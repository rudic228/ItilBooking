using Dal;
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
    public partial class FormArchive : Form
    {
        Context context = new Context();
        public FormArchive()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            var oldcheck = context.Checkins
                .Select(x => new CheckInOldViewModel()
                {
                    BeginCheckinDate = x.BeginCheckinDate,
                    RoomNumber = x.Room.Number,
                    Id = x.Id,
                    EndCheckinDate = x.EndCheckinDate,
                    Price = x.Price,
                    FullName = x.User.FullName
                })
                .Where(x => x.EndCheckinDate < DateTime.Today)
                .ToList();
            dataGridView1.DataSource = oldcheck;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 250;
        }

        private void FormArchive_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var search = context.Checkins
           .Select(x => new CheckInOldViewModel()
           {
               BeginCheckinDate = x.BeginCheckinDate,
               RoomNumber = x.Room.Number,
               Id = x.Id,
               EndCheckinDate = x.EndCheckinDate,
               Price = x.Price,
               FullName = x.User.FullName
           })
           .Where(x => x.EndCheckinDate < DateTime.Today && x.FullName.Contains(textBox1.Text))
           .ToList();
            dataGridView1.DataSource = search;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 250;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
