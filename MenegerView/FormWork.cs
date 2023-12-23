using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace MenegerView
{
    public partial class FormWork : Form
    {
        public FormWork()
        {
            InitializeComponent();
        }

        private void архивToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormArchive formarchive = new FormArchive();
            formarchive.ShowDialog();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Данный программный продукт был разработан студентом группы ИСЭбд-41 Казаковым Евгением специально для санатория 'Итиль'", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void создатьНовоеЗаселениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUsers formusers = new FormUsers();
            this.Hide();
            formusers.ShowDialog();
        }

        private void занятыеМестToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCheckIn formCheckIn = new FormCheckIn();
            formCheckIn.ShowDialog();
        }

        private void заселениеИзБронированияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBook formBook = new FormBook();
            formBook.ShowDialog();
        }
    }
}
