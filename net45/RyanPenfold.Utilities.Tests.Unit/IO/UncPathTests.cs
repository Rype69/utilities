// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UncPathTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit.IO
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using RyanPenfold.Utilities.IO;

    /// <summary>
    /// Provides unit tests for the 
    /// <see cref="RyanPenfold.Utilities.IO.UncPath" /> class.
    /// </summary>
    public class UncPathTests
    {
        /// <summary>
        /// Tests the GetApplicationDirectory method of the 
        /// <see cref="RyanPenfold.Utilities.IO.UncPath" /> class.
        /// </summary>
        [TestMethod]
        public void GetApplicationDirectory()
        {
            // Make the call to  Utilities.IO.UncPath.GetApplicationDirectory()
            var result = UncPath.GetApplicationDirectory();

            // Ensure string is not empty
            Assert.AreNotEqual(string.Empty, result);

            // Ensure is valid UNC path format
            Assert.IsTrue(
                System.Text.RegularExpressions.Regex.IsMatch(
                    result,
                    "^((\\\\\\\\[a-zA-Z0-9-]+\\\\[a-zA-Z0-9`~!@#$%^&(){}//._-]+([ ]+[a-zA-Z0-9`~!@#$%^&(){}//._-]+)*)|([a-zA-Z]:))(\\\\[^ \\\\/:*?\"\"<>|]+([ ]+[^ \\\\/:*?\"\"<>|]+)*)*\\\\?$"));
        }

        /// <summary>
        /// Tests the Build method of the 
        /// <see cref="RyanPenfold.Utilities.IO.UncPath" /> class.
        /// </summary>
        [TestMethod]
        public void Build()
        {
            // Build first URL
            var result = UncPath.Build(@"C:", "Windows", @"\");
            
            // Expected result C:\Windows\
            Assert.AreEqual(@"C:\Windows\", result);
        }

        /// <summary>
        /// Tests the GetLeftmostnamespace method of the 
        /// <see cref="RyanPenfold.Utilities.IO.UncPath" /> class.
        /// </summary>
        [TestMethod]
        public void GetLeftmostnamespace()
        {
            // Test UNC path
            var result1 = UncPath.GetLeftmostnamespace("C:\\Windows\\", "\\");
            Assert.AreEqual(result1, "C:");

            // Test web address
            var result2 = UncPath.GetLeftmostnamespace("www.ryanpenfold.com", ".");
            Assert.AreEqual(result2, "www");

            // Test param
            var result3 = UncPath.GetLeftmostnamespace("param=value", "=");
            Assert.AreEqual(result3, "param");
        }

        /// <summary>
        /// Tests the GetRightmostnamespace method of the 
        /// <see cref="RyanPenfold.Utilities.IO.UncPath" /> class.
        /// </summary>
        [TestMethod]
        public void GetRightmostnamespace()
        {
            // Test UNC path
            var result1 = "C:\\Windows\\".GetRightmostnamespace("\\");
            Assert.AreEqual(result1, string.Empty);

            // Test web address
            var result2 = "www.ryanpenfold.com".GetRightmostnamespace(".");
            Assert.AreEqual(result2, "com");

            // Test param
            var result3 = "param=value".GetRightmostnamespace("=");
            Assert.AreEqual(result3, "value");
        }
    }
}
