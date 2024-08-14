using Microsoft.Data.SqlClient;
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
    public partial class AccountInformation : Form
    {
        public SqlConnection conn = new SqlConnection("Data Source=DESKTOP-K8BIO91\\SQLEXPRESS;Initial Catalog=BankSystem;Integrated Security=True;TrustServerCertificate=True");

        public AccountInformation()
        {
            InitializeComponent();
        }

        public void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void button2_Click(object sender, EventArgs e)
        {
            AccountManagement am = new AccountManagement();
            this.Close();
            am.Show();
        }

        public void AccountInformation_Load(object sender, EventArgs e)
        {
            LoadAccountInformation();
        }
        public void LoadAccountInformation()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                // Query to get the last login account number from the login_log table
                string query = "SELECT TOP 1 account_number FROM login_log ORDER BY login_time DESC";
                SqlCommand command = new SqlCommand(query, conn);

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    string accountNumber = result.ToString();
                    // Assuming `account` is the name of your TextBox control
                    account.Text = accountNumber;
                    // Retrieve account details using the obtained account number
                    DisplayAccountDetails(accountNumber);
                }
                else
                {
                    MessageBox.Show("No account information found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public void DisplayAccountDetails(string accountNumber)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                // Query to get the account details from the account table
                string query = "SELECT * FROM account WHERE AccountNumber = @AccountNumber";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(new SqlParameter("@AccountNumber", accountNumber));

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Assuming dataGridView1 is the DataGridView control on your form
                guna2DataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Homepage hm = new Homepage();
            this.Hide();
            hm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
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
    }
}
