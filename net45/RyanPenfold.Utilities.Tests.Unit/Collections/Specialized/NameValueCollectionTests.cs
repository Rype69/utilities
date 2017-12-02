// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NameValueCollectionTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit.Collections.Specialized
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using RyanPenfold.Utilities.Collections.Specialized;

    /// <summary>
    /// Provides tests for the <see cref="RyanPenfold.Utilities.Collections.Specialized.NameValueCollection" /> class.
    /// </summary>
    [TestClass]
    public class NameValueCollectionTests
    {
        /// <summary>
        /// Tests the copy extension method of the <see cref="RyanPenfold.Utilities.Collections.Specialized.NameValueCollection" /> class.
        /// </summary>
        [TestMethod]
        public void Copy()
        {
            // Arrange
            var collection = new System.Collections.Specialized.NameValueCollection
                {
                    { "A", "1" },
                    { "B", "2" },
                    { "C", "3" }
                };

            // Act
            var copiedCollection = collection.Copy();

            // Assert
            Assert.AreEqual(3, copiedCollection.Count);
            Assert.AreEqual("1", copiedCollection[0]);
            Assert.AreEqual("2", copiedCollection[1]);
            Assert.AreEqual("3", copiedCollection[2]);
            Assert.AreEqual("A", copiedCollection.Keys[0]);
            Assert.AreEqual("B", copiedCollection.Keys[1]);
            Assert.AreEqual("C", copiedCollection.Keys[2]);
        }
    }
}