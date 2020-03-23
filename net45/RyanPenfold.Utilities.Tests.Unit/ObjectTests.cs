// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using @object = RyanPenfold.Utilities.Object;

    /// <summary>
    /// Provides unit tests for the 
    /// <see cref="Object" /> class.
    /// </summary>
    [TestClass]
    public class ObjectTests
    {
        /// <summary>
        /// Tests the Clone method of 
        /// the <see cref="Object" /> class.
        /// </summary>
        [TestMethod]
        public void Clone()
        {
            // Arrange
            var aircraft = new Aircraft { PassengerCapacity = 1, TypeName = "Boeing", Wingspan = 5.5 };

            // Act
            var cloneOfAircraft = aircraft.Clone<Aircraft>();

            // Assert
            Assert.IsNotNull(cloneOfAircraft);
            Assert.IsInstanceOfType(cloneOfAircraft, typeof(Aircraft));
            Assert.AreEqual(1, ((Aircraft)cloneOfAircraft).PassengerCapacity);
            Assert.AreEqual("Boeing", ((Aircraft)cloneOfAircraft).TypeName);
            Assert.AreEqual(5.5, ((Aircraft)cloneOfAircraft).Wingspan);
        }

        /// <summary>
        /// Tests the IsNullOrEmpty method of 
        /// the <see cref="RyanPenfold.Utilities.Object" /> class.
        /// </summary>
        [TestMethod]
        public void IsNullOrEmpty()
        {
            // Arrange
            var emptyAircraft = new Aircraft();
            var initedAircraft = new Aircraft
                {
                    PassengerCapacity = 1,
                    TypeName = "Boeing",
                    Wingspan = 5.5,
                    DateBuilt = System.DateTime.UtcNow,
                    Code = System.Convert.ToChar("c"),
                    IsActive = true
                };
            var initedDate = new System.DateTime(2011, 09, 28);

            // Assert
            Assert.IsTrue(@object.IsNullOrEmpty(emptyAircraft));
            Assert.IsFalse(@object.IsNullOrEmpty(initedAircraft));
            Assert.IsFalse(@object.IsNullOrEmpty(initedDate));
        }
    }
}
