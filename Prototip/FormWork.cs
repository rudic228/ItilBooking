using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototip
{
    public partial class FormWork : Form
    {
        
        public FormWork(bool New)
        {
            InitializeComponent();
            if(New == true)
            {
                comboBox1.Visible = false;
                label1.Visible = false;
            }
            else {  textBox3.Visible = false; label6.Visible = false; }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Успешно", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FormMain formmain = new FormMain();
            this.Hide();
            formmain.ShowDialog();
        }

        private void button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Тут открывается форма отчета(чека)", "Отчет", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
