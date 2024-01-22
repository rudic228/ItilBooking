using Dal;
using Dal.Entities;
using Dal.Enums;
using ItilBooking.Models.Booking.Create;
using ItilBooking.Models.Booking.Get;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MailKit.Net.Smtp;
using MimeKit;
using System.Security.Claims;

namespace ItilBooking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class BookingsController : Controller
    {
        Context context;
        public BookingsController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var userId = GetUserId();
            var bookings = await context.Bookings
                .Where(x => x.UserId == userId)
                .Select(x => new BookingViewModel()
                {
                    BeginBookingDate = x.BeginBookingDate.ToString("d"),
                    EndBookingDate = x.EndBookingDate.ToString("d"),
                    Id = x.Id,
                    Price = x.Price,
                    RoomCategory = x.Room.Category.ToString(),
                    RoomNumber = x.Room.Number,
                    RoomPrice = x.Room.Price,
                })
                .ToArrayAsync();

            return Ok(bookings);
        }

        [HttpGet("{bookingId:guid}")]
        public async Task<IActionResult> Get(
            Guid bookingId) 
        {
            //Random rand = new Random();
            //var bookings = new List<Booking>(100000);
            //for(int i = 0; i < 100000; i++)
            //{
            //    bookings.Add(new Booking()
            //    {
            //        BeginBookingDate = DateTime.Now.AddDays(rand.Next(500)),
            //        EndBookingDate = DateTime.Now.AddDays(rand.Next(500)),
            //        BookingState = (BookingState)rand.Next(0, 1),
            //        Id = Guid.NewGuid(),
            //        Price = rand.Next(1000),
            //        UserId = new Guid("934711d3-f145-4fdb-bc98-76d7651147e5"),
            //        RoomId = new Guid("4a925d97-a5e0-4524-ad9f-56a4d5de356d"),
            //    });
            //}
            //await context.BulkInsertAsync(bookings);
            //await context.SaveChangesAsync();

            var booking = await context.Bookings
                .Select(x => new BookingViewModel()
                {
                    BeginBookingDate = x.BeginBookingDate.ToString("d"),
                    EndBookingDate = x.EndBookingDate.ToString("d"),
                    Id = bookingId,
                    Price = x.Price,
                    RoomCategory = x.Room.Category.ToString(),
                    RoomNumber = x.Room.Number,
                    RoomPrice = x.Room.Price,
                })
                .FirstOrDefaultAsync(x => x.Id == bookingId);

            if(booking is null)
            {
                return NotFound($"Не найдена бронь {bookingId}");
            }

            return Ok(booking);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] BookingForm request)
        {
            if(request.BeginBookingDate >= request.EndBookingDate)
            {
                return BadRequest($"Дата окончания не может быть меньше даты начала");
            }

            if(request.BeginBookingDate < DateTime.Today)
            {
                return BadRequest($"Дата начала не может быть меньше текущей даты");
            }

            var room = await context.Rooms
                .Select(x => new
                {
                    x.Id,
                    x.Price,
                    x.NumberOfBeds
                })
                .FirstOrDefaultAsync(x => x.Id == request.RoomId);

            if (room is null)
            {
                return BadRequest($"Не найден номер {request.RoomId}");
            }

            if(room.NumberOfBeds < request.NumberOfBeds)
            {
                return BadRequest($"В номере не хватает мест");
            }

            var isBookingExist = await context.Bookings
                .AnyAsync(x => (request.BeginBookingDate >= x.BeginBookingDate && request.BeginBookingDate <= x.EndBookingDate && request.RoomId == x.RoomId)
                || (request.EndBookingDate >= x.BeginBookingDate && request.EndBookingDate <= x.EndBookingDate && request.RoomId == x.RoomId));

            if (isBookingExist)
            {
                return BadRequest("На выбранные даты номер занят");
            }


            var isCheckinExist = await context.Checkins
                .AnyAsync(x => (request.BeginBookingDate >= x.BeginCheckinDate && request.BeginBookingDate <= x.EndCheckinDate && request.RoomId == x.RoomId)
                || (request.EndBookingDate >= x.BeginCheckinDate && request.EndBookingDate <= x.EndCheckinDate && request.RoomId == x.RoomId));

            if (isCheckinExist)
            {
                return BadRequest("На выбранные даты номер занят");
            }

            var userId = GetUserId();

            var price = (room.Price * (request.EndBookingDate - request.BeginBookingDate).Days) + 1;

            var booking = new Booking()
            {
                Id = new Guid(),
                BeginBookingDate = request.BeginBookingDate,
                EndBookingDate = request.EndBookingDate,
                RoomId = request.RoomId,
                UserId = userId,
                Price = price,
            };
            context.Bookings.Add(booking);

            var user = await context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
            {
                return BadRequest("Пользователь не найден");
            }


            context.SaveChanges();

            await SendEmailAsync(user.Email, "Номер забронирован", $"<h3>Вы успешно забронировали номер с {request.BeginBookingDate.ToShortDateString()} по {request.EndBookingDate.ToShortDateString()}</h3>" +
                $"<br><p>тут должна быть верстка</p>");




            return Ok(booking.Id);
        }

        [HttpDelete("{bookingId:guid}")]
        public async Task<IActionResult> Delete(
            Guid bookingId)
        {
            var booking = await context.Bookings.FirstOrDefaultAsync(x => x.Id == bookingId);
            if (booking is null)
            {
                return NotFound($"Не найдена бронь {bookingId}");
            }

            context.Bookings.Remove(booking);

            context.SaveChanges();

            return Ok(bookingId);
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "zhenya_mironov_92@list.ru"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.mail.ru", 465, true);
                await client.AuthenticateAsync("zhenya_mironov_92@list.ru", "39hwkJjaJC9YJDGPjZrc");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }


        private Guid GetUserId()
        {
            var value = User.Claims.FirstOrDefault(x => x.Type == ClaimsIdentity.DefaultNameClaimType);
            if (value == null)
            {
                throw new InvalidOperationException("Не найдено утверждение с идентификатором клиента");
            }

            if(!Guid.TryParse(value.Value, out Guid userId))
            {
                throw new InvalidCastException($"Неверное значение поля userId {value.Value}");
            }
            return userId;
        }
    }
}
