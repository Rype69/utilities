// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NetworkTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit.Net
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Provides unit tests for the 
    /// <see cref="RyanPenfold.Utilities.Net.Network" /> class.
    /// </summary>
    [TestClass]
    public class NetworkTests
    {
        /// <summary>
        /// Tests the IsConnected method of the
        /// <see cref="RyanPenfold.Utilities.Net.Network" /> class.
        /// </summary>
        [TestMethod]
        public void IsConnected()
        {
            // Find out if the network is connected
            bool expectedResult;
            try
            {
                // Returns the Device Name
                var hostName = System.Net.Dns.GetHostName();
                var thisHost = System.Net.Dns.GetHostEntry(hostName);
                var thisIpAddr = thisHost.AddressList[0].ToString();
                expectedResult = thisIpAddr != System.Net.IPAddress.Parse("127.0.0.1").ToString();
            }
            catch (System.Exception)
            {
                expectedResult = false;
            }

            // Assert the expected result meets the actual result
            Assert.AreEqual(expectedResult, Utilities.Net.Network.IsConnected());

            // Get the current local IPV4 address contained in the Network class
            var originalLocalIpv4Address = Utilities.Net.Network.LocalIpv4Address;

            // Set the LocalIpv4Address of the Network class to an invalid address
            Utilities.Net.Network.LocalIpv4Address = "IPSUMLOREMYADA";

            // Assert the network is reported as not connected
            Assert.IsFalse(Utilities.Net.Network.IsConnected());

            // Reset the LocalIpv4Address property of the Network class
            Utilities.Net.Network.LocalIpv4Address = originalLocalIpv4Address;        
        }
    }
}
