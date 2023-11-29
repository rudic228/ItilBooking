using Dal.Enums;

namespace DbSeeding.Parsers.Rooms
{
    public class RoomRecord
    {
        public int Number { get; set; }

        public int Level { get; set; }

        public RoomCategory Category { get; set; }

        public decimal Area { get; set; }

        public decimal Price { get; set; }
    }
}
