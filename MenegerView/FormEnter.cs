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
    public partial class FormEnter : Form
    {
        public FormEnter()
        {
            InitializeComponent();
        }
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "admin" && textBoxPassword.Text == "admin")
            {
                FormMain formmain = new FormMain();
                this.Hide();
                formmain.ShowDialog();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
