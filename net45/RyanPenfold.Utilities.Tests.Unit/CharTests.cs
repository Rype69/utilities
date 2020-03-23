// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Provides unit tests for the 
    /// <see cref="RyanPenfold.Utilities.Char" /> class.
    /// </summary>
    [TestClass]
    public class CharTests
    {
        /// <summary>
        /// Tests the IsUpperCase method of 
        /// the <see cref="RyanPenfold.Utilities.Char" /> class.
        /// </summary>
        [TestMethod]
        public void IsUpperCase()
        {
            // "C" should equal true
            Assert.IsTrue(System.Convert.ToChar("C").IsUpperCase());

            // "c" should equal false
            Assert.IsFalse(System.Convert.ToChar("c").IsUpperCase());
        }
    }
}
