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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormWork formwork = new FormWork(false);
            formwork.ShowDialog();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Удалил", "УПС!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            FormWork formwork = new FormWork(true);
            formwork.ShowDialog();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            FormWork formwork = new FormWork(true);
            formwork.ShowDialog();
        }
    }
}
