// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="RyanPenfold.Utilities.Exception" /> class.
    /// </summary>
    [TestClass]
    public class ExceptionTests
    {
        /// <summary>
        /// Tests the GetAllMessages method of the 
        /// <see cref="RyanPenfold.Utilities.Exception" /> class 
        /// with an exception with an empty message.
        /// </summary>
        [TestMethod]
        public void GetAllMessages_NoMessages()
        {
            // Arrange
            const string ExpectedResult = "Exception Message: ";
            var exception = new System.Exception(string.Empty);

            // Act
            var result = exception.GetAllMessages();

            // Assert
            Assert.AreEqual(ExpectedResult, result);
        }

        /// <summary>
        /// Tests the GetAllMessages method of the 
        /// <see cref="RyanPenfold.Utilities.Exception" /> class 
        /// with a single exception.
        /// </summary>
        [TestMethod]
        public void GetAllMessages_OneMessage()
        {
            // Arrange
            const string ExceptionMessage = "IPSUM LOREM";
            var expectedResult = $"Exception Message: {ExceptionMessage}";
            var exception = new System.Exception(ExceptionMessage);

            // Act
            var result = exception.GetAllMessages();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Tests the GetAllMessages method of the 
        /// <see cref="RyanPenfold.Utilities.Exception" /> class 
        /// with many exceptions.
        /// </summary>
        [TestMethod]
        public void GetAllMessages_ManyMessages()
        {
            // Arrange
            const string ExceptionMessage1 = "IPSUM1 LOREM1";
            const string ExceptionMessage2 = "IPSUM2 LOREM2";
            const string ExceptionMessage3 = "IPSUM3 LOREM3";
            const string ExceptionMessage4 = "IPSUM4 LOREM4";
            var expectedResult = string.Format(
                "Exception Message: {0}{1}{2}{1}{3}{1}{4}",
                ExceptionMessage1,
                ", Inner Exception Message: ", 
                ExceptionMessage2,
                ExceptionMessage3,
                ExceptionMessage4);
            var exception = new System.Exception(
                ExceptionMessage1, new System.Exception(ExceptionMessage2, new System.Exception(ExceptionMessage3, new System.Exception(ExceptionMessage4))));

            // Act
            var result = exception.GetAllMessages();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Tests the GetAllMessages method of the 
        /// <see cref="RyanPenfold.Utilities.Exception" /> class 
        /// with a single exception.
        /// </summary>
        [TestMethod]
        public void GetAllMessages_OneMessageNoLabels()
        {
            // Arrange
            const string ExceptionMessage = "IPSUM LOREM";
            const string ExpectedResult = ExceptionMessage;
            var exception = new System.Exception(ExceptionMessage);

            // Act
            var result = exception.GetAllMessages(false);

            // Assert
            Assert.AreEqual(ExpectedResult, result);
        }

        /// <summary>
        /// Tests the GetAllMessages method of the 
        /// <see cref="RyanPenfold.Utilities.Exception" /> class 
        /// with many exceptions.
        /// </summary>
        [TestMethod]
        public void GetAllMessages_ManyMessagesSpaceDelimited()
        {
            // Arrange
            const string ExceptionMessage1 = "IPSUM1 LOREM1";
            const string ExceptionMessage2 = "IPSUM2 LOREM2";
            const string ExceptionMessage3 = "IPSUM3 LOREM3";
            const string ExceptionMessage4 = "IPSUM4 LOREM4";
            var expectedResult = string.Format(
                "Exception Message: {0}{1}{2}{1}{3}{1}{4}",
                ExceptionMessage1,
                " Inner Exception Message: ",
                ExceptionMessage2,
                ExceptionMessage3,
                ExceptionMessage4);
            var exception = new System.Exception(
                ExceptionMessage1, new System.Exception(ExceptionMessage2, new System.Exception(ExceptionMessage3, new System.Exception(ExceptionMessage4))));

            // Act
            var result = exception.GetAllMessages(delimiter: " ");

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Tests the GetAllMessages method of the 
        /// <see cref="RyanPenfold.Utilities.Exception" /> class 
        /// with many exceptions.
        /// </summary>
        [TestMethod]
        public void GetAllMessages_ManyMessagesNoLabelsSpaceDelimited()
        {
            // Arrange
            const string ExceptionMessage1 = "IPSUM1 LOREM1";
            const string ExceptionMessage2 = "IPSUM2 LOREM2";
            const string ExceptionMessage3 = "IPSUM3 LOREM3";
            const string ExceptionMessage4 = "IPSUM4 LOREM4";
            var expectedResult = string.Format(
                "{0}{1}{2}{1}{3}{1}{4}",
                ExceptionMessage1,
                " ",
                ExceptionMessage2,
                ExceptionMessage3,
                ExceptionMessage4);
            var exception = new System.Exception(
                ExceptionMessage1, new System.Exception(ExceptionMessage2, new System.Exception(ExceptionMessage3, new System.Exception(ExceptionMessage4))));

            // Act
            var result = exception.GetAllMessages(false, " ");

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Tests the GetAllMessages method of the 
        /// <see cref="RyanPenfold.Utilities.Exception" /> class 
        /// with a single exception.
        /// </summary>
        [TestMethod]
        public void GetAllMessages_OneMessageShowStackTrace()
        {
            // Arrange
            const string ExceptionMessage = "IPSUM LOREM";
            System.Exception exception;

            try
            {
                throw new System.Exception(ExceptionMessage);
            }
            catch (System.Exception caughtException)
            {
                exception = caughtException;
            }

            var expectedResult = $"Exception Message: {ExceptionMessage}, Stack Trace: {exception.StackTrace.Trim()}";

            // Act
            var result = exception.GetAllMessages(showStackTrace: true);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Tests the GetAllMessages method of the 
        /// <see cref="RyanPenfold.Utilities.Exception" /> class 
        /// with many exceptions.
        /// </summary>
        [TestMethod]
        public void GetAllMessages_ManyMessagesShowStackTrace()
        {
            // Arrange
            const string ExceptionMessage1 = "IPSUM1 LOREM1";
            const string ExceptionMessage2 = "IPSUM2 LOREM2";
            const string ExceptionMessage3 = "IPSUM3 LOREM3";
            const string ExceptionMessage4 = "IPSUM4 LOREM4";

            System.Exception exception;

            try
            {
                throw new System.Exception(
                    ExceptionMessage1, new System.Exception(ExceptionMessage2, new System.Exception(ExceptionMessage3, new System.Exception(ExceptionMessage4))));
            }
            catch (System.Exception caughtException)
            {
                exception = caughtException;
            }

            var expectedResult = string.Format(
                "Exception Message: {0}{1}{2}{3}{4}{3}{5}{3}{6}",
                ExceptionMessage1,
                ", Stack Trace: ",
                exception.StackTrace.Trim(),
                ", Inner Exception Message: ",
                ExceptionMessage2,
                ExceptionMessage3,
                ExceptionMessage4);

            // Act
            var result = exception.GetAllMessages(showStackTrace: true);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Tests the GetAllMessages method of the 
        /// <see cref="RyanPenfold.Utilities.Exception" /> class 
        /// with a single exception.
        /// </summary>
        [TestMethod]
        public void GetAllMessages_OneMessageNoLabelsShowStackTrace()
        {
            // Arrange
            const string ExceptionMessage = "IPSUM LOREM";

            System.Exception exception;

            try
            {
                throw new System.Exception(ExceptionMessage);
            }
            catch (System.Exception caughtException)
            {
                exception = caughtException;
            }

            var expectedResult = $"{ExceptionMessage}, {exception.StackTrace.Trim()}";

            // Act
            var result = exception.GetAllMessages(false, showStackTrace: true);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Tests the GetAllMessages method of the 
        /// <see cref="RyanPenfold.Utilities.Exception" /> class 
        /// with an exception with an empty message.
        /// </summary>
        [TestMethod]
        public void GetAllMessages_NoMessagesNoLabelsShowStackTrace()
        {
            // Arrange
            System.Exception exception;

            try
            {
                throw new System.Exception(string.Empty);
            }
            catch (System.Exception caughtException)
            {
                exception = caughtException;
            }

            var expectedResult = exception.StackTrace.Trim();

            // Act
            var result = exception.GetAllMessages(false, showStackTrace: true);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Tests the GetAllMessages method of the 
        /// <see cref="RyanPenfold.Utilities.Exception" /> class 
        /// with many exceptions.
        /// </summary>
        [TestMethod]
        public void GetAllMessages_ManyMessagesSpaceDelimitedShowStackTrace()
        {
            // Arrange
            const string ExceptionMessage1 = "IPSUM1 LOREM1";
            const string ExceptionMessage2 = "IPSUM2 LOREM2";
            const string ExceptionMessage3 = "IPSUM3 LOREM3";
            const string ExceptionMessage4 = "IPSUM4 LOREM4";

            System.Exception exception;

            try
            {
                throw new System.Exception(
                    ExceptionMessage1, new System.Exception(ExceptionMessage2, new System.Exception(ExceptionMessage3, new System.Exception(ExceptionMessage4))));
            }
            catch (System.Exception caughtException)
            {
                exception = caughtException;
            }

            var expectedResult = string.Format(
                "Exception Message: {0}{1}{2}{3}{4}{3}{5}{3}{6}",
                ExceptionMessage1,
                " Stack Trace: ",
                exception.StackTrace.Trim(),
                " Inner Exception Message: ",
                ExceptionMessage2,
                ExceptionMessage3,
                ExceptionMessage4);

            // Act
            var result = exception.GetAllMessages(delimiter: " ", showStackTrace: true);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Tests the GetAllMessages method of the 
        /// <see cref="RyanPenfold.Utilities.Exception" /> class 
        /// with many exceptions.
        /// </summary>
        [TestMethod]
        public void GetAllMessages_ManyMessagesNoLabelsSpaceDelimitedShowStackTrace()
        {
            // Arrange
            const string ExceptionMessage1 = "IPSUM1 LOREM1";
            const string ExceptionMessage2 = "IPSUM2 LOREM2";
            const string ExceptionMessage3 = "IPSUM3 LOREM3";
            const string ExceptionMessage4 = "IPSUM4 LOREM4";

            System.Exception exception;

            try
            {
                throw new System.Exception(
                    ExceptionMessage1, new System.Exception(ExceptionMessage2, new System.Exception(ExceptionMessage3, new System.Exception(ExceptionMessage4))));
            }
            catch (System.Exception caughtException)
            {
                exception = caughtException;
            }

            var expectedResult = string.Format(
                "{0}{1}{2}{1}{3}{1}{4}{1}{5}",
                ExceptionMessage1,
                " ",
                exception.StackTrace.Trim(),
                ExceptionMessage2,
                ExceptionMessage3,
                ExceptionMessage4);

            // Act
            var result = exception.GetAllMessages(false, " ", true);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
