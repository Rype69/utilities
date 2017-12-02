// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RandomTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Provides unit tests for the <see cref="Random"/> class.
    /// </summary>
    [TestClass]
    public class RandomTests
    {
        /// <summary>
        /// Tests the <see cref="Random.NextDateTime(bool)"/> method.
        /// </summary>
        [TestMethod]
        public void NextDateTime_NoParametersSpecified_ReturnsRandomDate()
        {
            // Act
            var result = Random.NextDateTime();

            // Assert
            Assert.IsInstanceOfType(result, typeof(System.DateTime));
        }

        /// <summary>
        /// Tests the <see cref="Random.NextDateTime(System.DateTime, bool)"/> method.
        /// </summary>
        [TestMethod]
        public void NextDateTime_MaximumValueSpecified_ResultIsBeforeMaximumDate()
        {
            // Arrange
            var maximumDate = new System.DateTime(2015, 10, 23, 0, 0, 0);

            // Act
            var result = Random.NextDateTime(maximumDate);

            // Assert
            Assert.IsInstanceOfType(result, typeof(System.DateTime));
            Assert.IsTrue(result <= maximumDate);
        }

        /// <summary>
        /// Tests the <see cref="Random.NextDateTime(System.DateTime, System.DateTime, bool)"/> method.
        /// </summary>
        [TestMethod]
        public void NextDateTime_MaximumAndMinimumValuesSpecified_ResultIsBetweenParameters()
        {
            // Arrange
            var minimumDate = new System.DateTime(1753, 1, 1, 0, 0, 0);
            var maximumDate = new System.DateTime(2015, 10, 21, 0, 0, 0);

            // Act
            var result = Random.NextDateTime(minimumDate, maximumDate);

            // Assert
            Assert.IsInstanceOfType(result, typeof(System.DateTime));
            Assert.IsTrue(result >= minimumDate);
            Assert.IsTrue(result <= maximumDate);
        }
    }
}
