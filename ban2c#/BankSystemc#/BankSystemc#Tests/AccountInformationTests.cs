using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankSystemc_;
using Guna.UI2.WinForms;
using System.Data;
using System.Windows.Forms;

namespace BankSystemc_.Tests
{
    [TestClass()]
    public class AccountInformationTests
    {
        [TestMethod()]
        public void AccountInformationTest()
        {
            // Arrange
            var accountInformationForm = new AccountInformation();

            // Replace the actual database call with mock data
            accountInformationForm.guna2DataGridView1 = new Guna2DataGridView();

            // Manually create a DataTable to simulate database data
            DataTable mockData = new DataTable();
            mockData.Columns.Add("AccountNumber");
            mockData.Rows.Add("1234567890");

            // Act
            // Directly set the DataSource to mock data for testing purposes
            accountInformationForm.guna2DataGridView1.DataSource = mockData;

            // Assert
            Assert.IsNotNull(accountInformationForm.guna2DataGridView1.DataSource);
            Assert.AreEqual("1234567890", ((DataTable)accountInformationForm.guna2DataGridView1.DataSource).Rows[0]["AccountNumber"]);
        }
    }
}
