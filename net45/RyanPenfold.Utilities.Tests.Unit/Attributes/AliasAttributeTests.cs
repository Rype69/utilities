// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AliasAttributeTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit.Attributes
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Utilities.Attributes;

    /// <summary>
    /// Provides unit tests for the 
    /// <see cref="AliasAttribute" /> class.
    /// </summary>
    [TestClass]
    public class AliasAttributeTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AliasedType" /> class
        /// and tests it to ensure it contains a 
        /// <see cref="AliasAttribute" /> 
        /// attribute.
        /// </summary>
        [TestMethod]
        public void CreateNew()
        {
            // Create a new instance of AliasedType
            var aliasedType = new AliasedType();

            // Gets all the attributes of the type
            var attributes = aliasedType.GetType().GetCustomAttributes(false);

            Assert.IsNotNull(attributes);

            Assert.AreEqual(1, attributes.Length);

            Assert.IsNotNull(attributes[0]);

            Assert.IsInstanceOfType(attributes[0], typeof(AliasAttribute));

            Assert.AreEqual("AliasedTestType", ((AliasAttribute)attributes[0]).Value);
        }
    }
}
