using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenegerView.Models.Main
{
    public class CheckInOldViewModel
    {
        public Guid Id { get; set; }
        [System.ComponentModel.DisplayName("ФИО")]

        public string? FullName { get; set; }
        [System.ComponentModel.DisplayName("Комната")]

        public int RoomNumber { get; set; }
        [System.ComponentModel.DisplayName("Цена")]

        public decimal Price { get; set; }
        [System.ComponentModel.DisplayName("ДатаНачала")]

        public DateTime BeginCheckinDate { get; set; }

        [System.ComponentModel.DisplayName("ДатаКонца")]
        public DateTime EndCheckinDate { get; set; }
        
        
        
    }
}
