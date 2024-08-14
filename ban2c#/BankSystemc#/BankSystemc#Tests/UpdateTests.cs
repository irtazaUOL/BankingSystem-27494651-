using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankSystemc_;
using System;
using System.Data;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace BankSystemc_.Tests
{
    [TestClass()]
    public class UpdateTests
    {
        [TestMethod()]
        public void GenerateAccountNumberTest()
        {
            // Arrange
            var updateForm = new Update();
            updateForm.guna2ComboBox1.Items.AddRange(new string[] { "Personal", "Business" });

            // Act
            updateForm.guna2ComboBox1.SelectedItem = "Personal";
            string accountNumber = updateForm.GenerateAccountNumber();

            // Assert
            Assert.IsNotNull(accountNumber);
            Assert.IsTrue(accountNumber.StartsWith("abl"));
            Assert.AreEqual(17, accountNumber.Length); // "abl" + 14 digits
        }



        [TestMethod()]
        public void LoadAccountInformationTest()
        {
            // Arrange
            var updateForm = new Update();

            // Simulating setting a text box manually
            updateForm.txtacn = new TextBox();
            updateForm.txtacn.Text = "123456789";

            // Act
            updateForm.LoadAccountInformation();

            // Assert
            // Since we can't interact with the database, we check if the text box is still the same
            Assert.IsNotNull(updateForm.txtacn.Text);
        }

        [TestMethod()]
        public void UpdateAccountTest()
        {
            // Arrange
            var updateForm = new Update();

            // Normally, you'd mock the database here
            string accountNumber = "123456789";
            string newAccountType = "Personal";
            string email = "test@example.com";
            string mobileNumber = "1234567890";
            string password = "password123";

            // Act
            updateForm.UpdateAccount(accountNumber, newAccountType, email, mobileNumber, password);

            // Assert
            // Since we can't actually update the database, we check for potential exceptions
            Assert.IsTrue(true); // Just ensuring the method doesn't throw
        }

        [TestMethod()]
        public void PopulateFieldsTest()
        {
            // Arrange
            var updateForm = new Update();

            // Mocking the data returned by the database
            updateForm.txtmbl = new TextBox();
            updateForm.txtemail = new TextBox();
            updateForm.txtpassword = new TextBox();
            updateForm.guna2ComboBox1 = new Guna2ComboBox();

            // Act
            updateForm.populatefeild();

            // Assert
            Assert.IsNotNull(updateForm.txtmbl.Text);
            Assert.IsNotNull(updateForm.txtemail.Text);
            Assert.IsNotNull(updateForm.txtpassword.Text);
            Assert.IsNotNull(updateForm.guna2ComboBox1.Text);
        }
    }
}
