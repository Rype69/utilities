// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArrayTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Provides unit tests for the 
    /// <see cref="RyanPenfold.Utilities.Array" /> class.
    /// </summary>
    [TestClass]
    public class ArrayTests
    {
        /// <summary>
        /// Tests the GetLowestEmptyIDmethod of 
        /// the <see cref="RyanPenfold.Utilities.Array" /> class.
        /// </summary>
        [TestMethod]
        public void GetLowestEmptyId()
        {
            // Arrange
            string[] array1 = { "HELLO", null, " ", null, "WORLD!" };
            string[] array2 = { "HELLO", string.Empty, " ", null, "WORLD!" };

            // Act
            var result1 = array1.GetLowestEmptyId();
            var result2 = array2.GetLowestEmptyId();

            // Assert
            Assert.AreEqual(result1, 1);
            Assert.AreEqual(result2, 3);
        }

        /// <summary>
        /// Tests the Concatenate method of 
        /// the <see cref="RyanPenfold.Utilities.Array" /> class.
        /// </summary>
        [TestMethod]
        public void Concatenate()
        {
            // Arrange
            string[] strings = { "HELLO", " ", "WORLD!" };

            // Act
            var result1 = strings.Concatenate(string.Empty);
            var result2 = strings.Concatenate(",");

            // Assert
            Assert.AreEqual(result1, "HELLO WORLD!");
            Assert.AreEqual(result2, "HELLO, ,WORLD!");
        }
    }
}
