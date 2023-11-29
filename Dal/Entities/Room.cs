using Dal.Enums;

namespace Dal.Entities
{
    public class Room
    {
        public Guid Id { get; set; }

        public int Number { get; set; }

        public int Level { get; set; }

        //[Column(TypeName = "text")]
        public RoomCategory Category {  get; set; }

        public decimal Area { get; set; }

        public decimal Price { get; set; }
    }
}
