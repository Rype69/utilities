// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MailMessageTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit.Net.Mail
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using RyanPenfold.Utilities.Net.Mail;

    /// <summary>
    /// Provides unit tests for the 
    /// <see cref="RyanPenfold.Utilities.Net.Mail.MailMessage" /> class.
    /// </summary>
    [TestClass]
    public class MailMessageTests
    {
        /// <summary>
        /// Tests the Send methods of the
        /// <see cref="RyanPenfold.Utilities.Net.Mail.MailMessage" /> class.
        /// </summary>
        [TestMethod]
        public void Send()
        {
            // Act
            // Call the "Send" method
            var result = MailMessage.Send(
                "sender@test.com",
                "recipient@test.com",
                "Subject",
                "Body",
                "reply@test.com");

            // False is expected
            Assert.IsFalse(result);

            // Set the config section to null
            MailMessage.SmtpSection = null;
            System.Configuration.ConfigurationManager.AppSettings.Set("MailServer", "localhost");

            // Call the "Send" method
            result = MailMessage.Send(
                "sender@test.com",
                "recipient@test.com",
                "Subject",
                "Body",
                "reply@test.com");

            // False is expected
            Assert.IsFalse(result);

            // Call the "Send" method again, this time specifying the host
            result = MailMessage.Send(
                "sender@test.com",
                "recipient@test.com",
                "Subject",
                "Body",
                "reply@test.com",
                string.Empty);

            // False is expected
            Assert.IsFalse(result);

            // Reset the SmtpSection
            MailMessage.SmtpSection = (System.Net.Configuration.SmtpSection)
                System.Configuration.ConfigurationManager.GetSection("system.net/mailSettings/smtp");

            var message = new System.Net.Mail.MailMessage("from@test.com", "to@test.com");
            message.Send();
        }
    }
}
