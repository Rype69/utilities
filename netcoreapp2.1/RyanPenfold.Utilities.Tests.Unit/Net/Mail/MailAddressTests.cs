// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MailAddressTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit.Net.Mail
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Provides unit tests for the 
    /// <see cref="RyanPenfold.Utilities.Net.Mail.MailAddress" /> class.
    /// </summary>
    [TestClass]
    public class MailAddressTests
    {
        /// <summary>
        /// Tests the build methods of the
        /// <see cref="RyanPenfold.Utilities.Net.Mail.MailAddress" /> class.
        /// </summary>
        [TestMethod]
        public void Build()
        {
            // throw new System.NotImplementedException("This method has not been implemented in the version of this library targeting .NET Core 2.0.");
            // TODO: Rewrite

            /*// Set up the necessary app settings
            System.Configuration.ConfigurationManager.AppSettings.Set("DomainName_Local", "ryanpenfold");
            System.Configuration.ConfigurationManager.AppSettings.Set("DomainName_Top", "com");
            
            // Call the build method
            var address1 = Utilities.Net.Mail.MailAddress.Build("ryanpenfold");

            // Assert the correct email address was built
            Assert.AreEqual("ryanpenfold@ryanpenfold.com", address1);

            // Call the build method
            var address2 = Utilities.Net.Mail.MailAddress.Build("ryanpenfold", "ryanpenfold", "com");

            // Assert the correct email address was built
            Assert.AreEqual("ryanpenfold@ryanpenfold.com", address2);

            // Clean up configuration settings
            System.Configuration.ConfigurationManager.AppSettings["DomainName_Local"] = null;
            System.Configuration.ConfigurationManager.AppSettings["DomainName_Top"] = null;*/
        }

        /// <summary>
        /// Tests the IsValid methods of the
        /// <see cref="RyanPenfold.Utilities.Net.Mail.MailAddress" /> class.
        /// </summary>
        [TestMethod]
        public void IsValid()
        {
            const string ValidAddressString = "ryanpenfold@hotmail.com";
            Assert.IsTrue(Utilities.Net.Mail.MailAddress.IsValid(ValidAddressString));

            var validMailAddress = new System.Net.Mail.MailAddress(ValidAddressString);
            Assert.IsTrue(Utilities.Net.Mail.MailAddress.IsValid(validMailAddress));

            const string InvalidAddressString = "ipsum lorem";
            Assert.IsFalse(Utilities.Net.Mail.MailAddress.IsValid(InvalidAddressString));
        }
    }
}
