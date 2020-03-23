// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumerableTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit.Collections.Generic
{
    using System.Collections.Generic;
    
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using RyanPenfold.Utilities.Collections.Generic;

    /// <summary>
    /// Provides unit tests for the 
    /// <see cref="Utilities.Collections.Generic.Enumerable" /> class.
    /// </summary>  
    [TestClass] 
    public class EnumerableTests
    {
        /// <summary>
        /// Tests the ToString method of the 
        /// <see cref="Utilities.Collections.Generic.Enumerable" /> class.
        /// </summary>
        [TestMethod]
        public new void ToString()
        {
            var enumerable = new List<Car>
            {
                new Car { Manufacturer = "Ford", Model = "Fiesta" },
                new Car { Manufacturer = "Mazda", Model = "MX-5" }
            };

            // Concatenate these strings and delimit with a comma and a space
            var commaDelimitedResult = enumerable.ToString(", ");

            // Is the desired result achieved?
            Assert.AreEqual("Ford Fiesta, Mazda MX-5", commaDelimitedResult);

            // Concatenate these strings and delimit with a semicolon and a space
            var semicolonDelimitedResult = enumerable.ToString("; ");

            // Is the desired result achieved?
            Assert.AreEqual("Ford Fiesta; Mazda MX-5", semicolonDelimitedResult);
        }
    }
}
