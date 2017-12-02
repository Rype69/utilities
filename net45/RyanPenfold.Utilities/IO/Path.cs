// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Path.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.IO
{
    /// <summary>
    /// Provides utility functions relating to paths
    /// </summary>
    public class Path
    {
        /// <summary>
        /// Determines a unique path to save a file to.
        /// </summary>
        /// <param name="directoryPath">
        /// The path to a directory
        /// </param>
        /// <param name="filename">
        /// The name of a file
        /// </param>
        /// <returns>
        /// A unique file path
        /// </returns>
        public static string DetermineUniquePath(string directoryPath, string filename)
        {
            // NULL-check the directory path
            if (string.IsNullOrWhiteSpace(directoryPath))
            {
                throw new System.ArgumentNullException(nameof(directoryPath));
            }

            // NULL-check the file name
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new System.ArgumentNullException(nameof(filename));
            }

            // Verify the directory is present on disk
            if (!System.IO.Directory.Exists(directoryPath))
            {
                throw new System.IO.DirectoryNotFoundException($"Directory {directoryPath} not found");
            }
            
            // Remove any illegal characters from the filename
            var fileName = Filename.RemoveIllegalCharacters(filename);

            // Determine whether a file @ the initial path exists, if so, return the path
            var initialPath = System.IO.Path.Combine(directoryPath, filename);
            if (!System.IO.File.Exists(initialPath))
            {
                return initialPath;
            }

            // Generate new file path
            var saveFilePath = initialPath;
            long counter = 0;
            var originalFileName = System.IO.Path.GetFileNameWithoutExtension(fileName);
            var fileExtension = System.IO.Path.GetExtension(filename); // Get file extension including dot

            while (System.IO.File.Exists(saveFilePath))
            {
                counter++;
                saveFilePath = System.IO.Path.Combine(
                    directoryPath,
                    $"{originalFileName} ({counter}){fileExtension}");
            }

            // Return result
            return saveFilePath;
        }
    }
}
