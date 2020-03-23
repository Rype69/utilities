// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MathTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Provides unit tests for the 
    /// <see cref="RyanPenfold.Utilities.Math" /> class.
    /// </summary>
    [TestClass]
    public class MathTests
    {
        /// <summary>
        /// Tests the GetOrdinal method of 
        /// the <see cref="RyanPenfold.Utilities.Math" /> class.
        /// </summary>
        [TestMethod]
        public void GetOrdinal()
        {
            // Assert
            Assert.AreEqual("st", 1.GetOrdinal());
            Assert.AreEqual("nd", 2.GetOrdinal());
            Assert.AreEqual("rd", 3.GetOrdinal());
            Assert.AreEqual("th", 4.GetOrdinal());
            Assert.AreEqual("th", 5.GetOrdinal());
            Assert.AreEqual("th", 6.GetOrdinal());
            Assert.AreEqual("th", 7.GetOrdinal());
            Assert.AreEqual("th", 10.GetOrdinal());
            Assert.AreEqual("rd", 23.GetOrdinal());
            Assert.AreEqual("nd", 32.GetOrdinal());
            Assert.AreEqual("th", 44.GetOrdinal());
            Assert.AreEqual("th", 55.GetOrdinal());
            Assert.AreEqual("th", 67.GetOrdinal());
            Assert.AreEqual("th", 77.GetOrdinal());
        }

        /// <summary>
        /// Tests the GetPercentageDifference method of 
        /// the <see cref="RyanPenfold.Utilities.Math" /> class.
        /// </summary>
        [TestMethod]
        public void GetPercentageDifference()
        {
            // Arrange
            const double OneHundred = 100.0;
            const double Fifty = 50.0;

            // Act
            var result1 = OneHundred.GetPercentageDifference(44.4);
            var result2 = OneHundred.GetPercentageDifference(55.5);
            var result3 = OneHundred.GetPercentageDifference(50.0);
            var result4 = Fifty.GetPercentageDifference(50.0);

            // Assert
            Assert.AreEqual(44.4, result1);
            Assert.AreEqual(55.500000000000007, result2);
            Assert.AreEqual(50.0, result3);
            Assert.AreEqual(100.0, result4);
        }

        /// <summary>
        /// Tests the Round method of 
        /// the <see cref="RyanPenfold.Utilities.Math" /> class.
        /// </summary>
        [TestMethod]
        public void Round()
        {
            // Assert
            Assert.AreEqual(55.5, 55.500000000000007.Round(3));
            Assert.AreEqual(55.50, 55.500000000000007.Round(4));
            Assert.AreEqual(55.50000, 55.500000000000007.Round(7));
            Assert.AreEqual(55.500000000000007, 55.500000000000007.Round(17));
        }

        /// <summary>
        /// Tests the RoundToSignificance method of 
        /// the <see cref="RyanPenfold.Utilities.Math" /> class.
        /// </summary>
        [TestMethod]
        public void RoundToSignificance()
        {
            // Assert
            Assert.AreEqual(54, 55.500000000000007.RoundToSignificance(3));
            Assert.AreEqual(52, 55.500000000000007.RoundToSignificance(4));
            Assert.AreEqual(49, 55.500000000000007.RoundToSignificance(7));
            Assert.AreEqual(51, 55.500000000000007.RoundToSignificance(17));
        }
    }
}
