namespace Dal.Entities
{
    public class Checkin
    {
        public Guid Id { get; set; }

        public Guid RoomId { get; set; }

        public Room Room { get; set; }

        public DateTime BeginCheckinDate { get; set; }

        public DateTime EndCheckinDate { get; set; }

        public decimal Price { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
