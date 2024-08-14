using System;
using Microsoft.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Drawing;
using Guna.UI2.WinForms;
namespace BankSystemc_
{
    public partial class Login : Form
    {
        public SqlConnection conn = new SqlConnection("Data Source=DESKTOP-K8BIO91\\SQLEXPRESS;Initial Catalog=BankSystem;Integrated Security=True;TrustServerCertificate=True");


        public Login()
        {
            InitializeComponent();
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
            this.FormClosing += new FormClosingEventHandler(OnFormClosing);

        }

        public void Form1_Load(object sender, EventArgs e)
        {
            
        }
        public void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (SqlConnection exitConn = new SqlConnection("Data Source=DESKTOP-K8BIO91\\SQLEXPRESS;Initial Catalog=BankSystem;Integrated Security=True;TrustServerCertificate=True"))
                {
                    exitConn.Open();
                    string clearLogQuery = "DELETE FROM login_log";
                    SqlCommand clearLogCommand = new SqlCommand(clearLogQuery, exitConn);
                    clearLogCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Show an error message if the operation fails
                MessageBox.Show($"An error occurred while clearing the login log: {ex.Message}");
            }
        }

        public void OnApplicationExit(object sender, EventArgs e)
        {
            try
            {
                // Create a new connection to ensure the connection is closed cleanly
                using (SqlConnection exitConn = new SqlConnection("Data Source=DESKTOP-K8BIO91\\SQLEXPRESS;Initial Catalog=BankSystem;Integrated Security=True;TrustServerCertificate=True"))
                {
                    exitConn.Open();
                    string clearLogQuery = "DELETE FROM login_log";
                    SqlCommand clearLogCommand = new SqlCommand(clearLogQuery, exitConn);
                    clearLogCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Show an error message if the operation fails
                MessageBox.Show($"An error occurred while clearing the login log: {ex.Message}");
            }
        }
        public void EmailSend(string toEmail, string subject, string body)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential("abdulhanaaan123@gmail.com", "vrcr iibl xcyr ecap")
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("abdulhanaaan123@gmail.com"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false,
                };

                mailMessage.To.Add(toEmail);

                smtpClient.Send(mailMessage);

                MessageBox.Show("Email sent successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while sending the email: {ex.Message}");
            }
        }
        public (string otp, DateTime timestamp) GenerateOTP()
        {
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                byte[] randomNumber = new byte[4];
                rng.GetBytes(randomNumber);
                int otp = Math.Abs(BitConverter.ToInt32(randomNumber, 0)) % 1000000;

                // Ensure OTP is always 6 digits
                string otpString = otp.ToString("D6");

                DateTime timestamp = DateTime.Now;
                return (otpString, timestamp);
            }
        }

        public void guna2Button2_Click(object sender, EventArgs e)

            {
                // Retrieve the values from the TextBoxes
                string uname = Name.Text;
                string uemail = Email.Text;
                

                // Validate if the fields are not empty
                if (string.IsNullOrWhiteSpace(uname) || string.IsNullOrWhiteSpace(uemail))
                {
                    MessageBox.Show("Please enter all required fields.");
                    return;
                }

                try
                {
                    conn.Open();

                    // Query to check if the provided credentials are correct
                    string query = "SELECT AccountNumber FROM account WHERE Name = @Name AND Email = @Email ";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.Add(new SqlParameter("@Name", uname));
                    command.Parameters.Add(new SqlParameter("@Email", uemail));


                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        string accountNumber = result.ToString();

                        // Generate OTP and get timestamp
                        var (otpp, timestamp) = GenerateOTP();

                        // Insert login details into the login_log table
                        string logQuery = "INSERT INTO login_log (account_number, Name) VALUES (@AccountNumber, @Name)";
                        SqlCommand logCommand = new SqlCommand(logQuery, conn);
                        logCommand.Parameters.Add(new SqlParameter("@AccountNumber", accountNumber));
                        logCommand.Parameters.Add(new SqlParameter("@Name", uname));

                        logCommand.ExecuteNonQuery();

                        MessageBox.Show("Successfully logged in.");

                        // Send the OTP email to the address specified in the email TextBox
                        string subject = "Your OTP Code";
                        string body = $"Your OTP code is: {otpp}";
                        EmailSend(uemail, subject, body);

                        // Open the OTP form and pass the OTP and timestamp
                        ONEtps otpForm = new ONEtps(otpp, timestamp);
                        this.Close();
                        otpForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid credentials. Please try again.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
                finally
                {
                    conn.Close();
                }
            

        }
    }
}
