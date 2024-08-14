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
    public partial class AccountManagement : Form
    {
        public AccountManagement()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Update ud = new Update();
            this.Close();
            ud.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Delete delete = new Delete();
            this.Close();
            delete.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AccountInformation accountInformation = new AccountInformation();
            this.Close();
            accountInformation.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Homepage hm = new Homepage();
            this.Hide();
            hm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            this.Hide();
            lg.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            this.Hide();
            lg.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Homepage hm = new Homepage();
            this.Hide();
            hm.Show();
        }
    }
}
