using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Enums;

namespace Dal.Entities
{
    public class Room
    {
        public Guid Id { get; set; }

        public int Level { get; set; }

        public RoomCategory Category {  get; set; }

        public decimal Area { get; set; }

        public decimal Price { get; set; }
    }
}
