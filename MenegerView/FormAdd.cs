using Dal;
using Dal.Entities;
using MenegerView.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
            var bookings = context.Bookings.ToList();
            var unbooked = context.Rooms
                .Where(r => !context.Bookings.Any(b => b.RoomId == r.Id) && !context.Checkins.Any(c => c.RoomId == r.Id))
                .Select(r => r.Number)
                .ToList();
            foreach (var room in unbooked)
            {
                comboBoxNumber.Items.Add(room);
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

            if (dateTimePickerEnd.Value <= DateTime.Today)
            {
                MessageBox.Show("Дата окончания меньше реальной даты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxFIO.SelectedIndex == -1 && textBoxSum == null && comboBoxNumber.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбран не один из параметор", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dateTimePickerEnd.Value < dateTimePickerStart.Value)
            {
                MessageBox.Show("Дата начала не может быть больше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Room room = context.Rooms
                .Where(x => x.Number.ToString() == comboBoxNumber.SelectedItem.ToString())
                .FirstOrDefault();
            if(room == null)
            {
                MessageBox.Show("Комната не найдена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            User user = context.Users
                 .Where(x => x.FullName == comboBoxFIO.SelectedItem.ToString())
                 .FirstOrDefault();
            if (user == null)
            {
                MessageBox.Show("Человек не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DateTime dt1, dt2;
            TimeSpan delta;
            dt1 = dateTimePickerStart.Value.Date;
            dt2 = dateTimePickerEnd.Value.Date;
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

            ToWord.ExportData(comboBoxFIO.Text, (Convert.ToDecimal(textBoxSum.Text) * delta.Days).ToString(), dateTimePickerStart.Value.ToString(), dateTimePickerEnd.Value.ToString());

            MessageBox.Show("Успешно", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
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
