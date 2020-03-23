// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsPrimaryKeyAttributeTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit.Attributes
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Utilities.Attributes;

    /// <summary>
    /// Provides unit tests for the 
    /// <see cref="IsPrimaryKeyAttribute" /> class.
    /// </summary>
    [TestClass]
    public class IsPrimaryKeyAttributeTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappedDataType" /> class
        /// and tests it to ensure it contains fields decorated with a  
        /// <see cref="IsPrimaryKeyAttribute" /> 
        /// attribute.
        /// </summary>
        [TestMethod]
        public void PrimaryKeyShouldBeTrue()
        {
            // Create a new instance of MappedDataType
            var mappedDataType = new MappedDataType();

            // Gets a property decorated with the attribute
            var property = mappedDataType.GetType().GetProperty("Id");

            Assert.IsNotNull(property);

            // Gets all the attributes of the property
            var attributes = property.GetCustomAttributes(false);

            Assert.IsNotNull(attributes);

            Assert.AreEqual(1, attributes.Length);

            Assert.IsNotNull(attributes[0]);

            Assert.IsInstanceOfType(attributes[0], typeof(IsPrimaryKeyAttribute));

            Assert.AreEqual(true, ((IsPrimaryKeyAttribute)attributes[0]).Value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MappedDataType" /> class
        /// and tests it to ensure it contains fields decorated with a  
        /// <see cref="RyanPenfold.Utilities.Attributes.IsPrimaryKeyAttribute" /> 
        /// attribute.
        /// </summary>
        [TestMethod]
        public void PrimaryKeyShouldNotBeTrue()
        {
            // Create a new instance of MappedDataType
            var mappedDataType = new MappedDataType();

            // Gets a property decorated with the attribute
            var property = mappedDataType.GetType().GetProperty("Text");

            Assert.IsNotNull(property);

            // Gets all the attributes of the property
            var attributes = property.GetCustomAttributes(false);

            Assert.IsNotNull(attributes);

            Assert.AreEqual(1, attributes.Length);

            Assert.IsNotNull(attributes[0]);

            Assert.IsInstanceOfType(attributes[0], typeof(IsPrimaryKeyAttribute));

            Assert.AreEqual(false, ((IsPrimaryKeyAttribute)attributes[0]).Value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataType" /> class
        /// and tests it to ensure it contains fields decorated with a  
        /// <see cref="RyanPenfold.Utilities.Attributes.IsPrimaryKeyAttribute" /> 
        /// attribute.
        /// </summary>
        [TestMethod]
        public void PrimaryKeyAttributeShouldNotBePresent()
        {
            // Create a new instance of MappedDataType
            var mappedDataType = new MappedDataType();

            // Gets a property decorated with the attribute
            var property = mappedDataType.GetType().GetProperty("Description");

            Assert.IsNotNull(property);

            // Gets all the attributes of the property
            var attributes = property.GetCustomAttributes(false);

            foreach (var attribute in attributes)
            {
                if (attribute != null)
                {
                    Assert.IsNotInstanceOfType(attributes[0], typeof(IsPrimaryKeyAttribute));
                }
            }
        }
    }
}
