using System;
using System.Windows.Forms;

namespace BankSystemc_
{
    public partial class MainWindow : Form
    {
        private const int ProgressBarMaxValue = 100;
        private const int TimerIntervalMs = 50; // Interval in milliseconds

        public MainWindow()
        {
            InitializeComponent();
            timer1.Interval = TimerIntervalMs; // Set timer interval
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < ProgressBarMaxValue)
            {
                progressBar1.Value += 1;
                label1.Text = progressBar1.Value.ToString() + "%";
            }
            else
            {
                timer1.Stop();
                // Show the Login form
                Login lg = new Login();
                lg.Show();
                // Close the main window
                this.Close();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Prevent the application from exiting
                e.Cancel = true;
                this.Hide();
            }
        }
    }
}
