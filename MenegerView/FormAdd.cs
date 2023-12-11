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
    public partial class FormAdd : Form
    {
        public FormAdd(bool New)
        {
            //if (New == true)
            //{
            //    comboBoxFIO.Visible = false;
            //    label1.Visible = false;
            //}
            //else { textBoxFIO.Visible = false; label2.Visible = false; }
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Успешно", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FormMain formmain = new FormMain();
            this.Hide();
            formmain.ShowDialog();
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Тут открывается форма отчета(чека)", "Отчет", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
