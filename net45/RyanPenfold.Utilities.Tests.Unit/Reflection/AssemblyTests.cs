// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RyanPenfold.Utilities.Tests.Unit.Reflection
{
    /// <summary>
    /// Provides unit tests for the <see cref="RyanPenfold.Utilities.Reflection.Assembly"/> class.
    /// </summary>
    [TestClass]
    public class AssemblyTests
    {
        /// <summary>
        /// Tests the <see cref="RyanPenfold.Utilities.Reflection.Assembly.GetCallingAssembly"/> method
        /// </summary>
        [TestMethod]
        public void GetCallingAssembly_NoParameters_ResultIsMscorlib()
        {
            // Act & Arrange
            var result = Utilities.Reflection.Assembly.GetCallingAssembly();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.GetName());
            Assert.IsNotNull(result.GetName().Name);
            Assert.AreEqual("mscorlib", result.GetName().Name);
        }
    }
}
