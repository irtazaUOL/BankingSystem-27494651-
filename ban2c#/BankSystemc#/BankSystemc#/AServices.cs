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
    public partial class AServices : Form
    {
        public AServices()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pyment_method pyment_Method = new pyment_method();
            this.Close();
            pyment_Method.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            service sc = new service();
            this.Close();
            sc.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AccountManagement am = new AccountManagement();
            this.Close();
            am.Show();
        }

        private void AServices_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Homepage hm = new Homepage();
            this.Close();
            hm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Homepage hm = new Homepage();
            this.Hide();
            hm.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            this.Hide();
            lg.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            this.Hide();
            lg.Show();
        }
    }
}
