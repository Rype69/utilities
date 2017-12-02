// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UriTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using RyanPenfold.Utilities.IO;

    /// <summary>
    /// Provides unit tests for the 
    /// <see cref="RyanPenfold.Utilities.Uri" /> class.
    /// </summary>
    [TestClass]
    public class UriTests
    {
        /// <summary>
        /// Tests the GetLeftmostnamespace method of the 
        /// <see cref="RyanPenfold.Utilities.Uri" /> class.
        /// </summary>
        [TestMethod]
        public void GetLeftmostnamespace()
        {
            // The Uri string
            const string Uri = "www.ryanpenfold.com/blog";

            // attempts to get the leftmost namespace of the Uri string
            var result = Uri.GetLeftmostnamespace("/");

            // Test to see if the expected result was attained
            Assert.AreEqual("www.ryanpenfold.com", result);
            Assert.AreEqual(string.Empty, Uri.GetLeftmostnamespace(string.Empty));
        }

        /// <summary>
        /// Tests the GetRightmostnamespace method of the 
        /// <see cref="RyanPenfold.Utilities.Uri" /> class.
        /// </summary>
        [TestMethod]
        public void GetRightmostnamespace()
        {
            // The Uri string
            const string Uri = "www.ryanpenfold.com/blog";

            // attempts to get the leftmost namespace of the Uri string
            var result = Uri.GetRightmostnamespace("/");

            // Test to see if the expected result was attained
            Assert.AreEqual("blog", result);
        }

        /// <summary>
        /// Tests the ToUriStringNoParameters method of the 
        /// <see cref="RyanPenfold.Utilities.Uri" /> class.
        /// </summary>
        [TestMethod]
        public void ToUriStringNoParameters()
        {
            // The path to the file
            const string Uri = "http://www.ryanpenfold.com/default.aspx?id=5&name=Ryan&page=10&colour=green";

            // attempts to get the leftmost namespace of the Uri string
            var result = Utilities.Uri.ToUriStringNoParameters(Uri);

            // Test to see if the expected result was attained
            Assert.AreEqual("http://www.ryanpenfold.com/default.aspx", result);
        }
    }
}
