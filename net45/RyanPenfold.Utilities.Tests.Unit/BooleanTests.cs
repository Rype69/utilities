// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Provides unit tests for the 
    /// <see cref="RyanPenfold.Utilities.Boolean" /> class.
    /// </summary>
    [TestClass]
    public class BooleanTests
    {
        /// <summary>
        /// Tests the ToByte method of 
        /// the <see cref="RyanPenfold.Utilities.Boolean" /> class.
        /// </summary>
        [TestMethod]
        public void ToByte()
        {
            // True should equal 1
            Assert.AreEqual(true.ToByte(), 1);

            // False should equal 0
            Assert.AreEqual(false.ToByte(), 0);
        }
    }
}
