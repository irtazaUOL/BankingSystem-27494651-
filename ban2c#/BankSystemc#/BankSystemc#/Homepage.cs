using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystemc_
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            AccountManagement am = new AccountManagement();
            this.Close();
            am.Show();
        }

        public void button2_Click(object sender, EventArgs e)
        {
            Transaction tc = new Transaction();
            this.Close();
            tc.Show();
        }

        public void button3_Click(object sender, EventArgs e)
        {
            AServices aServices = new AServices();
            this.Close();
            aServices.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
                lg.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Homepage hm = new Homepage();
            hm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
        }
    }
}
