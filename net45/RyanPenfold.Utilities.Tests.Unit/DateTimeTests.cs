// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Provides unit tests for the 
    /// <see cref="RyanPenfold.Utilities.DateTime" /> class.
    /// </summary>
    [TestClass]
    public class DateTimeTests
    {
        /// <summary>
        /// Tests the <see cref="DateTime.MaxDayOfMonth"/> method.
        /// </summary>
        [TestMethod]
        public void MaxDayOfMonth_JanuaryRandomYear_Returns31()
        {
            // Assert
            Assert.AreEqual(31, DateTime.MaxDayOfMonth(1, (byte)Random.NextInt32(1, 9999)));
        }

        /// <summary>
        /// Tests the <see cref="DateTime.MaxDayOfMonth"/> method.
        /// </summary>
        [TestMethod]
        public void MaxDayOfMonth_FebruaryNonLeapYear_Returns28()
        {
            // Assert
            Assert.AreEqual(28, DateTime.MaxDayOfMonth(2, 1999));
        }

        /// <summary>
        /// Tests the <see cref="DateTime.MaxDayOfMonth"/> method.
        /// </summary>
        [TestMethod]
        public void MaxDayOfMonth_FebruaryLeapYear_Returns29()
        {
            // Assert
            Assert.AreEqual(29, DateTime.MaxDayOfMonth(2, 2000));
        }

        /// <summary>
        /// Tests the <see cref="DateTime.MaxDayOfMonth"/> method.
        /// </summary>
        [TestMethod]
        public void MaxDayOfMonth_MarchRandomYear_Returns31()
        {
            // Assert
            Assert.AreEqual(31, DateTime.MaxDayOfMonth(3, (byte)Random.NextInt32(1, 9999)));
        }

        /// <summary>
        /// Tests the <see cref="DateTime.MaxDayOfMonth"/> method.
        /// </summary>
        [TestMethod]
        public void MaxDayOfMonth_AprilRandomYear_Returns30()
        {
            // Assert
            Assert.AreEqual(30, DateTime.MaxDayOfMonth(4, (byte)Random.NextInt32(1, 9999)));
        }

        /// <summary>
        /// Tests the <see cref="DateTime.MaxDayOfMonth"/> method.
        /// </summary>
        [TestMethod]
        public void MaxDayOfMonth_MayRandomYear_Returns31()
        {
            // Assert
            Assert.AreEqual(31, DateTime.MaxDayOfMonth(5, (byte)Random.NextInt32(1, 9999)));
        }

        /// <summary>
        /// Tests the <see cref="DateTime.MaxDayOfMonth"/> method.
        /// </summary>
        [TestMethod]
        public void MaxDayOfMonth_JuneRandomYear_Returns30()
        {
            // Assert
            Assert.AreEqual(30, DateTime.MaxDayOfMonth(6, (byte)Random.NextInt32(1, 9999)));
        }

        /// <summary>
        /// Tests the <see cref="DateTime.MaxDayOfMonth"/> method.
        /// </summary>
        [TestMethod]
        public void MaxDayOfMonth_JulyRandomYear_Returns31()
        {
            // Assert
            Assert.AreEqual(31, DateTime.MaxDayOfMonth(7, (byte)Random.NextInt32(1, 9999)));
        }

        /// <summary>
        /// Tests the <see cref="DateTime.MaxDayOfMonth"/> method.
        /// </summary>
        [TestMethod]
        public void MaxDayOfMonth_AugustRandomYear_Returns31()
        {
            // Assert
            Assert.AreEqual(31, DateTime.MaxDayOfMonth(8, (byte)Random.NextInt32(1, 9999)));
        }

        /// <summary>
        /// Tests the <see cref="DateTime.MaxDayOfMonth"/> method.
        /// </summary>
        [TestMethod]
        public void MaxDayOfMonth_SeptemberRandomYear_Returns30()
        {
            // Assert
            Assert.AreEqual(30, DateTime.MaxDayOfMonth(9, (byte)Random.NextInt32(1, 9999)));
        }

        /// <summary>
        /// Tests the <see cref="DateTime.MaxDayOfMonth"/> method.
        /// </summary>
        [TestMethod]
        public void MaxDayOfMonth_OctoberRandomYear_Returns31()
        {
            // Assert
            Assert.AreEqual(31, DateTime.MaxDayOfMonth(10, (byte)Random.NextInt32(1, 9999)));
        }

        /// <summary>
        /// Tests the <see cref="DateTime.MaxDayOfMonth"/> method.
        /// </summary>
        [TestMethod]
        public void MaxDayOfMonth_NovemberRandomYear_Returns30()
        {
            // Assert
            Assert.AreEqual(30, DateTime.MaxDayOfMonth(11, (byte)Random.NextInt32(1, 9999)));
        }

        /// <summary>
        /// Tests the <see cref="DateTime.MaxDayOfMonth"/> method.
        /// </summary>
        [TestMethod]
        public void MaxDayOfMonth_DecemberRandomYear_Returns31()
        {
            // Assert
            Assert.AreEqual(31, DateTime.MaxDayOfMonth(12, (byte)Random.NextInt32(1, 9999)));
        }

        /// <summary>
        /// Tests the ToLongDateStringIncludingOrdinal method of 
        /// the <see cref="RyanPenfold.Utilities.DateTime" /> class.
        /// </summary>
        [TestMethod]
        public void ToLongDateStringIncludingOrdinal()
        {
            // Arrange
            var date = new System.DateTime(2011, 09, 28);

            // Act
            var result1 = date.ToLongDateStringIncludingOrdinal();
            var result2 = date.ToLongDateStringIncludingOrdinal(true);

            // Assert
            Assert.AreEqual("28th September 2011", result1);
            Assert.AreEqual("Wednesday 28th September 2011", result2);
        }

        /// <summary>
        /// Tests the ToCookieForm method of 
        /// the <see cref="RyanPenfold.Utilities.DateTime" /> class.
        /// </summary>
        [TestMethod]
        public void ToCookieForm()
        {
            // Arrange
            var date = new System.DateTime(2011, 09, 28);

            // Act
            var result = date.ToCookieForm();

            // Assert
            Assert.AreEqual("Wed, 28 Sep 2011 00:00:00 UTC", result);
        }

        /// <summary>
        /// Tests the ToDateTime method of 
        /// the <see cref="RyanPenfold.Utilities.DateTime" /> class.
        /// </summary>
        [TestMethod]
        public void ToDateTime()
        {
            // Arrange
            const string Date1 = "28/09/2011";
            const string Date2 = "28/09/2011 15:35";

            // Act
            var result1 = Date1.ToDateTime(103);
            var result2 = Date2.ToDateTime(-1);

            // Assert
            Assert.IsNotNull(result1);
            Assert.AreEqual(Date1, result1.ToString("dd/MM/yyyy"));
            Assert.IsNotNull(result2);
            Assert.AreEqual(Date2, result2.ToString("dd/MM/yyyy HH:mm"));
        }

        /// <summary>
        /// Tests the ToDateTime method of 
        /// the <see cref="RyanPenfold.Utilities.DateTime" /> class.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void ToDateTimeWithException1()
        {
            string.Empty.ToDateTime(103);
        }

        /// <summary>
        /// Tests the ToDateTime method of 
        /// the <see cref="RyanPenfold.Utilities.DateTime" /> class.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void ToDateTimeWithException2()
        {
            "1 1".ToDateTime(-1);
        }

        /// <summary>
        /// Tests the ToDateTime method of 
        /// the <see cref="RyanPenfold.Utilities.DateTime" /> class.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void ToDateTimeWithException3()
        {
            "28/09/1979 1".ToDateTime(-1);
        }

        /// <summary>
        /// Tests the ToDateTime method of 
        /// the <see cref="RyanPenfold.Utilities.DateTime" /> class.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void ToDateTimeWithException4()
        {
            " 1".ToDateTime(-1);
        }

        /// <summary>
        /// Tests the ToDateTime method of 
        /// the <see cref="RyanPenfold.Utilities.DateTime" /> class.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void ToDateTimeWithException5()
        {
            "1".ToDateTime(-1);
        }

        /// <summary>
        /// Tests the TruncateToSeconds method of 
        /// the <see cref="RyanPenfold.Utilities.DateTime" /> class.
        /// </summary>
        [TestMethod]
        public void TruncateToSeconds_PassedParameter_MillisecondsIsZero()
        {
            // Arrange
            var date = System.DateTime.UtcNow;

            // Act
            var result = date.TruncateToSeconds();

            // Assert
            Assert.IsTrue(result.Millisecond == 0);
        }
    }
}
