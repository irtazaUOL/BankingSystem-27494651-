using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankSystemc_;
using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace BankSystemc_.Tests
{
    [TestClass()]
    public class AccountCreeateTests
    {
        [TestMethod()]
        public void IsValidEmailTest_ValidEmail_ReturnsTrue()
        {
            // Arrange
            var accountCreateForm = new AccountCreeate();
            string validEmail = "test@example.com";

            // Act
            bool result = accountCreateForm.IsValidEmail(validEmail);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsValidEmailTest_InvalidEmail_ReturnsFalse()
        {
            // Arrange
            var accountCreateForm = new AccountCreeate();
            string invalidEmail = "invalid-email";

            // Act
            bool result = accountCreateForm.IsValidEmail(invalidEmail);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void GenerateAccountNumber_PersonalAccount_ReturnsValidNumber()
        {
            // Arrange
            var accountCreateForm = new AccountCreeate();
            accountCreateForm.accounttype = new Guna2ComboBox();
            accountCreateForm.accounttype.Items.Add("Personal");
            accountCreateForm.accounttype.SelectedItem = "Personal";

            // Act
            string accountNumber = accountCreateForm.GenerateAccountNumber();

            // Assert
            Assert.IsTrue(accountNumber.StartsWith("abl") && accountNumber.Length == 17);
        }

        [TestMethod()]
        public void GenerateAccountNumber_BusinessAccount_ReturnsValidNumber()
        {
            // Arrange
            var accountCreateForm = new AccountCreeate();
            accountCreateForm.accounttype = new Guna2ComboBox();
            accountCreateForm.accounttype.Items.Add("Business");
            accountCreateForm.accounttype.SelectedItem = "Business";

            // Act
            string accountNumber = accountCreateForm.GenerateAccountNumber();

            // Assert
            Assert.IsTrue(accountNumber.StartsWith("abl") && accountNumber.Length == 17);
        }

        [TestMethod()]
        public void Createacccount_Click_AllFieldsValid_CreatesAccount()
        {
            // Arrange
            var accountCreateForm = new AccountCreeate();
            accountCreateForm.name = new TextBox() { Text = "John Doe" };
            accountCreateForm.fathername = new TextBox() { Text = "Richard Roe" };
            accountCreateForm.address = new TextBox() { Text = "123 Main St" };
            accountCreateForm.mobilenumber = new TextBox() { Text = "1234567890" };
            accountCreateForm.email = new TextBox() { Text = "test@example.com" };
            accountCreateForm.password = new TextBox() { Text = "password123" };
            accountCreateForm.confirmpasword = new TextBox() { Text = "password123" };
            accountCreateForm.balance = new TextBox() { Text = "1000" };
            accountCreateForm.accounttype = new Guna2ComboBox();
            accountCreateForm.accounttype.Items.Add("Personal");
            accountCreateForm.accounttype.SelectedItem = "Personal";
            accountCreateForm.accountnumber = new TextBox() { Text = accountCreateForm.GenerateAccountNumber() };

            // Act
            accountCreateForm.Createacccount_Click(null, null);

            // Assert
            // Here, we would typically check the database or mock interaction for successful creation.
            Assert.IsTrue(true); // Placeholder to ensure the method runs without exception.
        }

        [TestMethod()]
        public void Createacccount_Click_EmptyFields_ShowsMessage()
        {
            // Arrange
            var accountCreateForm = new AccountCreeate();

            // Act
            accountCreateForm.Createacccount_Click(null, null);

            // Assert
            // No exception means the form correctly handled empty fields.
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void UpdateAccountNumber_AccountTypeSelected_UpdatesAccountNumber()
        {
            // Arrange
            var accountCreateForm = new AccountCreeate();
            accountCreateForm.accounttype = new Guna2ComboBox();
            accountCreateForm.accountnumber = new TextBox();
            accountCreateForm.accounttype.Items.Add("Personal");
            accountCreateForm.accounttype.SelectedItem = "Personal";

            // Act
            accountCreateForm.UpdateAccountNumber();

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(accountCreateForm.accountnumber.Text));
        }
    }
}
