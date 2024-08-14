using System;
using System.Windows.Forms;

namespace BankSystemc_
{
    public partial class ONEtps : Form
    {
        public string generatedOtp;
        public DateTime generatedTimestamp;
        public const int OTP_VALIDITY_DURATION = 60; // in seconds

        public ONEtps(string otp, DateTime timestamp)
        {
            InitializeComponent();
            generatedOtp = otp;
            generatedTimestamp = timestamp;
        }

        public void otpverify_Click(object sender, EventArgs e)
        {

        }

        public void otp_Load(object sender, EventArgs e)
        {

        }

        public void txtotp_TextChanged(object sender, EventArgs e)
        {

        }

        public void lgn_Click(object sender, EventArgs e)
        {

        }

        public void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void ONEtps_Load(object sender, EventArgs e)
        {

        }

        public void lgn_Click_1(object sender, EventArgs e)
        {
            Login lg = new Login();
            this.Close();
            lg.Show();
        }

        public void otpverify_Click_1(object sender, EventArgs e)
        {

            string enteredOtp = txtotp.Text;


            TimeSpan timeElapsed = DateTime.Now - generatedTimestamp;
            if (timeElapsed.TotalSeconds > OTP_VALIDITY_DURATION)
            {
                MessageBox.Show("OTP has expired. Please go back to Login page to request a new OTP.");
                Login lg = new Login();
                lg.Show();
                return;
            }


            if (enteredOtp == generatedOtp)
            {
                MessageBox.Show("OTP verified successfully.");
                Homepage pg = new Homepage();
                pg.Show();
            }
            else
            {
                MessageBox.Show("Invalid OTP. Please try again.");
            }
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
