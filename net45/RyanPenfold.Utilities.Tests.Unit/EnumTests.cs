// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Provides unit tests for the 
    /// <see cref="RyanPenfold.Utilities.Enum" /> class.
    /// </summary>
    [TestClass]
    public class EnumTests
    {
        /// <summary>
        /// Tests a method of 
        /// the <see cref="RyanPenfold.Utilities.Enum" /> class.
        /// </summary>
        [TestMethod]
        public void ToEnum()
        {
            // Arrange
            const string Saturday = "Saturday";

            // Act
            var result = Saturday.ToEnum<System.DayOfWeek>();

            // Assert
            Assert.AreEqual(System.DayOfWeek.Saturday, result);
        }

        /// <summary>
        /// Tests a method of 
        /// the <see cref="RyanPenfold.Utilities.Enum" /> class.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void ToEnumWithException()
        {
            // Act
            "IpsumDay".ToEnum<System.DayOfWeek>();
        }
    }
}
