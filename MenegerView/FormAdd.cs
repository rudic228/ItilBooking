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

namespace MenegerView
{
    public partial class FormAdd : Form
    {
        int Id;
        Context context = new Context();
        public FormAdd(bool New)
        {
            InitializeComponent();
            Context context = new Context();
            var rooms = context.Rooms.ToList();
            foreach (var room in rooms)
            {
                comboBoxNumber.Items.Add(room.Number);
            }
            if (New == true)
            {
                comboBoxFIO.Visible = false;
                label1.Visible = false;
            }
            else 
            { 
                textBoxFIO.Visible = false;
                label2.Visible = false;
                var users = context.Users.ToList();
                foreach (var user in users)
                {
                    comboBoxNumber.Items.Add(user.FullName);
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if((textBoxFIO.Text != null || comboBoxFIO.SelectedIndex > -1) && textBoxSum != null && comboBoxNumber.SelectedIndex > -1)
            {
                if(dateTimePickerEnd.Value > DateTime.Today)
                {
                    if (dateTimePickerEnd.Value >= dateTimePickerStart.Value)
                    {
                        Room room = context.Rooms
                            .Where(x=> x.Number.ToString() == comboBoxNumber.SelectedItem.ToString())
                            .FirstOrDefault();
                        Checkin checkin = new Checkin
                        {
                            Id = new Guid(),
                            RoomId = room.Id,
                            //закончил на этом моменте!
                        };
                        MessageBox.Show("Успешно", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormMain formmain = new FormMain();
                        this.Hide();
                        formmain.ShowDialog();
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
    }
}
