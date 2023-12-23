using Dal.Enums;

namespace ItilBooking.Models
{
    public class FilterModel
    {
        public DateTime? EndDate { get; set; }

        public DateTime? BeginDate { get; set; }

        public int? Level { get; set; }

        public RoomCategory? RoomCategory { get; set; }

        public int? NumberOfBeds { get; set; }
    }
}
