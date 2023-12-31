﻿using Dal.Enums;

namespace Dal.Entities
{
    public class Room
    {
        public Guid Id { get; set; }

        public int Number { get; set; }

        public int NumberOfBeds { get; set; }

        public int Level { get; set; }

        public RoomCategory Category {  get; set; }

        public decimal Area { get; set; }

        public decimal Price { get; set; }

        public List<Booking> Bookings { get; set; }

        public List<Checkin> Checkins { get; set; }
    }
}
