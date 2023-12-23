using Dal;
using Dal.Entities;
using DocumentFormat.OpenXml.Drawing.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using MenegerView.Models.Main;
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
    public partial class FormBook : Form
    {
        Context context = new Context();
        public FormBook()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            var book = context.Bookings
                .Select(x => new CheckInOldViewModel()
                {
                    BeginCheckinDate = x.BeginBookingDate,
                    RoomNumber = x.Room.Number,
                    Id = x.Id,
                    EndCheckinDate = x.EndBookingDate,
                    Price = x.Price,
                    FullName = x.User.FullName
                })
                .Where(x => x.EndCheckinDate >= DateTime.Today)
                .ToList();
            dataGridView1.DataSource = book;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 250;
        }

        private void buttonGet_Click(object sender, EventArgs e)
        {
            var book = context.Bookings
                .Select(x => new CheckInOldViewModel()
                {
                    BeginCheckinDate = x.BeginBookingDate,
                    RoomNumber = x.Room.Number,
                    Id = x.Id,
                    EndCheckinDate = x.EndBookingDate,
                    Price = x.Price,
                    FullName = x.User.FullName
                })
                .Where(x => x.EndCheckinDate < DateTime.Today && x.FullName.Contains(textBox1.Text))
                .ToList();
            dataGridView1.DataSource = book;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 250;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Guid guid = Guid.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var book = context.Bookings
                .Where(x => x.Id == guid)
                .FirstOrDefault();

            Checkin frombook = new Checkin
            {
                Id = new Guid(),
                RoomId = book.RoomId,
                BeginCheckinDate = book.BeginBookingDate,
                EndCheckinDate = book.EndBookingDate,
                Price = book.Price,
                UserId = book.UserId,
            };
            book.BookingState = Dal.Enums.BookingState.Chekin;
            context.Checkins.Add(frombook);
            context.SaveChangesAsync();
            MessageBox.Show("Заселение произошло", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FormBook_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
