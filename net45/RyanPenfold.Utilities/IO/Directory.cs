// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Directory.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.IO
{
    using System.Linq;

    /// <summary>
    /// Provides static methods for performing operations on directories.
    /// </summary>
    public static class Directory
    {
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public class SecurityAttributes
        {
            public int nLength;
            public System.IntPtr pSecurityDescriptor;
            public int bInheritHandle;
        }

        /// <summary>
        /// Clears the contents of a directory at the specified location.
        /// </summary>
        /// <param name="path">The path to the directory.</param>
        public static void Clear(string path)
        {
            // NULL-check the path parameter
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new System.ArgumentNullException(nameof(path));
            }

            // If the directory doesn't exist, return
            if (!System.IO.Directory.Exists(path))
            {
                return;
            }

            // Delete all the files in this directory
            foreach (var strFile in System.IO.Directory.GetFiles(path))
            {
                System.IO.File.Delete(strFile);
            }

            // Delete all the directories in this directory
            foreach (var strDir in System.IO.Directory.GetDirectories(path))
            {
                Clear(strDir);
            }
        }

        /// <summary>
        /// Clears a directory at the given location if it exists. 
        /// If it doesn't exist, the directory is created.
        /// </summary>
        /// <param name="path">The path to the directory</param>
        public static void ClearOrCreate(string path)
        {
            // NULL-check the path parameter
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new System.ArgumentNullException(nameof(path));
            }

            // Delete it and all it//s contents if it exists
            if (System.IO.Directory.Exists(path))
            {
                Clear(path);
            }

            // Create it!
            if (!System.IO.Directory.Exists(path))
            {
                CreateDirectory(path);
            }
        }

        /// <summary>
        /// Copies a directory, including all files and sub directories.
        /// </summary>
        /// <param name="sourceDirectoryPath">The path to the source directory.</param>
        /// <param name="destinationDirectoryPath">The path to the destination directory.</param>
        /// <remarks>
        /// Based on the example @ https://msdn.microsoft.com/en-us/library/bb762914(v=vs.110).aspx
        /// </remarks>
        public static void Copy(string sourceDirectoryPath, string destinationDirectoryPath)
        {
            // Get the subdirectories for the specified directory.
            var sourceDirectory = new System.IO.DirectoryInfo(sourceDirectoryPath);

            if (!sourceDirectory.Exists)
            {
                throw new System.IO.DirectoryNotFoundException(
                    $"Source directory does not exist or could not be found: {sourceDirectoryPath}");
            }

            // If the destination directory doesn't exist, create it.
            if (!System.IO.Directory.Exists(destinationDirectoryPath))
            {
                CreateDirectory(destinationDirectoryPath);
            }

            // Get the files in the directory and copy them to the new location.
            foreach (var file in sourceDirectory.GetFiles())
            {
                file.CopyTo(System.IO.Path.Combine(destinationDirectoryPath, file.Name), false);
            }

            // Copy the subdirectories and their contents to new location.
            foreach (var subdirPath in System.IO.Directory.GetDirectories(sourceDirectoryPath))
            {
                // TODO: System.IO.Path.GetDirectoryName throws PathTooLongException
                Copy(subdirPath, System.IO.Path.Combine(destinationDirectoryPath, System.IO.Path.GetDirectoryName(subdirPath)));
            }
        }

        /// <summary>
        /// Counts all the objects (files and directories) 
        /// within a specified directory.
        /// </summary>
        /// <param name="path">
        /// The path to the directory to find the objects to count.
        /// </param>
        /// <param name="recursive">
        /// Indicates whether the search should extend to all of the 
        /// directories within that specified.
        /// </param>
        /// <returns>
        /// A count of all of the objects (files and directories) 
        /// within the specified directory.
        /// </returns>
        public static int CountObjects(string path, bool recursive = false)
        {
            if (!System.IO.Directory.Exists(path))
            {
                throw new System.IO.DirectoryNotFoundException($"Directory {path} not found.");
            }

            var sourceDirectory = new System.IO.DirectoryInfo(path);
            var directories = sourceDirectory.GetDirectories();
            var files = sourceDirectory.GetFiles();

            var result = directories.Length + files.Length;
            if (recursive)
            {
                foreach (var directory in directories)
                {
                    result += CountObjects(directory.FullName, true);
                }
            }

            return result;
        }

        /// <summary>
        /// Creates a directory
        /// </summary>
        /// <param name="path">
        /// The path of the directory to create
        /// </param>
        /// <returns>
        /// A boolean value indicating whether the create was successful or not.
        /// </returns>
        public static bool Create(string path)
        {
            var result = true;
            try
            {
                if (!System.IO.Directory.Exists(path))
                {
                    CreateDirectory(path);
                }
            }
            catch (System.Exception)
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Attempts to create a directory.
        /// </summary>
        /// <param name="path">The path of a directory to create.</param>
        /// <returns>A <see cref="bool"/>.</returns>
        /// <remarks>Uses the p/invoke method so there's no restriction on path lengths.</remarks>
        public static bool CreateDirectory(string path)
        {
            var result = true;

            var pathSegments = path.Split(new[] { System.IO.Path.DirectorySeparatorChar }, System.StringSplitOptions.RemoveEmptyEntries);

            for (var count = 0; count < pathSegments.Length; count++)
            {
                var pathStringBuilder = new System.Text.StringBuilder();
                for (var segmentId = 0; segmentId <= count; segmentId++)
                {
                    if (string.IsNullOrWhiteSpace(pathSegments[segmentId]))
                    {
                        continue;
                    }

                    pathStringBuilder.Append(System.IO.Path.Combine(pathStringBuilder.ToString(), System.IO.Path.DirectorySeparatorChar.ToString(), pathSegments[segmentId]));
                }

                if (!System.IO.Directory.Exists(pathStringBuilder.ToString()))
                {
                    result = result && 
                        CreateDirectory(string.Concat(@"\\?\", pathStringBuilder.ToString()), null);
                }
            }

            return result;            
        }

        /// <summary>
        /// Attempts to create a directory.
        /// </summary>
        /// <param name="lpPathName">A path.</param>
        /// <param name="lpSecurityAttributes">Some security attributes.</param>
        /// <returns>A <see cref="bool"/>.</returns>
        [System.Runtime.InteropServices.DllImport("kernel32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern bool CreateDirectory(string lpPathName, SecurityAttributes lpSecurityAttributes);

        /// <summary>
        /// Deletes all the files and directories within the given directory recursively.
        /// </summary>
        /// <param name="path">
        /// The path of the root directory
        /// </param>
        public static void Delete(string path)
        {
            // Delete all the files in this directory
            foreach (var strFile in System.IO.Directory.GetFiles(path))
            {
                File.Delete(strFile);
            }

            // Delete all the directories in this directory
            foreach (var strDir in System.IO.Directory.GetDirectories(path))
            {
                // Delete the sub directory @ "strDir" - attempt #1
                try
                {
                    RemoveDirectory(strDir);
                }
                catch
                {
                }

                // Delete the sub directory @ "strDir" - attempt #2
                try
                {
                    System.IO.Directory.Delete(strDir, true);
                }
                catch
                {
                }
            }

            // Delete the root directory @ path - attempt #1
            try
            {
                RemoveDirectory(path);
            }
            catch
            {
            }

            // Delete the root directory @ path - attempt #2
            try
            {
                System.IO.Directory.Delete(path, true);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Recursively gets a list of all of the directories in a specified path.
        /// </summary>
        /// <param name="path">
        /// The path to search for the directories.
        /// </param>
        /// <returns>
        /// A list of all of the directories in the specified path.
        /// </returns>
        public static System.Collections.Generic.List<string> GetDirectories(string path)
        {
            var results = new System.Collections.Generic.List<string>();
            foreach (var s in System.IO.Directory.GetDirectories(path))
            {
                results.AddRange(GetDirectories(s));
                results.Add(s);
            }

            return results;
        }

        /// <summary>
        /// Gets a list of all the files within a specified directory and within all the nested directories.
        /// </summary>
        /// <param name="path">
        /// The path of the directory in which to search for files.
        /// </param>
        /// <returns>
        /// A list of all the files within the specified directory and all the nested directories.
        /// </returns>
        public static System.Collections.Generic.List<string> GetFiles(string path)
        {
            var files = new System.Collections.Generic.List<string>();
            foreach (var s in System.IO.Directory.GetDirectories(path))
            {
                files.AddRange(GetFiles(s));
            }

            files.AddRange(System.IO.Directory.GetFiles(path));
            return files;
        }

        /// <summary>
        /// Gets all the objects (files and directories) within a specified directory path.
        /// </summary>
        /// <param name="path">
        /// The directory path in which to search for objects.
        /// </param>
        /// <returns>
        /// The an array of all the objects (files and directories) within 
        /// a specified directory path.
        /// </returns>
        public static object[] GetObjects(string path)
        {
            // Get all the files
            var results = System.IO.Directory.GetFiles(path).Select(s => new System.IO.FileInfo(s)).Cast<object>().ToList();

            // Get all the directories
            results.AddRange(System.IO.Directory.GetDirectories(path).Select(s => new System.IO.DirectoryInfo(s)));

            // Return results
            return results.ToArray();
        }

        /// <summary>
        /// Determines whether a directory is empty
        /// </summary>
        /// <param name="path">
        /// The path to the directory to check for objects.
        /// </param>
        /// <returns>
        /// A boolean value indicating whether the specified directory is empty or not.
        /// </returns>
        public static bool IsEmpty(string path)
        {
            var result = true;
            if (System.IO.Directory.Exists(path))
            {
                result = CountObjects(path) == 0;
            }

            return result;
        }

        /// <summary>
        /// Removes a directory
        /// </summary>
        [System.Runtime.InteropServices.DllImport("kernel32.dll", CharSet = System.Runtime.InteropServices.CharSet.Unicode, SetLastError = true)]
        public static extern bool RemoveDirectory(string lpPathName);
    }
}
