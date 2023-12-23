using Dal.Enums;

namespace Dal.Entities
{
    public class Booking
    {
        public Guid Id { get; set; }

        public Guid RoomId { get; set; }

        public Room Room { get; set; }

        public DateTime BeginBookingDate { get; set; }

        public DateTime EndBookingDate { get; set; }

        public decimal Price { get; set; }

        public BookingState? BookingState { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
