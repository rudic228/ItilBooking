using Dal;
using Dal.EfExtensions;
using ItilBooking.Models;
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
            [FromQuery] FilterModel filter
            )
        {

            var query = context.Rooms
                .AsNoTracking();


            if (!string.IsNullOrEmpty(filter.StringFilter))
            {
                var splitStringFilter = filter.StringFilter.Split(" ");
                if (splitStringFilter.Length != 2)
                {
                    query.StringFilter(splitStringFilter[0], splitStringFilter[1], splitStringFilter[2]);
                }
            }

            return Ok(query.ToArray());
        }

    }
}
