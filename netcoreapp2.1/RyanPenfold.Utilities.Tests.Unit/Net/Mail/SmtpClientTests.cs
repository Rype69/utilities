// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SmtpClientTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit.Net.Mail
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using RyanPenfold.Utilities.Net.Mail;

    /// <summary>
    /// Provides unit tests for the 
    /// <see cref="RyanPenfold.Utilities.Net.Mail.SmtpClient" /> class.
    /// </summary>
    [TestClass]
    public class SmtpClientTests
    {
        /// <summary>
        /// Tests the Enabled method of the
        /// <see cref="RyanPenfold.Utilities.Net.Mail.SmtpClient" /> class.
        /// </summary>
        [TestMethod]
        public void Enabled()
        {
            throw new System.NotImplementedException("This method has not been implemented in the version of this library targeting .NET Core 2.0.");
            // TODO: Rewrite
            
            /*// Create a new SMTP server (evee though it//s set to client)
            var server = new System.Net.Mail.SmtpClient();
            
            // Server should be disabled by default
            Assert.IsFalse(server.Enabled());

            // Set Enableemail to false in the configuration
            System.Configuration.ConfigurationManager.AppSettings.Set("Enableemail", "false");

            // Server should be disabled as per the configuration
            Assert.IsFalse(server.Enabled());

            // Set the Enableemail to true in the configuration
            System.Configuration.ConfigurationManager.AppSettings.Set("Enableemail", "true");

            // Server should now be enabled
            Assert.IsTrue(server.Enabled());

            // Clean up configuration settings
            System.Configuration.ConfigurationManager.AppSettings["Enableemail"] = null;

            // Server should now be disabled
            Assert.IsFalse(server.Enabled());*/
        }
    }
}
