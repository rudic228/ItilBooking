using Dal.Entities;
using Dal.Enums;

namespace ItilBooking.Models.Booking.Get
{
    public class BookingViewModel
    {
        public Guid Id { get; set; }

        public int RoomNumber { get; set; }

        public decimal RoomPrice { get; set; }

        public string RoomCategory { get; set; }

        public string BeginBookingDate { get; set; }

        public string EndBookingDate { get; set; }

        public decimal Price { get; set; }
    }
}
