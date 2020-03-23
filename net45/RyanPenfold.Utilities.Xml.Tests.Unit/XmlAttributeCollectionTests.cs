using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RyanPenfold.Utilities.Xml.Tests.Unit
{
    [TestClass]
    public class XmlAttributeCollectionTests
    {
        [TestMethod]
        public void Any_HasAttributes_ReturnsTrue()
        {
            // Arrange
            var xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.LoadXml("<Test Include=\"Blah.cs\"></Test>");
            var childNodes = xmlDoc.ChildNodes;

            // Act
            var result = childNodes[0].Attributes.Any();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Any_IsEmpty_ReturnsFalse()
        {
            // Arrange
            var xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.LoadXml("<Test></Test>");
            var childNodes = xmlDoc.ChildNodes;

            // Act
            var result = childNodes[0].Attributes.Any();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Any_HasNonNullAttributes_ReturnsTrue()
        {
            // Arrange
            var xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.LoadXml("<Test Include=\"Blah.cs\"></Test>");
            var childNodes = xmlDoc.ChildNodes;

            // Act
            var result = childNodes[0].Attributes.Any(r => r != null);

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
            var result = childNodes[0].Attributes.Any(r => r.Name == "Include");

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
            var result = childNodes[0].Attributes.Any(r => r.Name == "Invalid");

            // Assert
            Assert.IsFalse(result);
        }

    }
}
