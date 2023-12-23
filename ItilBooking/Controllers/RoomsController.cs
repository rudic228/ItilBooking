using Dal;
using Dal.EfExtensions;
using Dal.Enums;
using ItilBooking.Models;
using ItilBooking.Models.Room.Get;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItilBooking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomsController : Controller
    {
        Context context;
        public RoomsController(Context context) 
        {
            this.context = context;
        }
        [HttpGet("{roomId:guid}")]
        public async Task<IActionResult> Get(Guid roomId)
        {
            var room = context.Rooms
                .FirstOrDefault(x => x.Id == roomId);

            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        [HttpGet]

        public async Task<IActionResult> List(
            [FromQuery] FilterModel filter)
        {

            var query = context.Rooms
                .AsNoTracking();

            if (filter.BeginDate.HasValue)
            {
                query = query.Where(x => !x.Bookings.Any(y => y.EndBookingDate > filter.BeginDate));
                query = query.Where(x => !x.Checkins.Any(y => y.EndCheckinDate > filter.BeginDate));
            }

            if (filter.EndDate.HasValue)
            {
                query = query.Where(x => !x.Bookings.Any(y => y.BeginBookingDate < filter.EndDate));
                query = query.Where(x => !x.Checkins.Any(y => y.BeginCheckinDate < filter.EndDate));
            }

            if (filter.Level.HasValue)
            {
                query = query.Where(x => x.Level == filter.Level);
            }

            if (filter.NumberOfBeds.HasValue)
            {
                query = query.Where(x => x.NumberOfBeds >= filter.NumberOfBeds);
            }

            if (filter.RoomCategory.HasValue)
            {
                query = query.Where(x => x.Category == filter.RoomCategory);
            }

            var result = await query
                .Select(x => new RoomViewModel()
                {
                    Area = x.Area,
                    Category = x.Category.ToString(),
                    Id = x.Id,
                    Level = x.Level,
                    Number = x.Number,
                    NumberOfBeds = x.NumberOfBeds,
                    Price = x.Price,
                })
                .ToArrayAsync();


            return Ok(result);
        }

    }
}
