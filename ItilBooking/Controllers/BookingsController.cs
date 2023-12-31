﻿using Dal;
using Dal.Entities;
using ItilBooking.Models.Booking.Create;
using ItilBooking.Models.Booking.Get;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            context.SaveChanges();

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
