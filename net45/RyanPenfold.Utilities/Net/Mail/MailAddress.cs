// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MailAddress.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Net.Mail
{
    /// <summary>
    /// Provides operations performed on mail addresses 
    /// </summary>
    public abstract class MailAddress
    {
        public static string RegularExpressionPattern => "^[0-9a-zA-Z]+([0-9a-zA-Z]*[-._+])*[0-9a-zA-Z]+@[0-9a-zA-Z]+([-.][0-9a-zA-Z]+)*([0-9a-zA-Z]*[.])[a-zA-Z]{2,6}$";

        // "^[A-Za-z0-9](([_\\.\\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\\.\\-]?[a-zA-Z0-9]+)*)\\.([A-Za-z]{2,})$";

        /// <summary>
        /// Builds a mail address string 
        /// </summary>
        /// <param name="localName">
        /// The local name.
        /// </param>
        /// <returns>
        /// A mail address string
        /// </returns>
        public static string Build(string localName)
        {
            return Build(localName, System.Configuration.ConfigurationManager.AppSettings.Get("DomainName_Local"), System.Configuration.ConfigurationManager.AppSettings.Get("DomainName_Top"));
        }

        /// <summary>
        /// Builds a mail address string
        /// </summary>
        /// <param name="localName">
        /// The local name.
        /// </param>
        /// <param name="domainNameLocal">
        /// The domain name local.
        /// </param>
        /// <param name="domainNameTop">
        /// The domain name top.
        /// </param>
        /// <returns>
        /// A mail address string
        /// </returns>
        public static string Build(string localName, string domainNameLocal, string domainNameTop)
        {
            var builder = new System.Text.StringBuilder(localName);
            builder.Append("@");
            builder.Append(domainNameLocal);
            builder.Append(".");
            builder.Append(domainNameTop);
            return builder.ToString();
        }

        /// <summary>
        /// Determines whether a given mail address is in valid format.
        /// </summary>
        /// <param name="address">
        /// The mail address.
        /// </param>
        /// <returns>
        /// A boolean value indicating whether the given mail address is in valid format.
        /// </returns>
        public static bool IsValid(System.Net.Mail.MailAddress address)
        {
            return !string.IsNullOrEmpty(address?.Address) && IsValid(address.Address);
        }

        /// <summary>
        /// Determines whether a given mail address string is in valid format.
        /// </summary>
        /// <param name="address">
        /// The mail address string.
        /// </param>
        /// <returns>
        /// A boolean value indicating whether the given mail address string is in valid format.
        /// </returns>
        public static bool IsValid(string address)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(address, RegularExpressionPattern);
                // || System.Text.RegularExpressions.Regex.IsMatch(address, "^((?>[a-zA-Z\\d!#$%&//*+\\-/=?^_`{|}~]+\\x20*|\"((?=[\\x01-\\x7f])[^\"\\\\]|\\\\[\\x01-\\x7f])*\"\\x20*)*(?<angle><))?((?!\\.)(?>\\.?[a-zA-Z\\d!#$%&//*+\\-/=?^_`{|}~]+)+|\"((?=[\\x01-\\x7f])[^\"\\\\]|\\\\[\\x01-\\x7f])*\")@(((?!-)[a-zA-Z\\d\\-]+(?<!-)\\.)+[a-zA-Z]{2,}|\\[(((?(?<!\\[)\\.)(25[0-5]|2[0-4]\\d|[01]?\\d?\\d)){4}|[a-zA-Z\\d\\-]*[a-zA-Z\\d]:((?=[\\x01-\\x7f])[^\\\\\\[\\]]|\\\\[\\x01-\\x7f])+)\\])(?(angle)>)$");
        }
    }
}
