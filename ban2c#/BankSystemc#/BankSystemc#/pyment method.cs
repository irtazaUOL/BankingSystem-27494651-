using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace BankSystemc_
{
    public partial class pyment_method : Form
    {
        public SqlConnection conn = new SqlConnection("Data Source=DESKTOP-K8BIO91\\SQLEXPRESS;Initial Catalog=BankSystem;Integrated Security=True");

        public pyment_method()
        {
            InitializeComponent();
            accounttype.Items.AddRange(new string[] { "Direct Debit", "RepeatPay" });
            accounttype.SelectedIndexChanged += type_SelectedIndexChanged;
        }

        public void button2_Click(object sender, EventArgs e)
        {
            AServices service = new AServices();
            this.Close();
            service.Show();
        }

        public void type_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle the event if needed
        }

        public void button1_Click(object sender, EventArgs e)
        {
            string paymentType = accounttype.SelectedItem.ToString();
            string paymentDetails = txtdetail.Text;
            string paymentAmount = txtamount.Text;

            if (!string.IsNullOrEmpty(paymentType) && !string.IsNullOrEmpty(paymentDetails) && !string.IsNullOrEmpty(paymentAmount))
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    string query = "INSERT INTO Payment (Type, Details, Amount, SetupDateTime) VALUES (@Type, @Details, @Amount, @SetupDateTime)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Type", paymentType);
                        cmd.Parameters.AddWithValue("@Details", paymentDetails);
                        cmd.Parameters.AddWithValue("@Amount", paymentAmount);
                        cmd.Parameters.AddWithValue("@SetupDateTime", DateTime.Now);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Payment details submitted successfully.");
                            LoadPaymentData();
                        }
                        else
                        {
                            MessageBox.Show("Failed to submit payment details.");
                        }
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
            else
            {
                MessageBox.Show("Please fill in all the fields.");
            }
        }

        public void PaymentMethord_Load(object sender, EventArgs e)
        {
            LoadAccountInformation();
            LoadPaymentData();
        }

        public void label5_Click(object sender, EventArgs e)
        {

        }

        public void LoadAccountInformation()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }


                string query = "SELECT TOP 1 account_number FROM login_log ORDER BY login_time DESC";
                SqlCommand command = new SqlCommand(query, conn);

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    string accountNumber = result.ToString();

                    txtamount.Text = accountNumber;


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

        public void LoadPaymentData()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string query = "SELECT Type, Details, Amount, SetupDateTime FROM Payment";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
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

        public void acn_TextChanged(object sender, EventArgs e)
        {

        }

        public void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
