// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntegerTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Provides unit tests for the 
    /// <see cref="RyanPenfold.Utilities.Integer" /> class.
    /// </summary>
    [TestClass]
    public class IntegerTests
    {
        /// <summary>
        /// Tests the ToText method of 
        /// the <see cref="RyanPenfold.Utilities.Integer" /> class.
        /// </summary>
        [TestMethod]
        public void ToText()
        {
            Assert.AreEqual("Minus One Hundred", (-100).ToText());
            Assert.AreEqual("Minus Ninety", (-90).ToText());
            Assert.AreEqual("Minus Eighty", (-80).ToText());
            Assert.AreEqual("Minus Seventy", (-70).ToText());
            Assert.AreEqual("Minus Sixty", (-60).ToText());
            Assert.AreEqual("Minus Fifty", (-50).ToText());
            Assert.AreEqual("Minus Forty", (-40).ToText());
            Assert.AreEqual("Minus Thirty", (-30).ToText());
            Assert.AreEqual("Minus Twenty", (-20).ToText());
            Assert.AreEqual("Minus Ten", (-10).ToText());
            Assert.AreEqual("Minus Four", (-4).ToText());
            Assert.AreEqual("Minus Three", (-3).ToText());
            Assert.AreEqual("Minus Two", (-2).ToText());
            Assert.AreEqual("Minus One", (-1).ToText());
            Assert.AreEqual("Zero", 0.ToText());
            Assert.AreEqual("One", 1.ToText());
            Assert.AreEqual("Two", 2.ToText());
            Assert.AreEqual("Three", 3.ToText());
            Assert.AreEqual("Four", 4.ToText());
            Assert.AreEqual("Five", 5.ToText());
            Assert.AreEqual("Six", 6.ToText());
            Assert.AreEqual("Seven", 7.ToText());
            Assert.AreEqual("Eight", 8.ToText());
            Assert.AreEqual("Nine", 9.ToText());
            Assert.AreEqual("Ten", 10.ToText());
            Assert.AreEqual("Eleven", 11.ToText());
            Assert.AreEqual("Twelve", 12.ToText());
            Assert.AreEqual("Thirteen", 13.ToText());
            Assert.AreEqual("Fourteen", 14.ToText());
            Assert.AreEqual("Fifteen", 15.ToText());
            Assert.AreEqual("Sixteen", 16.ToText());
            Assert.AreEqual("Seventeen", 17.ToText());
            Assert.AreEqual("Eighteen", 18.ToText());
            Assert.AreEqual("Nineteen", 19.ToText());
            Assert.AreEqual("Twenty", 20.ToText());
            Assert.AreEqual("Twenty One", 21.ToText());
            Assert.AreEqual("Thirty", 30.ToText());
            Assert.AreEqual("Thirty Seven", 37.ToText());
            Assert.AreEqual("Forty", 40.ToText());
            Assert.AreEqual("Forty Two", 42.ToText());
            Assert.AreEqual("Fifty", 50.ToText());
            Assert.AreEqual("Fifty Five", 55.ToText());
            Assert.AreEqual("Sixty", 60.ToText());
            Assert.AreEqual("Sixty Three", 63.ToText());
            Assert.AreEqual("Seventy", 70.ToText());
            Assert.AreEqual("Seventy Four", 74.ToText());
            Assert.AreEqual("Eighty", 80.ToText());
            Assert.AreEqual("Eighty Eight", 88.ToText());
            Assert.AreEqual("Ninety", 90.ToText());
            Assert.AreEqual("Ninety Six", 96.ToText());
            Assert.AreEqual("One Hundred", 100.ToText());
            Assert.AreEqual("One Hundred and Sixty Four", 164.ToText());
            Assert.AreEqual("Two Hundred", 200.ToText());
            Assert.AreEqual("Two Hundred and Thirty", 230.ToText());
            Assert.AreEqual("Three Hundred", 300.ToText());
            Assert.AreEqual("Four Hundred", 400.ToText());
            Assert.AreEqual("Five Hundred", 500.ToText());
            Assert.AreEqual("Six Hundred", 600.ToText());
            Assert.AreEqual("Seven Hundred", 700.ToText());
            Assert.AreEqual("Eight Hundred", 800.ToText());
            Assert.AreEqual("Nine Hundred", 900.ToText());
            Assert.AreEqual("One Thousand", 1000.ToText());
            Assert.AreEqual("One Thousand and Ten", 1010.ToText());
            Assert.AreEqual("One Thousand, One Hundred", 1100.ToText());
            Assert.AreEqual("One Thousand, One Hundred and Eighty", 1180.ToText());
            Assert.AreEqual("One Thousand, Nine Hundred", 1900.ToText());
            Assert.AreEqual("Two Thousand", 2000.ToText());
            Assert.AreEqual("Three Thousand", 3000.ToText());
            Assert.AreEqual("Four Thousand", 4000.ToText());
            Assert.AreEqual("Forty Thousand", 40000.ToText());
            Assert.AreEqual("One Hundred Thousand", 100000.ToText());
            Assert.AreEqual("One Hundred and Eighty Thousand", 180000.ToText());
            Assert.AreEqual("One Million", 1000000.ToText());
            Assert.AreEqual("Nine Million", 9000000.ToText());
            Assert.AreEqual("Ninety Million", 90000000.ToText());
            Assert.AreEqual("One Hundred and Ninety Million", 190000000.ToText());
            Assert.AreEqual("One Hundred and Ninety Million, Ten Thousand, One Hundred", 190010100.ToText());
            Assert.AreEqual("One Billion", 1000000000.ToText());
            Assert.AreEqual("One Billion, One Hundred", 1000000100.ToText());
            Assert.AreEqual("One Billion, One Hundred and Twenty", 1000000120.ToText());
            Assert.AreEqual("Two Billion and Twenty One", 2000000021.ToText());
        }
    }
}
