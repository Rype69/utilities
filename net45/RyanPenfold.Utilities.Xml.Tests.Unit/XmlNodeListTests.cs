using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RyanPenfold.Utilities.Xml.Tests.Unit
{
    [TestClass]
    public class XmlNodeListTests
    {
        [TestMethod]
        public void Any_HasNodes_ReturnsTrue()
        {
            // Arrange
            var xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.LoadXml("<Test></Test>");
            var childNodes = xmlDoc.ChildNodes;

            // Act
            var result = childNodes.Any();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Any_IsEmpty_ReturnsFalse()
        {
            // Arrange
            var xmlDoc = new System.Xml.XmlDocument();
            var childNodes = xmlDoc.ChildNodes;

            // Act
            var result = childNodes.Any();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Any_HasNonNullNodes_ReturnsTrue()
        {
            // Arrange
            var xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.LoadXml("<Test></Test>");
            var childNodes = xmlDoc.ChildNodes;

            // Act
            var result = childNodes.Any(r => r != null);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Any_HasSpecifiedNodes_ReturnsTrue()
        {
            // Arrange
            var xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.LoadXml("<Compile Include=\"Blah.cs\" />");
            var childNodes = xmlDoc.ChildNodes;

            // Act
            var result = childNodes.Any(r => r.Name == "Compile");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Any_HasNoSpecifiedNodes_ReturnsFalse()
        {
            // Arrange
            var xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.LoadXml("<Compile Include=\"Blah.cs\" />");
            var childNodes = xmlDoc.ChildNodes;

            // Act
            var result = childNodes.Any(r => r.Name == "EmbeddedResource");

            // Assert
            Assert.IsFalse(result);
        }

    }
}
