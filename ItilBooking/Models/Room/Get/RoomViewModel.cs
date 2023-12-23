using Dal.Enums;

namespace ItilBooking.Models.Room.Get
{
    public class RoomViewModel
    {
        public Guid Id { get; set; }

        public int Number { get; set; }

        public int NumberOfBeds { get; set; }

        public int Level { get; set; }

        public string Category { get; set; }

        public decimal Area { get; set; }

        public decimal Price { get; set; }
    }
}
