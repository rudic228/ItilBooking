using Dal;
using Dal.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MenegerView
{
    public partial class FormAdd : Form
    {
        public string name;
        Context context = new Context();
        public FormAdd(bool New)
        {
            InitializeComponent();
            Context context = new Context();
            var rooms = context.Rooms.ToList();
            var bookings = context.Bookings.ToList();
            foreach (var room in rooms)
            {
                comboBoxNumber.Items.Add(room.Number);
            }
            if (New == false)
            {
                comboBoxFIO.Items.Clear();
                foreach (var book in bookings)
                {
                    User user = context.Users
                        .Where(x => x.Id == book.UserId)
                        .FirstOrDefault();
                    comboBoxFIO.Items.Add(user.FullName);
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (comboBoxFIO.SelectedIndex > -1 && textBoxSum != null && comboBoxNumber.SelectedIndex > -1)
            {
                if (dateTimePickerEnd.Value > DateTime.Today)
                {
                    if (dateTimePickerEnd.Value >= dateTimePickerStart.Value)
                    {
                        Room room = context.Rooms
                            .Where(x => x.Number.ToString() == comboBoxNumber.SelectedItem.ToString())
                            .FirstOrDefault();
                            User user = context.Users
                                .Where(x => x.FullName == comboBoxFIO.SelectedItem.ToString())
                                .FirstOrDefault();
                        DateTime dt1, dt2;
                        TimeSpan delta;
                        dt1 = dateTimePickerStart.Value;
                        dt2= dateTimePickerEnd.Value;
                        delta = dt2 - dt1;
                        Checkin checkin = new Checkin
                        {
                            Id = new Guid(),
                            RoomId = room.Id,
                            BeginCheckinDate = dateTimePickerStart.Value,
                            EndCheckinDate = dateTimePickerEnd.Value,
                            Price = Convert.ToDecimal(textBoxSum.Text) * delta.Days,
                            UserId = user.Id
                        };
                        context.Checkins.Add(checkin);
                        context.SaveChanges();
                        MessageBox.Show("Успешно", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                    }
                    else { MessageBox.Show("Дата начала не может быть больше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else { MessageBox.Show("Дата окончания меньше реальной даты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else { MessageBox.Show("Не выбран не один из параметор", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Тут открывается форма отчета(чека)", "Отчет", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void comboBoxNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            Room room = context.Rooms
                .Where(x=>x.Number.ToString()==comboBoxNumber.SelectedItem.ToString())
                .FirstOrDefault();
            textBoxSum.Text = room.Price.ToString();
        }
    }
}
