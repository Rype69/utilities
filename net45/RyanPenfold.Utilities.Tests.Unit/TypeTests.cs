// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Provides unit tests for the 
    /// <see cref="RyanPenfold.Utilities.Type" /> class.
    /// </summary>
    [TestClass]
    public class TypeTests
    {
        /// <summary>
        /// Tests the GetTypeFromName method of 
        /// the <see cref="RyanPenfold.Utilities.Type" /> class.
        /// </summary>
        [TestMethod]
        public void GetTypeFromName()
        {
            // Assert
            Assert.AreEqual(typeof(Aircraft), Type.GetTypeFromName("RyanPenfold.Utilities.Tests.Unit.Aircraft"));
            Assert.AreEqual(typeof(Uri), Type.GetTypeFromName("RyanPenfold.Utilities.Uri"));
            Assert.AreNotEqual(typeof(System.Uri), Type.GetTypeFromName("RyanPenfold.Utilities.Uri"));
        }

        /// <summary>
        /// Tests the IsNotNullAndIsNotDbNull method of 
        /// the <see cref="RyanPenfold.Utilities.Type" /> class.
        /// </summary>
        [TestMethod]
        public void IsNotNullAndIsNotDbNull()
        {
            // Arrange
            const int Integer = 3;
            const string String = "IPSUM LOREM";
            var dbnull = System.DBNull.Value;

            // Act
            var result1 = Type.IsNotNullAndIsNotDbNull(Integer);
            var result2 = Type.IsNotNullAndIsNotDbNull(String);
            var result3 = Type.IsNotNullAndIsNotDbNull(dbnull);
            var result4 = Type.IsNotNullAndIsNotDbNull(null);

            // Assert
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsFalse(result3);
            Assert.IsFalse(result4);
        }

        /// <summary>
        /// Tests the GetDerivedClasses method of 
        /// the <see cref="RyanPenfold.Utilities.Type" /> class.
        /// </summary>
        [TestMethod]
        public void GetDerivedClasses()
        {
            // Act
            var results = Type.GetDerivedClasses(typeof(Vehicle));

            // Assert
            Assert.IsTrue(results.Contains(typeof(Aircraft)));
            Assert.IsTrue(results.Contains(typeof(Car)));
        }
    }
}
