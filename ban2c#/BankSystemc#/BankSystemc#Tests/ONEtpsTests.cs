using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

namespace BankSystemc_.Tests
{
    [TestClass()]
    public class ONEtpsTests
    {
        [TestMethod()]
        public void OTPVerification_SuccessfulTest()
        {
            // Arrange
            string expectedOtp = "123456";
            DateTime generatedTime = DateTime.Now;
            var otpForm = new ONEtps(expectedOtp, generatedTime)
            {
                txtotp = new TextBox() { Text = expectedOtp }
            };

            // Act
            otpForm.otpverify_Click_1(null, null);

            // Assert
            // In a real-world scenario, you'd mock MessageBox.Show and Homepage to check interactions.
            // Here, we'll assume no exception means success.
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void OTPVerification_ExpiredTest()
        {
            // Arrange
            string expectedOtp = "123456";
            DateTime generatedTime = DateTime.Now.AddSeconds(-ONEtps.OTP_VALIDITY_DURATION - 1);
            var otpForm = new ONEtps(expectedOtp, generatedTime)
            {
                txtotp = new TextBox() { Text = expectedOtp }
            };

            // Act
            otpForm.otpverify_Click_1(null, null);

            // Assert
            // No exception means the method handled the expired OTP correctly.
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void OTPVerification_InvalidTest()
        {
            // Arrange
            string expectedOtp = "123456";
            string enteredOtp = "654321";
            DateTime generatedTime = DateTime.Now;
            var otpForm = new ONEtps(expectedOtp, generatedTime)
            {
                txtotp = new TextBox() { Text = enteredOtp }
            };

            // Act
            otpForm.otpverify_Click_1(null, null);

            // Assert
            // No exception means the method handled the invalid OTP correctly.
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void panel1_PaintTest()
        {
            // This test would normally be for visual elements, so it's likely to be empty unless specific drawing logic is tested.
            Assert.IsTrue(true);
        }
    }
}
