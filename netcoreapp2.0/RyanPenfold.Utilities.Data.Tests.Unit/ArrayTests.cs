using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RyanPenfold.Utilities.Data.Tests.Unit
{
    [TestClass]
    public class ArrayTests
    {
        [TestMethod]
        public void Parse_NullString_ShouldReturnNull()
        {
            // Act
            var result = Array.Parse<int>(null);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Parse_EmptyString_ShouldReturnNull()
        {
            // Act
            var result = Array.Parse<int>(string.Empty);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Parse_WhiteSpaceString1_ShouldReturnNull()
        {
            // Act
            var result = Array.Parse<int>(" ");

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Parse_WhiteSpaceString2_ShouldReturnNull()
        {
            // Act
            var result = Array.Parse<int>("\r\n \r\n ");

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Parse_DoesntContainComma_ShouldProduceArrayWithOneElements()
        {
            // Arrange
            var input = "1";
            var expectedResult = new[] { 1 };

            // Act
            var result = Array.Parse<int>(input);

            // Assert
            Assert.AreEqual(expectedResult.Length, result.Length);
            for (var id = 0; id < expectedResult.Length; id++)
            {
                Assert.AreEqual(expectedResult[id], result[id]);
            }
        }

        [TestMethod]
        public void Parse_ContainsComma_ShouldProduceArrayWithMultipleElements()
        {
            // Arrange
            var input = "1,2";
            var expectedResult = new[] { 1, 2 };

            // Act
            var result = Array.Parse<int>(input);

            // Assert
            Assert.AreEqual(expectedResult.Length, result.Length);
            for (var id = 0; id < expectedResult.Length; id++)
            {
                Assert.AreEqual(expectedResult[id], result[id]);
            }
        }

        [TestMethod]
        public void Parse_ContainsCommaAndPadding_ShouldProduceArrayWithMultipleElements()
        {
            // Arrange
            var input = " 1 , 2 ";
            var expectedResult = new[] {1, 2};

            // Act
            var result = Array.Parse<int>(input);

            // Assert
            Assert.AreEqual(expectedResult.Length, result.Length);
            for (var id = 0; id < expectedResult.Length; id++)
            {
                Assert.AreEqual(expectedResult[id], result[id]);
            }
        }
    }
}
