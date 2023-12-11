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
            FormAdd formwork = new FormAdd(true);
            formwork.ShowDialog();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Удалил", "УПС!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            FormAdd formwork = new FormAdd(true);
            formwork.ShowDialog();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //context.Checkins.Select
        }
    }
}
