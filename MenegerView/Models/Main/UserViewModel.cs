using Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenegerView.Models.Main
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        [System.ComponentModel.DisplayName("ФИО")]
        public string FullName { get; set; }
        [System.ComponentModel.DisplayName("Телефон")]
        public string Phone { get; set; }
        [System.ComponentModel.DisplayName("Почта")]
        public string Email { get; set; }
        [System.ComponentModel.DisplayName("Логин")]
        public string Login { get; set; }
    }
}
