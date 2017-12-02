// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SmtpClient.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Net.Mail
{
    /// <summary>
    /// Provides operations performed on smtp clients 
    /// </summary>
    public static class SmtpClient
    {
        /// <summary>
        /// Determines whether or not the application settings  
        /// denote that the SMTP client is enabled.
        /// </summary>
        /// <param name="client">
        /// The smtp client.
        /// </param>
        /// <returns>
        /// A boolean value indicating whether or not the application settings  
        /// denote that the SMTP client is enabled.
        /// </returns>
        public static bool Enabled(this System.Net.Mail.SmtpClient client)
        {
            bool result;
            bool.TryParse(System.Configuration.ConfigurationManager.AppSettings.Get("Enableemail"), out result);
            return result;
        }
    }
}
