// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MailMessage.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Net.Mail
{
    /// <summary>
    /// Provides operations performed on mail messages 
    /// </summary>
    public static class MailMessage
    {
        /// <summary>
        /// Initializes static members of the <see cref="MailMessage"/> class.
        /// </summary>
        static MailMessage()
        {
            throw new System.NotImplementedException("This method has not been implemented in the version of this library targeting this version of the framework.");
            // TODO: Rewrite
            /*SmtpSection = (System.Net.Configuration.SmtpSection)
                System.Configuration.ConfigurationManager.GetSection("system.net/mailSettings/smtp");*/
        }

        // <summary>
        // Gets or sets the configuration section relevant to the SMTP settings
        // </summary>
        // TODO: Rewrite
        //public static System.Net.Configuration.SmtpSection SmtpSection { get; set; }

        /// <summary>
        /// Sends a mail message
        /// </summary>
        /// <param name="from">
        /// The from address.
        /// </param>
        /// <param name="to">
        /// The to address.
        /// </param>
        /// <param name="subject">
        /// The subject.
        /// </param>
        /// <param name="body">
        /// The message body.
        /// </param>
        /// <param name="replyTo">
        /// The reply to address.
        /// </param>
        /// <returns>
        /// A boolean value indicating whether the send was successful or not.
        /// </returns>
        public static bool Send(string from, string to, string subject, string body, string replyTo)
        {
            throw new System.NotImplementedException("This method has not been implemented in the version of this library targeting this version of the framework.");
            // TODO: Rewrite
            /*var host = string.Empty;
            var mailServer = System.Configuration.ConfigurationManager.AppSettings.Get("MailServer");
            if (!string.IsNullOrEmpty(SmtpSection?.Network?.Host))
            {
                host = SmtpSection.Network.Host;
            }
            else if (!string.IsNullOrEmpty(mailServer))
            {
                host = mailServer;
            }

            return Send(from, to, subject, body, replyTo, host);*/
        }

        /// <summary>
        /// Sends a mail message
        /// </summary>
        /// <param name="from">
        /// The from address.
        /// </param>
        /// <param name="to">
        /// The to address.
        /// </param>
        /// <param name="subject">
        /// The subject.
        /// </param>
        /// <param name="body">
        /// The message body.
        /// </param>
        /// <param name="replyTo">
        /// The reply to address.
        /// </param>
        /// <param name="host">
        /// The mail server host address.
        /// </param>
        /// <returns>
        /// A boolean value indicating whether the send was successful or not.
        /// </returns>
        public static bool Send(string from, string to, string subject, string body, string replyTo, string host)
        {
            var result = true;
            try
            {
                var mailClient = new System.Net.Mail.SmtpClient(host);
                var message = new System.Net.Mail.MailMessage(from, to, subject, body);

                if (replyTo != null)
                {
                    message.Headers.Add("Reply-To", replyTo);
                }

                mailClient.Send(message);
            }
            catch (System.Exception)
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Sends a mail message.
        /// </summary>
        /// <param name="message">
        /// The message to send.
        /// </param>
        public static void Send(this System.Net.Mail.MailMessage message)
        {
            throw new System.NotImplementedException("This method has not been implemented in the version of this library targeting this version of the framework.");
            // TODO: Rewrite
            /*System.Net.Mail.SmtpClient client = null;
            if (SmtpSection?.Network != null)
            {
                client = new System.Net.Mail.SmtpClient(SmtpSection.Network.Host, SmtpSection.Network.Port);
            }

            try
            {
                client?.Send(message);
            }
            catch (System.Net.Mail.SmtpException)
            {
            }*/
        }
    }
}
