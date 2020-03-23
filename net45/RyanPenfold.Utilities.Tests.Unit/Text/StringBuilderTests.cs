// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArrayTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit.Text
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RyanPenfold.Utilities.Text;

    /// <summary>
    /// Provides unit tests for the <see cref="StringBuilder" /> class.
    /// </summary>
    [TestClass]
    public class StringBuilderTests
    {
        /// <summary>
        /// Tests the <see cref="StringBuilder.AppendWithDelimiter" /> method.
        /// </summary>
        [ExpectedException(typeof(System.ArgumentNullException)), TestMethod]
        public void AppendWithDelimiter_NullStringBuilder_ThrowsException()
        {
            // Arrange
            System.Text.StringBuilder builder = null;

            // Act
            builder.AppendWithDelimiter("appendage", ",");
        }

        /// <summary>
        /// Tests the <see cref="StringBuilder.AppendWithDelimiter" /> method.
        /// </summary>
        [TestMethod]
        public void AppendWithDelimiter_ParametersSpecified_AppendsWithDelimiter()
        {
            // Arrange
            var builder = new System.Text.StringBuilder("HELLO ");

            // Act
            builder.AppendWithDelimiter(" WORLD!", "+");

            // Assert
            Assert.AreEqual("HELLO + WORLD!", builder.ToString());
        }

        /// <summary>
        /// Tests the <see cref="StringBuilder.Trim" /> method.
        /// </summary>
        [ExpectedException(typeof(System.ArgumentNullException)), TestMethod]
        public void Trim_NullStringBuilder_ThrowsException()
        {
            // Arrange
            System.Text.StringBuilder builder = null;

            // Act
            builder.Trim();
        }

        /// <summary>
        /// Tests the <see cref="StringBuilder.Trim" /> method.
        /// </summary>
        [TestMethod]
        public void Trim_StringContainsStartingSpace_TrimsString()
        {
            // Arrange
            var builder = new System.Text.StringBuilder(" HELLO WORLD");

            // Act
            builder.Trim();

            // Assert
            Assert.AreEqual("HELLO WORLD", builder.ToString());
        }

        /// <summary>
        /// Tests the <see cref="StringBuilder.Trim" /> method.
        /// </summary>
        [TestMethod]
        public void Trim_StringContainsTrailingSpace_TrimsString()
        {
            // Arrange
            var builder = new System.Text.StringBuilder("HELLO WORLD ");

            // Act
            builder.Trim();

            // Assert
            Assert.AreEqual("HELLO WORLD", builder.ToString());
        }

        /// <summary>
        /// Tests the <see cref="StringBuilder.Trim" /> method.
        /// </summary>
        [TestMethod]
        public void Trim_StringContainsStartingAndTrailingSpaces_TrimsString()
        {
            // Arrange
            var builder = new System.Text.StringBuilder(" HELLO WORLD ");

            // Act
            builder.Trim();

            // Assert
            Assert.AreEqual("HELLO WORLD", builder.ToString());
        }

        /// <summary>
        /// Tests the <see cref="StringBuilder.TrimEnd" /> method.
        /// </summary>
        [ExpectedException(typeof(System.ArgumentNullException)), TestMethod]
        public void TrimEnd_NullStringBuilder_ThrowsException()
        {
            // Arrange
            System.Text.StringBuilder builder = null;

            // Act
            builder.TrimEnd();
        }

        /// <summary>
        /// Tests the <see cref="StringBuilder.TrimEnd" /> method.
        /// </summary>
        [TestMethod]
        public void TrimEnd_StringContainsStartingSpace_DoesNothing()
        {
            // Arrange
            var builder = new System.Text.StringBuilder(" HELLO WORLD");

            // Act
            builder.TrimEnd();

            // Assert
            Assert.AreEqual(" HELLO WORLD", builder.ToString());
        }

        /// <summary>
        /// Tests the <see cref="StringBuilder.TrimEnd" /> method.
        /// </summary>
        [TestMethod]
        public void TrimEnd_StringContainsTrailingSpace_TrimsStringEnd()
        {
            // Arrange
            var builder = new System.Text.StringBuilder("HELLO WORLD ");

            // Act
            builder.TrimEnd();

            // Assert
            Assert.AreEqual("HELLO WORLD", builder.ToString());
        }

        /// <summary>
        /// Tests the <see cref="StringBuilder.TrimEnd" /> method.
        /// </summary>
        [TestMethod]
        public void TrimEnd_StringContainsStartingAndTrailingSpaces_TrimsStringEnd()
        {
            // Arrange
            var builder = new System.Text.StringBuilder(" HELLO WORLD ");

            // Act
            builder.TrimEnd();

            // Assert
            Assert.AreEqual(" HELLO WORLD", builder.ToString());
        }

        /// <summary>
        /// Tests the <see cref="StringBuilder.TrimStart" /> method.
        /// </summary>
        [ExpectedException(typeof(System.ArgumentNullException)), TestMethod]
        public void TrimStart_NullStringBuilder_ThrowsException()
        {
            // Arrange
            System.Text.StringBuilder builder = null;

            // Act
            builder.TrimStart();
        }

        /// <summary>
        /// Tests the <see cref="StringBuilder.TrimStart" /> method.
        /// </summary>
        [TestMethod]
        public void TrimStart_StringContainsStartingSpace_TrimsStringStart()
        {
            // Arrange
            var builder = new System.Text.StringBuilder(" HELLO WORLD");

            // Act
            builder.TrimStart();

            // Assert
            Assert.AreEqual("HELLO WORLD", builder.ToString());
        }

        /// <summary>
        /// Tests the <see cref="StringBuilder.TrimStart" /> method.
        /// </summary>
        [TestMethod]
        public void TrimStart_StringContainsTrailingSpace_DoesNothing()
        {
            // Arrange
            var builder = new System.Text.StringBuilder("HELLO WORLD ");

            // Act
            builder.TrimStart();

            // Assert
            Assert.AreEqual("HELLO WORLD ", builder.ToString());
        }

        /// <summary>
        /// Tests the <see cref="StringBuilder.TrimStart" /> method.
        /// </summary>
        [TestMethod]
        public void TrimStart_StringContainsStartingAndTrailingSpaces_TrimsStringStart()
        {
            // Arrange
            var builder = new System.Text.StringBuilder(" HELLO WORLD ");

            // Act
            builder.TrimStart();

            // Assert
            Assert.AreEqual("HELLO WORLD ", builder.ToString());
        }
    }
}
