// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Network.cs" company="Inspire IT Ltd">
//   Copyright © Inspire IT Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Net
{
    /// <summary>
    /// Provides utility functionality relevant to networks 
    /// </summary>
    public class Network
    {
        /// <summary>
        /// Initializes static members of the <see cref="Network"/> class.
        /// </summary>
        static Network()
        {
            LocalIpv4Address = "127.0.0.1";
        }

        /// <summary>
        /// Gets or sets the IP (version 4) address.
        /// </summary>
        public static string LocalIpv4Address { get; set; }

        /*
        /// <summary>
        /// Determines whether the host device is connected to a network
        /// </summary>
        /// <returns>
        /// A boolean value indicating whether the host device is 
        /// connected to a network or not.
        /// </returns>
        public static bool IsConnected()
        {
            bool result;
            try
            {
                // Returns the Device Name
                var hostName = System.Net.Dns.GetHostName();
                var thisHost = System.Net.Dns.GetHostEntry(hostName);
                var thisIpAddr = thisHost.AddressList[0].ToString();
                result = thisIpAddr != System.Net.IPAddress.Parse(LocalIpv4Address).ToString();
            }
            catch (System.Exception)
            {
                result = false;
            }

            return result;
        }
        */
    }
}
