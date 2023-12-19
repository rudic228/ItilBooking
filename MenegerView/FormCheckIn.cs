using Dal;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MenegerView
{
    public partial class FormCheckIn : Form
    {
        Context context = new Context();
        public FormCheckIn()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            var check = context.Checkins
               .Select(x => new CheckInOldViewModel()
               {
                   BeginCheckinDate = x.BeginCheckinDate,
                   RoomNumber = x.Room.Number,
                   Id = x.Id,
                   EndCheckinDate = x.EndCheckinDate,
                   Price = x.Price,
                   FullName = x.User.FullName
               })
               .Where(x => x.EndCheckinDate >= DateTime.Today)
               .ToList();
            dataGridView1.DataSource = check;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 250;
        }

        private void FormCheckIn_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonFiltr_Click(object sender, EventArgs e)
        {
    //        var check = context.Checkins.AsEnumerable()
    //        .Select(x => new CheckInOldViewModel())
    //        .Where(x => (string.IsNullOrEmpty(textBoxName.Text) || x.FullName == textBoxName.Text)
    //        && (string.IsNullOrEmpty(textBoxName.Text) || x.RoomNumber.ToString() == textBoxName.Text))
    //.ToList();
    //        dataGridView1.DataSource = check;
        }
    }
}
