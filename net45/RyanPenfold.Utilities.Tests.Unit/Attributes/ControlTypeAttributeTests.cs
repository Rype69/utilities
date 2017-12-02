// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ControlTypeAttributeTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit.Attributes
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Utilities.Attributes;

    /// <summary>
    /// Provides unit tests for the 
    /// <see cref="ControlTypeAttribute" /> class.
    /// </summary>
    [TestClass]
    public class ControlTypeAttributeTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataType" /> class
        /// and tests it to ensure it contains fields decorated with a  
        /// <see cref="ControlTypeAttribute" /> 
        /// attribute.
        /// </summary>
        [TestMethod]
        public void CreateNew()
        {
            // Create a new instance of DataType
            var dataType = new DataType();

            // Gets the property decorated with the attribute
            var property = dataType.GetType().GetProperty("Field1");

            Assert.IsNotNull(property);

            // Gets all the attributes of the property
            var attributes = property.GetCustomAttributes(false);

            Assert.IsNotNull(attributes);

            Assert.AreEqual(1, attributes.Length);

            Assert.IsNotNull(attributes[0]);

            Assert.IsInstanceOfType(attributes[0], typeof(ControlTypeAttribute));

            Assert.AreEqual("CheckBoxList", ((ControlTypeAttribute)attributes[0]).TypeName);

            Assert.AreEqual(typeof(object), ((ControlTypeAttribute)attributes[0]).DataSourceType);

            Assert.AreEqual("Text", ((ControlTypeAttribute)attributes[0]).DataTextField);

            Assert.AreEqual("Id", ((ControlTypeAttribute)attributes[0]).DataValueField);

            Assert.AreEqual(true, ((ControlTypeAttribute)attributes[0]).ReadOnly);

            Assert.AreEqual(false, ((ControlTypeAttribute)attributes[0]).AutoPostBack);
        }
    }
}
