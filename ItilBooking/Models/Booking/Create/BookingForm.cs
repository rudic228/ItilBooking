using Dal.Entities;
using Dal.Enums;

namespace ItilBooking.Models.Booking.Create
{
    public class BookingForm
    {
        public Guid RoomId { get; set; }

        public DateTime BeginBookingDate { get; set; }

        public DateTime EndBookingDate { get; set; }

        public int NumberOfBeds { get; set; }
    }
}
