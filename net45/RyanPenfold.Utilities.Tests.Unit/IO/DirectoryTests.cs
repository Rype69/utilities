// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DirectoryTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit.IO
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Provides unit tests for the 
    /// <see cref="Utilities.IO.Directory" /> class.
    /// </summary>
    [TestClass]
    public class DirectoryTests
    {
        /// <summary>
        /// Tests the ClearOrCreate method of the 
        /// <see cref="Utilities.IO.Directory" /> class.
        /// </summary>
        [TestMethod]
        public void ClearOrCreate()
        {
            // Get application path
            var appDir = Utilities.IO.UncPath.GetApplicationDirectory();

            // Assert target directory doesn't exist at present
            Assert.IsFalse(System.IO.Directory.Exists($"{appDir}\\Root1\\Dir1\\Dir4"));

            // Attempt to create directory
            Utilities.IO.Directory.ClearOrCreate($"{appDir}\\Root1\\Dir1");

            // Should now exist
            Assert.IsTrue(System.IO.Directory.Exists($"{appDir}\\Root1\\Dir1"));

            // Create a nested directory
            System.IO.Directory.CreateDirectory($"{appDir}\\Root1\\Dir1\\Dir4");

            // Should now exist
            Assert.IsTrue(System.IO.Directory.Exists($"{appDir}\\Root1\\Dir1\\Dir4"));

            // Create a file
            using (System.IO.File.Create($"{appDir}\\Root1\\Dir1\\Dir4.txt"))
            {
                // The file now exist
                Assert.IsTrue(System.IO.File.Exists($"{appDir}\\Root1\\Dir1\\Dir4.txt"));
            }

            // Attempt to clear directory
            Utilities.IO.Directory.ClearOrCreate($"{appDir}\\Root1\\Dir1");

            // Nested directory should no longer exist
            Assert.IsFalse(System.IO.Directory.Exists($"{appDir}\\Root1\\Dir1\\Dir4"));

            // File should no longer exist
            Assert.IsFalse(System.IO.File.Exists($"{appDir}\\Root1\\Dir1\\Dir4.txt"));

            // Clean up
            if (System.IO.Directory.Exists($"{appDir}\\Root1\\Dir1\\Dir4"))
            {
                System.IO.Directory.Delete($"{appDir}\\Root1\\Dir1\\Dir4");
            }

            Assert.IsFalse(System.IO.Directory.Exists($"{appDir}\\Root1\\Dir1\\Dir4"));

            if (System.IO.Directory.Exists($"{appDir}\\Root1\\Dir1"))
            {
                System.IO.Directory.Delete($"{appDir}\\Root1\\Dir1");
            }

            Assert.IsFalse(System.IO.Directory.Exists($"{appDir}\\Root1\\Dir1"));
        }

        /// <summary>
        /// Tests the GetDirectories method of the 
        /// <see cref="RyanPenfold.Utilities.IO.Directory" /> class.
        /// </summary>
        [TestMethod]
        public void GetDirectories()
        {
            // Get application path
            var appDir = Utilities.IO.UncPath.GetApplicationDirectory();

            // Create a couple of directories, one inside another.
            System.IO.Directory.CreateDirectory($"{appDir}\\Root1\\Dir1");

            // Create another nested directory.
            System.IO.Directory.CreateDirectory($"{appDir}\\Root1\\Dir2");

            // And another
            System.IO.Directory.CreateDirectory($"{appDir}\\Root1\\Dir2\\Dir3");

            // And another
            System.IO.Directory.CreateDirectory($"{appDir}\\Root1\\Dir1\\Dir4");

            // Get the directories using the Utilities
            var directories = Utilities.IO.Directory.GetDirectories($"{appDir}\\Root1");

            // Ensure 4 results are found
            Assert.AreEqual(4, directories.Count);

            Assert.IsNotNull(directories[0]);
            Assert.AreEqual($"{appDir}\\Root1\\Dir1\\Dir4", directories[0]);

            Assert.IsNotNull(directories[1]);
            Assert.AreEqual($"{appDir}\\Root1\\Dir1", directories[1]);

            Assert.IsNotNull(directories[2]);
            Assert.AreEqual($"{appDir}\\Root1\\Dir2\\Dir3", directories[2]);

            Assert.IsNotNull(directories[3]);
            Assert.AreEqual($"{appDir}\\Root1\\Dir2", directories[3]);

            // Clean up
            System.IO.Directory.Delete($"{appDir}\\Root1\\Dir1\\Dir4");
            Assert.IsFalse(System.IO.Directory.Exists($"{appDir}\\Root1\\Dir1\\Dir4"));

            System.IO.Directory.Delete($"{appDir}\\Root1\\Dir1");
            Assert.IsFalse(System.IO.Directory.Exists($"{appDir}\\Root1\\Dir1"));

            System.IO.Directory.Delete($"{appDir}\\Root1\\Dir2\\Dir3");
            Assert.IsFalse(System.IO.Directory.Exists($"{appDir}\\Root1\\Dir2\\Dir3"));

            System.IO.Directory.Delete($"{appDir}\\Root1\\Dir2");
            Assert.IsFalse(System.IO.Directory.Exists($"{appDir}\\Root1\\Dir2"));

            System.IO.Directory.Delete($"{appDir}\\Root1");
            Assert.IsFalse(System.IO.Directory.Exists($"{appDir}\\Root1"));
        }

        /// <summary>
        /// Tests the GetFiles method of the 
        /// <see cref="RyanPenfold.Utilities.IO.Directory" /> class.
        /// </summary>
        [TestMethod]
        public void GetFiles()
        {
            // Get application path
            var appDir = Utilities.IO.UncPath.GetApplicationDirectory();

            // Create a couple of directories, one inside another.
            System.IO.Directory.CreateDirectory($"{appDir}\\Root2\\Dir1");

            // Create a file
            using (System.IO.File.Create($"{appDir}\\Root2\\Dir1\\File1.txt"))
            {
                Assert.IsTrue(System.IO.File.Exists($"{appDir}\\Root2\\Dir1\\File1.txt"));
            }

            // Create another nested directory.
            System.IO.Directory.CreateDirectory($"{appDir}\\Root2\\Dir2");

            // Create another file
            using (System.IO.File.Create($"{appDir}\\Root2\\Dir2\\File2.txt"))
            {
                Assert.IsTrue(System.IO.File.Exists($"{appDir}\\Root2\\Dir2\\File2.txt"));
            }

            // Add another directory
            System.IO.Directory.CreateDirectory($"{appDir}\\Root2\\Dir2\\Dir3");

            // Create another file
            using (System.IO.File.Create($"{appDir}\\Root2\\Dir2\\Dir3\\File3.txt"))
            {
                Assert.IsTrue(System.IO.File.Exists($"{appDir}\\Root2\\Dir2\\Dir3\\File3.txt"));
            }

            // Add another directory
            System.IO.Directory.CreateDirectory($"{appDir}\\Root2\\Dir1\\Dir4");

            // Create another file
            using (System.IO.File.Create($"{appDir}\\Root2\\Dir1\\Dir4\\File4.txt"))
            {
                Assert.IsTrue(System.IO.File.Exists($"{appDir}\\Root2\\Dir1\\Dir4\\File4.txt"));
            }

            // Get the files using the Utilities
            var files = Utilities.IO.Directory.GetFiles($"{appDir}\\Root2");

            // Ensure 4 results are found
            Assert.AreEqual(4, files.Count);

            Assert.IsNotNull(files[0]);
            Assert.AreEqual($"{appDir}\\Root2\\Dir1\\Dir4\\File4.txt", files[0]);

            Assert.IsNotNull(files[1]);
            Assert.AreEqual($"{appDir}\\Root2\\Dir1\\File1.txt", files[1]);

            Assert.IsNotNull(files[2]);
            Assert.AreEqual($"{appDir}\\Root2\\Dir2\\Dir3\\File3.txt", files[2]);

            Assert.IsNotNull(files[3]);
            Assert.AreEqual($"{appDir}\\Root2\\Dir2\\File2.txt", files[3]);

            // Clean up
            System.IO.File.Delete($"{appDir}\\Root2\\Dir1\\Dir4\\File4.txt");
            Assert.IsFalse(System.IO.File.Exists($"{appDir}\\Root2\\Dir1\\Dir4\\File4.txt"));

            System.IO.File.Delete($"{appDir}\\Root2\\Dir1\\File1.txt");
            Assert.IsFalse(System.IO.File.Exists($"{appDir}\\Root2\\Dir1\\File1.txt"));

            System.IO.File.Delete($"{appDir}\\Root2\\Dir2\\Dir3\\File3.txt");
            Assert.IsFalse(System.IO.File.Exists($"{appDir}\\Root2\\Dir2\\Dir3\\File3.txt"));

            System.IO.File.Delete($"{appDir}\\Root2\\Dir2\\File2.txt");
            Assert.IsFalse(System.IO.File.Exists($"{appDir}\\Root2\\Dir2\\File2.txt"));

            System.IO.Directory.Delete($"{appDir}\\Root2\\Dir1\\Dir4");
            Assert.IsFalse(System.IO.Directory.Exists($"{appDir}\\Root2\\Dir1\\Dir4"));

            System.IO.Directory.Delete($"{appDir}\\Root2\\Dir2\\Dir3");
            Assert.IsFalse(System.IO.Directory.Exists($"{appDir}\\Root2\\Dir2\\Dir3"));

            System.IO.Directory.Delete($"{appDir}\\Root2\\Dir2");
            Assert.IsFalse(System.IO.Directory.Exists($"{appDir}\\Root2\\Dir2"));

            System.IO.Directory.Delete($"{appDir}\\Root2\\Dir1");
            Assert.IsFalse(System.IO.Directory.Exists($"{appDir}\\Root2\\Dir1"));

            System.IO.Directory.Delete($"{appDir}\\Root2");
            Assert.IsFalse(System.IO.Directory.Exists($"{appDir}\\Root2"));
        }

        /// <summary>
        /// Tests the GetObjects method of the 
        /// <see cref="RyanPenfold.Utilities.IO.Directory" /> class.
        /// </summary>
        [TestMethod]
        public void GetObjects()
        {
            // Get application path
            var appDir = Utilities.IO.UncPath.GetApplicationDirectory();

            // Create a couple of directories, one inside another.
            System.IO.Directory.CreateDirectory($"{appDir}\\Root3\\Dir1");

            // Create a file
            using (System.IO.File.Create($"{appDir}\\Root3\\File1.txt"))
            {
                Assert.IsTrue(System.IO.File.Exists($"{appDir}\\Root3\\File1.txt"));
            }

            // Create another nested directory.
            System.IO.Directory.CreateDirectory($"{appDir}\\Root3\\Dir2");

            // Create another file
            using (System.IO.File.Create($"{appDir}\\Root3\\File2.txt"))
            {
                Assert.IsTrue(System.IO.File.Exists($"{appDir}\\Root3\\File2.txt"));
            }

            // Get the objects using the Utilities
            var objects = Utilities.IO.Directory.GetObjects($"{appDir}\\Root3");

            // Ensure 4 results are found
            Assert.AreEqual(4, objects.Length);

            Assert.IsNotNull(objects[0]);
            Assert.IsInstanceOfType(objects[0], typeof(System.IO.FileInfo));
            Assert.AreEqual($"{appDir}\\Root3\\File1.txt", ((System.IO.FileInfo)objects[0]).FullName);

            Assert.IsNotNull(objects[1]);
            Assert.IsInstanceOfType(objects[1], typeof(System.IO.FileInfo));
            Assert.AreEqual($"{appDir}\\Root3\\File2.txt", ((System.IO.FileInfo)objects[1]).FullName);

            Assert.IsNotNull(objects[2]);
            Assert.IsInstanceOfType(objects[2], typeof(System.IO.DirectoryInfo));
            Assert.AreEqual($"{appDir}\\Root3\\Dir1", ((System.IO.DirectoryInfo)objects[2]).FullName);

            Assert.IsNotNull(objects[3]);
            Assert.IsInstanceOfType(objects[3], typeof(System.IO.DirectoryInfo));
            Assert.AreEqual($"{appDir}\\Root3\\Dir2", ((System.IO.DirectoryInfo)objects[3]).FullName);

            // Clean up
            System.IO.File.Delete($"{appDir}\\Root3\\File1.txt");
            Assert.IsFalse(System.IO.File.Exists($"{appDir}\\Root3\\File1.txt"));

            System.IO.File.Delete($"{appDir}\\Root3\\File2.txt");
            Assert.IsFalse(System.IO.File.Exists($"{appDir}\\Root3\\File2.txt"));

            System.IO.Directory.Delete($"{appDir}\\Root3\\Dir1");
            Assert.IsFalse(System.IO.Directory.Exists($"{appDir}\\Root3\\Dir1"));

            System.IO.Directory.Delete($"{appDir}\\Root3\\Dir2");
            Assert.IsFalse(System.IO.Directory.Exists($"{appDir}\\Root3\\Dir2"));

            System.IO.Directory.Delete($"{appDir}\\Root3");
            Assert.IsFalse(System.IO.Directory.Exists($"{appDir}\\Root3"));
        }

        /// <summary>
        /// Tests the CountObjects method of the 
        /// <see cref="RyanPenfold.Utilities.IO.Directory" /> class.
        /// </summary>
        [TestMethod]
        public void CountObjects()
        {
            // Get application path
            var appDir = Utilities.IO.UncPath.GetApplicationDirectory();

            // Create a couple of directories, one inside another.
            System.IO.Directory.CreateDirectory($"{appDir}\\Root4\\Dir1");

            // Create a file
            using (System.IO.File.Create($"{appDir}\\Root4\\File1.txt"))
            {
                Assert.IsTrue(System.IO.File.Exists($"{appDir}\\Root4\\File1.txt"));
            }

            // Create another nested directory.
            System.IO.Directory.CreateDirectory($"{appDir}\\Root4\\Dir2");

            // Create another file
            using (System.IO.File.Create($"{appDir}\\Root4\\File2.txt"))
            {
                Assert.IsTrue(System.IO.File.Exists($"{appDir}\\Root4\\File2.txt"));
            }

            // Get the objects using the Utilities
            var objectCount = Utilities.IO.Directory.CountObjects($"{appDir}\\Root4", true);

            // Ensure 4 results are found
            Assert.AreEqual(4, objectCount);

            // Clean up
            System.IO.File.Delete($"{appDir}\\Root4\\File1.txt");
            Assert.IsFalse(System.IO.File.Exists($"{appDir}\\Root4\\File1.txt"));

            System.IO.File.Delete($"{appDir}\\Root4\\File2.txt");
            Assert.IsFalse(System.IO.File.Exists($"{appDir}\\Root4\\File2.txt"));

            System.IO.Directory.Delete($"{appDir}\\Root4\\Dir1");
            Assert.IsFalse(System.IO.Directory.Exists($"{appDir}\\Root4\\Dir1"));

            System.IO.Directory.Delete($"{appDir}\\Root4\\Dir2");
            Assert.IsFalse(System.IO.Directory.Exists($"{appDir}\\Root4\\Dir2"));

            System.IO.Directory.Delete($"{appDir}\\Root4");
            Assert.IsFalse(System.IO.Directory.Exists($"{appDir}\\Root4"));
        }

        /// <summary>
        /// Tests the Create method of the 
        /// <see cref="RyanPenfold.Utilities.IO.Directory" /> class.
        /// </summary>
        [TestMethod]
        public void Create()
        {
            // Get application path
            var appDir = Utilities.IO.UncPath.GetApplicationDirectory();

            // Create a directory
            Utilities.IO.Directory.Create($"{appDir}\\Root5\\Dir1");

            // Assert directory exists
            Assert.IsTrue(System.IO.Directory.Exists($"{appDir}\\Root5\\Dir1"));

            // Create a directory with the same name
            Utilities.IO.Directory.Create($"{appDir}\\Root5\\Dir1");

            // Assert directory still exists
            Assert.IsTrue(System.IO.Directory.Exists($"{appDir}\\Root5\\Dir1"));

            // Clean up
            Utilities.IO.Directory.Delete($"{appDir}\\Root5\\Dir1");
            Assert.IsFalse(System.IO.Directory.Exists($"{appDir}\\Root5\\Dir1"));

            Utilities.IO.Directory.Delete($"{appDir}\\Root5");
            Assert.IsFalse(System.IO.Directory.Exists($"{appDir}\\Root5"));
        }

        /// <summary>
        /// Tests the Create method of the 
        /// <see cref="RyanPenfold.Utilities.IO.Directory" /> class.
        /// </summary>
        [TestMethod]
        public void CreateWithException()
        {
            // find a drive that doesn't exist
            var driveLetter = Common.FindDriveLetterThatDoesntExist();

            if (string.IsNullOrEmpty(driveLetter))
            {
                return;
            }

            // Attempt to create a directory on a drive that doesn't exist
            Assert.IsFalse(Utilities.IO.Directory.Create($"{driveLetter}directory\\"));
        }

        /// <summary>
        /// Tests the Delete method of the 
        /// <see cref="RyanPenfold.Utilities.IO.Directory" /> class.
        /// </summary>
        [TestMethod]
        public void Delete()
        {
            // Get application path
            var appDir = Utilities.IO.UncPath.GetApplicationDirectory();

            // Create a directory
            System.IO.Directory.CreateDirectory($"{appDir}\\Root5\\Dir1");

            // Assert directory exists
            Assert.IsTrue(System.IO.Directory.Exists($"{appDir}\\Root5\\Dir1"));

            // Create a file
            using (System.IO.File.Create($"{appDir}\\Root5\\File1.txt"))
            {
            }

            // Assert directory exists
            Assert.IsTrue(System.IO.File.Exists($"{appDir}\\Root5\\File1.txt"));

            // Attempt to delete directory
            Utilities.IO.Directory.Delete($"{appDir}\\Root5");

            // Assert directory no longer exists
            Assert.IsFalse(System.IO.Directory.Exists($"{appDir}\\Root5"));
        }

        /// <summary>
        /// Tests the IsEmpty method of the 
        /// <see cref="RyanPenfold.Utilities.IO.Directory" /> class.
        /// </summary>
        [TestMethod]
        public void IsEmpty()
        {
            // Get application path
            var appDir = Utilities.IO.UncPath.GetApplicationDirectory();

            // Create a directory
            System.IO.Directory.CreateDirectory($"{appDir}\\Root7\\Dir1");

            // Create another directory
            System.IO.Directory.CreateDirectory($"{appDir}\\Root7\\Dir2");

            // Create a file
            using (System.IO.File.Create($"{appDir}\\Root7\\Dir2\\File1.txt"))
            {
                Assert.IsTrue(System.IO.File.Exists($"{appDir}\\Root7\\Dir2\\File1.txt"));
            }

            // Dir1 should be empty
            Assert.IsTrue(Utilities.IO.Directory.IsEmpty($"{appDir}\\Root7\\Dir1"));

            // Dir2 should not be empty
            Assert.IsFalse(Utilities.IO.Directory.IsEmpty($"{appDir}\\Root7\\Dir2"));

            // Clean up
            Utilities.IO.File.Delete($"{appDir}\\Root7\\Dir2\\File1.txt");
            Assert.IsFalse(System.IO.File.Exists($"{appDir}\\Root7\\Dir2\\File1.txt"));

            Utilities.IO.Directory.Delete($"{appDir}\\Root7\\Dir1");
            Assert.IsFalse(System.IO.Directory.Exists($"{appDir}\\Root7\\Dir1"));

            Utilities.IO.Directory.Delete($"{appDir}\\Root7\\Dir2");
            Assert.IsFalse(System.IO.Directory.Exists($"{appDir}\\Root7\\Dir2"));

            Utilities.IO.Directory.Delete($"{appDir}\\Root7");
            Assert.IsFalse(System.IO.Directory.Exists($"{appDir}\\Root7"));
        }
    }
}
