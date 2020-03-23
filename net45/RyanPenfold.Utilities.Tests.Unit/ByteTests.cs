// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ByteTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Provides unit tests for the 
    /// <see cref="RyanPenfold.Utilities.Byte" /> class.
    /// </summary>
    [TestClass]
    public class ByteTests
    {
        /// <summary>
        /// Tests the ToBoolean method of 
        /// the <see cref="RyanPenfold.Utilities.Byte" /> class.
        /// </summary>
        [TestMethod]
        public void ToBoolean()
        {
            // 1 should equal true
            Assert.AreEqual(((byte)1).ToBoolean(), true);

            // 0 should equal false
            Assert.AreEqual(((byte)2).ToBoolean(), false);
        }
    }
}
