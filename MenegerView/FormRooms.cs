using Dal.Entities;
using Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenegerView
{
    public partial class FormRooms : Form
    {
        Context context = new Context();
        Guid nameId;

        public FormRooms(Guid NameId)
        {
            InitializeComponent();
            nameId = NameId;
            var uniqueFloors = context.Rooms
                .Select(r => r.Level)
                .Distinct()
                .ToList();
            foreach (var floor in uniqueFloors)
            {
                comboBoxFloor.Items.Add(floor);
            }
        }
        private void LoadData()
        {
            var unbooked = context.Rooms
                .Where(r => !context.Bookings.Any(b => (b.RoomId == r.Id) && b.EndBookingDate >= DateTime.Today) && !context.Checkins.Any(c => c.RoomId == r.Id && c.EndCheckinDate >= DateTime.Today))
                .ToList();

            if (unbooked == null)
            {
                MessageBox.Show("На сегодня нет свободных номеров", "Внимаение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormUsers formuser = new FormUsers();
                this.Hide();
                formuser.ShowDialog();
            }
            else
            {
                dataGridView1.DataSource = unbooked;
                dataGridView1.Columns[0].Visible = false;
            }

        }

        private void FormRooms_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            FormUsers formUsers = new FormUsers();
            this.Hide();
            formUsers.ShowDialog();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            Guid guidRoom = Guid.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            FormAdd formadd = new FormAdd(nameId, guidRoom);
            this.Hide();
            formadd.ShowDialog();
        }

        private void comboBoxFloor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var unbooked = context.Rooms
                .Where(r => !context.Bookings.Any(b => (b.RoomId == r.Id) && b.EndBookingDate >= DateTime.Today) && !context.Checkins.Any(c => c.RoomId == r.Id && c.EndCheckinDate >= DateTime.Today) && r.Level.ToString() == comboBoxFloor.SelectedItem.ToString())
                .ToList();
            if (unbooked.Count == 0)
            {
                MessageBox.Show("На данном этаже нету свободных номеров", "Внимаение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                dataGridView1.DataSource = unbooked;
                dataGridView1.Columns[0].Visible = false;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
