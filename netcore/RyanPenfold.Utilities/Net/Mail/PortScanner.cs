/*
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PortScanner.cs" company="Inspire IT Ltd">
//   Copyright © Inspire IT Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Net.Mail
{
    /// <summary>
    /// Scans a network address for open ports
    /// </summary>
    public class PortScanner
    {
        /// <summary>
        /// Scans a network address for open ports.
        /// </summary>
        /// <param name="host">
        /// The host address.
        /// </param>
        /// <param name="port">
        /// The port ID.
        /// </param>
        /// <param name="milliSeconds">
        /// The amount of milliseconds elapsed.
        /// </param>
        /// <returns>
        /// A boolean value indicating whether the scan was successful or not.
        /// </returns>
        public static bool Scan(string host, int port, out long milliSeconds)
        {
            var result = true;
            var watch = new System.Diagnostics.Stopwatch();
            var tcpClient = new System.Net.Sockets.TcpClient();
            try
            {
                watch.Start();
                tcpClient.Connect(host, port);
            }
            catch (System.Net.Sockets.SocketException)
            {
                result = false;
            }
            finally
            {
                watch.Stop();
            }

            milliSeconds = watch.ElapsedMilliseconds;
            return result;
        }
    }
}
*/