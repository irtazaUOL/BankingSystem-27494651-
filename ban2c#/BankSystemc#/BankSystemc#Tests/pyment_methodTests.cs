using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankSystemc_;
using System;
using System.Data;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace BankSystemc_.Tests
{
    [TestClass()]
    public class pyment_methodTests
    {
        [TestMethod()]
        public void LoadPaymentDataTest()
        {
            // Arrange
            var paymentForm = new pyment_method();

            // Create a DataGridView to simulate the data grid on the form
            paymentForm.dataGridView1 = new Guna2DataGridView();

            // Manually create a DataTable to simulate data from the database
            DataTable mockData = new DataTable();
            mockData.Columns.Add("Type");
            mockData.Columns.Add("Details");
            mockData.Columns.Add("Amount");
            mockData.Columns.Add("SetupDateTime");

            // Add mock data row
            mockData.Rows.Add("Direct Debit", "Details", "100", DateTime.Now);

            // Act
            // Simulate loading data into the DataGridView by setting the DataSource
            paymentForm.dataGridView1.DataSource = mockData;

            // Assert
            Assert.IsNotNull(paymentForm.dataGridView1.DataSource);
            Assert.AreEqual("Direct Debit", ((DataTable)paymentForm.dataGridView1.DataSource).Rows[0]["Type"]);
            Assert.AreEqual("Details", ((DataTable)paymentForm.dataGridView1.DataSource).Rows[0]["Details"]);
            Assert.AreEqual("100", ((DataTable)paymentForm.dataGridView1.DataSource).Rows[0]["Amount"]);
        }
    }
}
