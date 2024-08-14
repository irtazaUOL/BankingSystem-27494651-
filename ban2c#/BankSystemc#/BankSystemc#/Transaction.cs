using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace BankSystemc_
{
    public partial class Transaction : Form
    {
        public SqlConnection conn = new SqlConnection("Data Source=DESKTOP-K8BIO91\\SQLEXPRESS;Initial Catalog=BankSystem;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

        public Transaction()
        {
            InitializeComponent();
            pnltransaction.Visible = false;
            pnlwithdraw.Visible = false;
            depositepanel.Visible = false;
            historypnl.Visible = false;
            accounttype.Items.AddRange(new string[] { "Personal", "Business" });
            btnSearch.Click += btnSearch_Click;
        }

        public void depotredio_CheckedChanged(object sender, EventArgs e)
        {
            if (depotredio.Checked)
            {
                pnltransaction.Visible = false;
                pnlwithdraw.Visible = false;
                depositepanel.Visible = true;
                historypnl.Visible = false;
            }
        }

        public void withdrawredio_CheckedChanged(object sender, EventArgs e)
        {
            if (withdrawredio.Checked)
            {
                pnltransaction.Visible = false;
                pnlwithdraw.Visible = true;
                depositepanel.Visible = false;
                historypnl.Visible = false;
            }
        }

        public void transferredio_CheckedChanged(object sender, EventArgs e)
        {
            if (transferredio.Checked)
            {
                pnltransaction.Visible = true;
                pnlwithdraw.Visible = false;
                depositepanel.Visible = false;
                historypnl.Visible = false;
            }
        }

        public void Transaction_Load(object sender, EventArgs e)
        {
           // LoadAccountInformation();
        }


        public void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime startDate = StartDate.Value;
            DateTime endDate = dateTimePicker2.Value;
            string accountType = accounttype.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(accountType))
            {
                LoadTransactionHistory(startDate, endDate, accountType);
            }
            else
            {
                MessageBox.Show("Please select an account type.");
            }
        }

        public void LoadTransactionHistory(DateTime startDate, DateTime endDate, string accountType)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string q = "SELECT a.Name,a.FatherName,a.Address,a.MobileNumber,a.Email ,a.AccountNumber, a.AccountType,a.Balance, th.timestamp " +
                           "FROM account a " +
                           "JOIN transaction_history th ON a.AccountNumber = th.account_number " +
                           "WHERE th.timestamp BETWEEN @StartDate AND @EndDate " +
                           "AND a.AccountType = @AccountType " +
                           "ORDER BY th.timestamp DESC";

                using (SqlCommand command = new SqlCommand(q, conn))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);
                    command.Parameters.AddWithValue("@AccountType", accountType);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading transaction history: {ex.Message}");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
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
                    accountd.Text = accountNumber;
                    accountt.Text = accountNumber;
                    accountw.Text = accountNumber;
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

        public void RecordTransaction(string accountNumber, string transactionType, decimal amount)
        {
            if (!int.TryParse(txtbalanced.Text, out int parsedBalance) ||
                !int.TryParse(txtbalancet.Text, out int parsedBalancet) ||
                !int.TryParse(txtbalancew.Text, out int parsedBalancew))
            {
                MessageBox.Show("Please enter a valid integer for the balance.");
                return;
            }

            try
            {
                conn.Open();
                string query = "INSERT INTO transaction_history (account_number, transaction_type, amount, timestamp) VALUES (@AccountNumber, @TransactionType, @Amount, GETDATE())";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(new SqlParameter("@AccountNumber", accountNumber));
                command.Parameters.Add(new SqlParameter("@TransactionType", transactionType));
                command.Parameters.Add(new SqlParameter("@Amount", amount));

                command.ExecuteNonQuery();
                MessageBox.Show("Transaction recorded successfully.");
                LoadTransactionHistory(DateTime.Now.AddMonths(-1), DateTime.Now, transactionType); // Example call
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

        public void Deposit(string accountNumber, decimal amount)
        {
            try
            {
                conn.Open();
                string query = "UPDATE account SET Balance = Balance + @Amount WHERE AccountNumber = @AccountNumber";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(new SqlParameter("@Amount", amount));
                command.Parameters.Add(new SqlParameter("@AccountNumber", accountNumber));

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Deposit successful.");
                    RecordTransaction(accountNumber, "Deposit", amount);
                }
                else
                {
                    MessageBox.Show("Account not found. Deposit failed.");
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

        public void Transfer(string fromAccount, string toAccount, decimal amount)
        {
            try
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string withdrawQuery = "UPDATE account SET Balance = Balance - @Amount WHERE AccountNumber = @AccountNumber";
                    SqlCommand withdrawCommand = new SqlCommand(withdrawQuery, conn, transaction);
                    withdrawCommand.Parameters.Add(new SqlParameter("@Amount", amount));
                    withdrawCommand.Parameters.Add(new SqlParameter("@AccountNumber", fromAccount));
                    withdrawCommand.ExecuteNonQuery();

                    string depositQuery = "UPDATE account SET Balance = Balance + @Amount WHERE AccountNumber = @AccountNumber";
                    SqlCommand depositCommand = new SqlCommand(depositQuery, conn, transaction);
                    depositCommand.Parameters.Add(new SqlParameter("@Amount", amount));
                    depositCommand.Parameters.Add(new SqlParameter("@AccountNumber", toAccount));
                    depositCommand.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Transfer successful.");
                    RecordTransaction(fromAccount, "Transfer Out", amount);
                    RecordTransaction(toAccount, "Transfer In", amount);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"An error occurred during the transfer: {ex.Message}");
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

        public void Withdraw(string accountNumber, decimal amount)
        {
            try
            {
                conn.Open();
                string query = "UPDATE account SET Balance = Balance - @Amount WHERE AccountNumber = @AccountNumber";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(new SqlParameter("@Amount", amount));
                command.Parameters.Add(new SqlParameter("@AccountNumber", accountNumber));

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Withdrawal successful.");
                    RecordTransaction(accountNumber, "Withdraw", amount);
                }
                else
                {
                    MessageBox.Show("Account not found. Withdrawal failed.");
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

        public void Back_Click(object sender, EventArgs e)
        {
            Homepage hp = new Homepage();
            hp.Show();
        }

        public void guna2CustomRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            pnltransaction.Visible = false;
            pnlwithdraw.Visible = false;
            depositepanel.Visible = false;
            historypnl.Visible = true;
        }

    }
}
