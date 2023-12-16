using Dal;
using Dal.Entities;
using MenegerView.Models.Main;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
    public partial class FormMain : Form
    {
        Context context = new Context();
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonBook_Click(object sender, EventArgs e)
        {
            FormAdd formwork = new FormAdd(false);
            formwork.ShowDialog();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormAddUser formwork = new FormAddUser();
            formwork.ShowDialog();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить запись? Это действие нельзя будет отменить", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    var del = context.Checkins
                .Where(x => x.Id.ToString() == id)
                .FirstOrDefault();
                    context.Checkins.Remove(del);
                    context.SaveChanges();
                    MessageBox.Show("Запись была успешно удалена из базы данных", "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            FormAdd formwork = new FormAdd(false);
            formwork.ShowDialog();
        }
        private void LoadData()
        {
            var residents = context.Checkins
                .Select(x => new CheckInViewModel()
                {
                    BeginCheckinDate = x.BeginCheckinDate,
                    RoomNumber = x.Room.Number,
                    Id = x.Id,
                    EndCheckinDate = x.EndCheckinDate,
                    Price = x.Price,
                    FullName = x.User.FullName
                })
                .ToList();
            dataGridView1.DataSource = residents;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
            var check = context.Checkins
                .Where(x => x.EndCheckinDate < DateTime.Today)
                .ToList();
            if (!check.Any())
            {
                context.Checkins.RemoveRange(check);
                context.SaveChanges();
            }
        }

        private void buttonRefForm_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
