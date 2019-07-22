using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Master
{
    public partial class AdminHome : Form
    {
        public AdminHome()
        {
            InitializeComponent();
        }

        private void inputToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void barangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MasterBarang a = new MasterBarang();
            a.Show();
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void karyawanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Master a = new Master();
            a.Show();
            this.Close();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login a = new Login();
            a.Show();
            this.Close();
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReport a = new FormReport();
            a.Show();
            this.Close();
        }
    }
}
