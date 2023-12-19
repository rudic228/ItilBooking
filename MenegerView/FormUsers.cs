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
    public partial class FormUsers : Form
    {
        Context context = new Context();
        public FormUsers()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            FormWork formwork = new FormWork();
            this.Hide();
            formwork.ShowDialog();
        }

        private void LoadData()
        {
            var users = context.Users
                .Select(x => new UserViewModel()
                {
                    FullName = x.FullName,
                    Phone = x.Phone,
                    Id = x.Id,
                    Email = x.Email,
                    Login = x.Login
                })
                .ToList();
            dataGridView1.DataSource = users;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[3].Width = 150;
        }

        private void FormUsers_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            LoadData();
            textBox1.Text = "";
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            var user = context.Users
                .Where(x => x.Phone.Contains(textBox1.Text))
                .ToList();
            dataGridView1.DataSource = user;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            
        }
    }
}
