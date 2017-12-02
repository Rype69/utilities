// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebClientTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit.Net
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Provides unit tests for the 
    /// <see cref="RyanPenfold.Utilities.Net.WebClient" /> class.
    /// </summary>
    [TestClass]
    public class WebClientTests
    {
        /// <summary>
        /// Tests the DownloadData method of the
        /// <see cref="RyanPenfold.Utilities.Net.WebClient" /> class.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void DownloadData()
        {
            // Call to the DownloadData method
            Utilities.Net.WebClient.DownloadData(string.Empty);
        }
    }
}
