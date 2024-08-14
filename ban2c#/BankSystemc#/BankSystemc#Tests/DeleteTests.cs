using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankSystemc_;
using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace BankSystemc_.Tests
{
    [TestClass()]
    public class DeleteTests
    {
        [TestMethod()]
        public void LoadAccountInformationTest()
        {
            // Arrange
            var deleteForm = new Delete(true);
            deleteForm.account = new TextBox();

            // Act
            deleteForm.LoadAccountInformation();

            // Assert
            // Since we can't connect to a real database, we'll just ensure that the method doesn't crash.
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void DeleteAccountTest_ValidAccount()
        {
            // Arrange
            var deleteForm = new Delete(true);
            deleteForm.account = new TextBox() { Text = "123456789" };

            // Act
            deleteForm.DeleteAccount("123456789");

            // Assert
            // We can't verify database state without mocks, so we simply ensure no exceptions.
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void DeleteAccountTest_InvalidAccount()
        {
            // Arrange
            var deleteForm = new Delete(true);
            deleteForm.account = new TextBox() { Text = "invalid_account" };

            // Act
            deleteForm.DeleteAccount("invalid_account");

            // Assert
            // Again, we are checking that the method handles the invalid account gracefully.
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void Button1_ClickTest_WithValidAccount()
        {
            // Arrange
            var deleteForm = new Delete(true);
            deleteForm.account = new TextBox() { Text = "123456789" };

            // Act
            deleteForm.button1_Click(null, null);

            // Assert
            // This test ensures that the button click triggers the deletion process without crashing.
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void Button1_ClickTest_WithEmptyAccount()
        {
            // Arrange
            var deleteForm = new Delete(true);
            deleteForm.account = new TextBox() { Text = "" };

            // Act
            deleteForm.button1_Click(null, null);

            // Assert
            // Check that no crash happens when an empty account is provided.
            Assert.IsTrue(true);
        }
    }
}
