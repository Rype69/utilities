// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit.IO
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Provides unit tests for the 
    /// <see cref="RyanPenfold.Utilities.IO.File" /> class.
    /// </summary>
    [TestClass]
    public class FileTests
    {
        /// <summary>
        /// Tests the Delete method of the 
        /// <see cref="RyanPenfold.Utilities.IO.File" /> class.
        /// </summary>
        [TestMethod]
        public void Delete()
        {
            // The path to the new file
            var path = Utilities.IO.UncPath.GetApplicationDirectory() +
                "\\NewFile.txt";

            // Create the file on disk
            using (System.IO.File.Create(path))
            {
                // Assert the file exists
                Assert.IsTrue(System.IO.File.Exists(path));
            }

            // Run the delete method in utilities
            var result = Utilities.IO.File.Delete(path);

            // Assert the file is now deleted
            Assert.IsFalse(System.IO.File.Exists(path));

            // Assert the result is true
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Tests the Delete method of the 
        /// <see cref="RyanPenfold.Utilities.IO.File" /> class.
        /// </summary>
        [TestMethod]
        public void DeleteWithException()
        {
            // The path to the new file
            var path = Utilities.IO.UncPath.GetApplicationDirectory() +
                "\\NewFileWithException.txt";

            // Create the file on disk but without the using statement
            System.IO.File.Create(path);

            // Run the delete method in utilities
            var result = Utilities.IO.File.Delete(path);

            // Assert the file still exists
            Assert.IsTrue(System.IO.File.Exists(path));

            // Assert the result is false
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Tests the IsEmpty method of the 
        /// <see cref="RyanPenfold.Utilities.IO.File" /> class.
        /// </summary>
        [TestMethod]
        public void IsEmpty()
        {
            // The path to the new file
            var path = Utilities.IO.UncPath.GetApplicationDirectory() +
                "\\NewFile.txt";

            // Create the file on disk
            using (System.IO.File.Create(path))
            {
                // Assert the file exists
                Assert.IsTrue(System.IO.File.Exists(path));
            }

            // Assert the file is empty
            Assert.IsTrue(Utilities.IO.File.IsEmpty(path));

            // Write some data to file
            using (var streamWriter = new System.IO.StreamWriter(path, true))
            {
                streamWriter.Write("HELLO WORLD!");
            }

            // Assert the file is not empty
            Assert.IsFalse(Utilities.IO.File.IsEmpty(path));

            // Delete file
            System.IO.File.Delete(path);

            // Assert the file is now deleted
            Assert.IsFalse(System.IO.File.Exists(path));
        }

        /// <summary>
        /// Tests the Read method of the 
        /// <see cref="RyanPenfold.Utilities.IO.File" /> class.
        /// </summary>
        [TestMethod]
        public void Read()
        {
            // The path to the new file
            var path = Utilities.IO.UncPath.GetApplicationDirectory() +
                "\\NewFile.txt";

            const string TestData = "HELLO WORLD!";

            // Create the file on disk
            using (System.IO.File.Create(path))
            {
                // Assert the file exists
                Assert.IsTrue(System.IO.File.Exists(path));
            }

            // Variable to store the contents of the file
            string fileContents;

            // Read the contents of the file
            using (var streamReader = new System.IO.StreamReader(path, true))
            {
                fileContents = streamReader.ReadToEnd();
            }

            // Contents should be empty at this stage
            Assert.AreEqual(string.Empty, fileContents);

            // Write some data to the file
            using (var streamWriter = new System.IO.StreamWriter(path, true))
            {
                streamWriter.Write(TestData);
            }

            // Re-read the file
            using (var streamReader = new System.IO.StreamReader(path, true))
            {
                fileContents = streamReader.ReadToEnd();
            }

            // Assert the file contains the test string 
            Assert.AreEqual(TestData, fileContents);

            // Delete file
            System.IO.File.Delete(path);

            // Assert the file is now deleted
            Assert.IsFalse(System.IO.File.Exists(path));
        }

        /// <summary>
        /// Tests the Read method of the 
        /// <see cref="RyanPenfold.Utilities.IO.File" /> class.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.IO.DirectoryNotFoundException))]
        public void ReadWithException()
        {
            // Arrange
            var driveLetter = Common.FindDriveLetterThatDoesntExist();

            if (string.IsNullOrEmpty(driveLetter))
            {
                return;
            }

            // Act
            var result = Utilities.IO.File.Read($"{driveLetter}directory\\");

            // Assert
            Assert.IsTrue(string.IsNullOrEmpty(result));
        }

        /// <summary>
        /// Tests the Write method of the 
        /// <see cref="Utilities.IO.File" /> class.
        /// </summary>
        [TestMethod]
        public void Write()
        {
            // The path to the new file
            var path = Utilities.IO.UncPath.GetApplicationDirectory() +
                "\\NewFile.txt";

            const string TestData = "HELLO WORLD!";

            // Create the file on disk
            using (System.IO.File.Create(path))
            {
                // Assert the file exists
                Assert.IsTrue(System.IO.File.Exists(path));
            }

            // Variable to store the contents of the file
            string fileContents;

            // Read the contents of the file
            using (var streamReader = new System.IO.StreamReader(path, true))
            {
                fileContents = streamReader.ReadToEnd();
            }

            // Contents should be empty at this stage
            Assert.AreEqual(string.Empty, fileContents);

            // Write some data to the file with the utilities
            Utilities.IO.File.Write(TestData, path);

            // Re-read the file
            using (var streamReader = new System.IO.StreamReader(path, true))
            {
                fileContents = streamReader.ReadToEnd();
            }

            // Assert the file contains the test string 
            Assert.AreEqual(TestData, fileContents);

            // Delete file
            System.IO.File.Delete(path);

            // Assert the file is now deleted
            Assert.IsFalse(System.IO.File.Exists(path));
        }

        /// <summary>
        /// Tests the Write method of the 
        /// <see cref="RyanPenfold.Utilities.IO.File" /> class.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.IO.DirectoryNotFoundException))]
        public void WriteWithException()
        {
            // Arrange
            var driveLetter = Common.FindDriveLetterThatDoesntExist();

            if (string.IsNullOrEmpty(driveLetter))
            {
                return;
            }

            const string TestData = "HELLO WORLD!";

            // Act
            var result = Utilities.IO.File.Write(TestData, $"{driveLetter}dir\\");

            // Assert
            Assert.IsFalse(result);
        }
    }
}
