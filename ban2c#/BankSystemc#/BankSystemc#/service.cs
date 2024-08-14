using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace BankSystemc_
{
    public partial class service : Form
    {
        public SqlConnection conn = new SqlConnection("Data Source=DESKTOP-K8BIO91\\SQLEXPRESS;Initial Catalog=BankSystem;Integrated Security=True;TrustServerCertificate=True");

        public service()
        {
            InitializeComponent();
            guna2ComboBox1.Items.AddRange(new string[] { "CheckBook", "CreditCard", "DebitCard" });
            guna2ComboBox1.SelectedIndexChanged += servicetype_SelectedIndexChanged;
        }

        public void back_Click(object sender, EventArgs e)
        {
            AServices ac = new AServices();
            this.Close();
            ac.Show();
        }

        public void Service_Load(object sender, EventArgs e)
        {
            LoadServiceData();

        }

        public void servicetype_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle the event if needed
        }

        public void btnsubmit_Click(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedItem != null)
            {
                string serviceDetail = guna2ComboBox1.SelectedItem.ToString();
                string detailedService = textBox1.Text;

                if (!string.IsNullOrEmpty(detailedService))
                {
                    try
                    {
                        if (conn.State == ConnectionState.Closed)
                        {
                            conn.Open();
                        }

                        string query = "INSERT INTO service (ServiceDetail, Status) VALUES (@ServiceDetail, 'Pending')";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@ServiceDetail", serviceDetail + ": " + detailedService);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Service request submitted successfully.");
                                LoadServiceData(); // Load data into DataGridView after successful submission
                            }
                            else
                            {
                                MessageBox.Show("Failed to submit service request.");
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
                    MessageBox.Show("Please fill in the service details.");
                }
            }
            else
            {
                MessageBox.Show("Please select a service type.");
            }
        }

        public void LoadServiceData()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string query = "SELECT * FROM service";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading data: {ex.Message}");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public void button2_Click(object sender, EventArgs e)
        {
            AServices aServices = new AServices();
            aServices.Show();
        }

        public void service_Load_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Homepage hm = new Homepage();
            hm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Homepage hm = new Homepage();
            hm.Show();
        }
    }
}
