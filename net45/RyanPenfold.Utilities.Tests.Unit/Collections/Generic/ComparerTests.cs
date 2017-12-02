// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ComparerTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit.Collections.Generic
{    
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Provides unit tests for the 
    /// <see cref="Utilities.Collections.Generic.Enumerable" /> class.
    /// </summary>  
    [TestClass] 
    public class ComparerTests
    {
        /// <summary>
        /// Tests the constructor of the 
        /// <see cref="Utilities.Collections.Generic.Comparer{T}" /> class.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.ApplicationException))]
        public void CreateNewMissingProperty()
        {
            // Act
            // ReSharper disable ObjectCreationAsStatement
            new Utilities.Collections.Generic.Comparer<Person>("Taillength");
            // ReSharper restore ObjectCreationAsStatement
        }

        /// <summary>
        /// Tests the constructor of the 
        /// <see cref="Utilities.Collections.Generic.Comparer{T}" /> class.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.ApplicationException))]
        public void CreateNewMissingDirection()
        {
            // Act
            // ReSharper disable ObjectCreationAsStatement
            new Utilities.Collections.Generic.Comparer<Person>("Surname", string.Empty);
            // ReSharper restore ObjectCreationAsStatement
        }

        /// <summary>
        /// Tests the Compare method of the 
        /// <see cref="Utilities.Collections.Generic.Comparer{T}" /> class.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.ApplicationException))]
        public void Compare()
        {
            // Arrange
            var comparer = new Utilities.Collections.Generic.Comparer<Person>("Age");

            // Act
            var result = comparer.Compare(new Person(), new Person());

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
