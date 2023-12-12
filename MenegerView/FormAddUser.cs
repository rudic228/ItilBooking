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
    public partial class FormAddUser : Form
    {
        public FormAddUser()
        {
            InitializeComponent();
            
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Context context = new Context();
            if (textBoxName.Text != null && textBoxLastName.Text != null && textBoxSurname.Text != null && textBoxPhone.Text != null && textBoxMail.Text != null)
            {
                User user = new User
                {
                    Id = new Guid(),
                    Name = textBoxName.Text,
                    Surname = textBoxSurname.Text,
                    Patronymic = textBoxLastName.Text,
                    FullName = ""+ textBoxName.Text +  " " + textBoxSurname.Text + " " + textBoxLastName.Text + "",
                    Phone = textBoxPhone.Text,
                    Email = textBoxMail.Text
                };
                context.Users.Add(user);
                context.SaveChanges();
                FormAdd formwork = new FormAdd(true);
                formwork.comboBoxFIO.Items.Add("" + textBoxName.Text + " " + textBoxSurname.Text + " " + textBoxLastName.Text + "");
                this.Hide();
                formwork.ShowDialog();
            }
            else { MessageBox.Show("У вас остались незаполненные поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
