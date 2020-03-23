// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using @string = RyanPenfold.Utilities.String;

    /// <summary>
    /// Provides unit tests for the 
    /// <see cref="RyanPenfold.Utilities.String" /> class.
    /// </summary>
    [TestClass]
    public class StringTests
    {
        /// <summary>
        /// Tests the ContainsNumbers method of the
        /// <see cref="RyanPenfold.Utilities.String" />
        /// class.
        /// </summary>
        [TestMethod]
        public void ContainsNumbers()
        {
            // Assert
            Assert.IsTrue("010100011101010010010".ContainsNumbers());
            Assert.IsFalse("ABBABBABABBABBABBABB".ContainsNumbers());
            Assert.IsTrue("ABBABBABA1BBABBABBABB".ContainsNumbers());
            Assert.IsFalse("%^**%%FSFFDFD`¬<>,.///".ContainsNumbers());
        }

        /// <summary>
        /// Tests the CountSubstringOccurrences method of the
        /// <see cref="RyanPenfold.Utilities.String" />
        /// class.
        /// </summary>
        [TestMethod]
        public void CountSubstringOccurrences()
        {
            // Act
            const string SubString = "IPSUM";

            // Assert         
            Assert.AreEqual(0, "LOREM".CountSubstringOccurrences(SubString));
            Assert.AreEqual(1, SubString.CountSubstringOccurrences(SubString));
            Assert.AreEqual(2, ($"{SubString} {SubString}").CountSubstringOccurrences(SubString));
            Assert.AreEqual(3, ($"{SubString} {SubString} {SubString}").CountSubstringOccurrences(SubString));
            Assert.AreEqual(4, ($"{SubString} {SubString} {SubString} {SubString}").CountSubstringOccurrences(SubString));
        }

        /// <summary>
        /// Tests the EqualsIgnoreCase method of the
        /// <see cref="RyanPenfold.Utilities.String" />
        /// class.
        /// </summary>
        [TestMethod]
        public void EqualsIgnoreCase()
        {
            // Assert         
            Assert.IsTrue("IPSUM".EqualsIgnoreCase("ipsum"));
            Assert.IsTrue("LOREM".EqualsIgnoreCase("lorem"));
            Assert.IsFalse("LOREM IPSUM".EqualsIgnoreCase("ipsum lorem"));
        }

        /// <summary>
        /// Tests the FromCamelCase method of the
        /// <see cref="RyanPenfold.Utilities.String" />
        /// class.
        /// </summary>
        [TestMethod]
        public void FromCamelCase()
        {
            // Assert         
            Assert.AreEqual("Ryan Penfold", "RyanPenfold".FromCamelCase());
            Assert.AreEqual("System Reflection", "SystemReflection".FromCamelCase());
            Assert.AreEqual("Scooby Dooby Doo", "ScoobyDoobyDoo".FromCamelCase());
            Assert.AreEqual("Save Our Lives", "SaveOurLives".FromCamelCase());
        }

        /// <summary>
        /// Tests the FromCharCodeString method of the
        /// <see cref="RyanPenfold.Utilities.String" />
        /// class.
        /// </summary>
        [TestMethod]
        public void FromCharCodeString()
        {
            // Assert         
            Assert.AreEqual("Ryan Penfold", "082121097110032080101110102111108100".FromCharCodeString());
            Assert.AreEqual("the quick brown fox jumps over the lazy dog", "116104101032113117105099107032098114111119110032102111120032106117109112115032111118101114032116104101032108097122121032100111103".FromCharCodeString());
        }

        /// <summary>
        /// Tests the FromEmptyToNothing method of the
        /// <see cref="RyanPenfold.Utilities.String" />
        /// class.
        /// </summary>
        [TestMethod]
        public void FromEmptyToNothing()
        {
            // Assert         
            Assert.AreEqual(null, " ".FromEmptyToNothing());
            Assert.AreEqual(null, string.Empty.FromEmptyToNothing());
            Assert.AreNotEqual(null, "Ryan".FromEmptyToNothing());
        }

        /// <summary>
        /// Tests the RemoveWhiteSpace method of the
        /// <see cref="RyanPenfold.Utilities.String" />
        /// class.
        /// </summary>
        [TestMethod]
        public void RemoveWhiteSpace()
        {
            // Assert         
            Assert.AreEqual("Hello World", "Hello  World".RemoveWhiteSpace());
            Assert.AreEqual(" IPSUM LOREM ", "  IPSUM  LOREM  ".RemoveWhiteSpace());
        }

        /// <summary>
        /// Tests the Reverse method of the
        /// <see cref="RyanPenfold.Utilities.String" />
        /// class.
        /// </summary>
        [TestMethod]
        public void Reverse()
        {
            // Arrange
            const string Input1 = "HELLO WORLD!";
            const string Input2 = "Lorem ipsum dolor sit amet";
            const string ExpectedResult1 = "!DLROW OLLEH";
            const string ExpectedResult2 = "tema tis rolod muspi meroL";

            // Act
            var result1 = Input1.Reverse();
            var result2 = Input2.Reverse();

            // Assert
            Assert.AreEqual(result1, ExpectedResult1);
            Assert.AreEqual(result2, ExpectedResult2);
        }

        /// <summary>
        /// Tests a method of the
        /// <see cref="RyanPenfold.Utilities.String" />
        /// class.
        /// </summary>
        [TestMethod]
        public void Sanitise()
        {
            // Assert         
            Assert.AreEqual(string.Empty, @String.Sanitise(null));
            Assert.AreEqual(string.Empty, @String.Sanitise(string.Empty));
            Assert.AreEqual("IPSUM LOREM", @String.Sanitise("IPSUM LOREM"));
        }

        /// <summary>
        /// Tests the ToBoolean method of the
        /// <see cref="RyanPenfold.Utilities.String" />
        /// class.
        /// </summary>
        [TestMethod]
        public void ToBoolean()
        {
            // Act & Assert         
            Assert.AreEqual(true, "1".ToBoolean());
            Assert.AreEqual(true, "yes".ToBoolean());
            Assert.AreEqual(true, "true".ToBoolean());
            Assert.AreNotEqual(true, "false".ToBoolean());
            Assert.AreEqual(false, "0".ToBoolean());
            Assert.AreEqual(false, "no".ToBoolean());
            Assert.AreEqual(false, "false".ToBoolean());
            Assert.AreNotEqual(false, "true".ToBoolean());
        }

        /// <summary>
        /// Tests the ToBoolean method of the
        /// <see cref="RyanPenfold.Utilities.String" />
        /// class.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.InvalidCastException))]
        public void ToBooleanWithException()
        {
            "IPSUM LOREM".ToBoolean();
        }

        /// <summary>
        /// Tests the ToCamelCase method of the
        /// <see cref="RyanPenfold.Utilities.String" />
        /// class.
        /// </summary>
        [TestMethod]
        public void ToCamelCase()
        {
            // Assert         
            Assert.AreEqual("IpsumLorem", "Ipsum Lorem".ToCamelCase());
            Assert.AreEqual("ipsumLorem", "Ipsum Lorem".ToCamelCase(true));
            Assert.AreEqual("IpsumLorem", "ipsum Lorem".ToCamelCase());
        }

        /// <summary>
        /// Tests the ToCharCodeString method of the
        /// <see cref="RyanPenfold.Utilities.String" />
        /// class.
        /// </summary>
        [TestMethod]
        public void ToCharCodeString()
        {
            // Assert 
            Assert.AreEqual("009082121097110032080101110102111108100", "\tRyan Penfold".ToCharCodeString());
            Assert.AreEqual("116104101032113117105099107032098114111119110032102111120032106117109112115032111118101114032116104101032108097122121032100111103", "the quick brown fox jumps over the lazy dog".ToCharCodeString());
        }

        /// <summary>
        /// Tests the ToLowerCamelCase method of the
        /// <see cref="RyanPenfold.Utilities.String" />
        /// class.
        /// </summary>
        [TestMethod]
        public void ToLowerCamelCase()
        {
            // Assert         
            Assert.AreEqual("ipsumLorem", "Ipsum Lorem".ToLowerCamelCase());
        }

        /// <summary>
        /// Tests the ToTitleCase method of the
        /// <see cref="RyanPenfold.Utilities.String" />
        /// class.
        /// </summary>
        [TestMethod]
        public void ToTitleCase()
        {
            // Assert         
            Assert.AreEqual("Ipsum lorem", "IpsumLorem".ToTitleCase(false));
            Assert.AreEqual("Ipsum Lorem", "IpsumLorem".ToTitleCase());
            Assert.AreEqual("TCP Listener", "TCPListener".ToTitleCase());
        }

        /// <summary>
        /// Tests the ToUpperCamelCase method of the
        /// <see cref="RyanPenfold.Utilities.String" />
        /// class.
        /// </summary>
        [TestMethod]
        public void ToUpperCamelCase()
        {
            // Assert         
            Assert.AreEqual("IpsumLorem", "Ipsum Lorem".ToUpperCamelCase());
        }

        /// <summary>
        /// Tests the ZeroPad method of the
        /// <see cref="RyanPenfold.Utilities.String" />
        /// class.
        /// </summary>
        [TestMethod]
        public void ZeroPad()
        {
            // Assert
            Assert.AreEqual("007", "7".ZeroPad(2));
            Assert.AreEqual("000007", "0007".ZeroPad(2));
            Assert.AreEqual("000007", "7".ZeroPad(5));
            Assert.AreEqual("00000007", "7".ZeroPad(7));
            Assert.AreEqual("00007", "7".ZeroPad(4, 7));
            Assert.AreEqual("0000007", "7".ZeroPad(7, 7));
            Assert.AreNotEqual("00007", "7".ZeroPad(7, 7));
        }
    }
}
