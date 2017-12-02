// --------------------------------------------------------------------------------------------------------------------
// <copyright file="File.cs" company="Inspire IT Ltd">
//   Copyright © Inspire IT Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.IO
{
    using System.Linq;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Provides static methods for performing operations on files.
    /// </summary>
    public class File
    {
        /// <summary>
        /// Attempts to copy a file from the source path to the destination path.
        /// </summary>
        public static void CopyTo(string sourcePath, string destinationPath)
        {
            CopyFile(sourcePath, destinationPath, false);
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        static extern bool CopyFile(string lpExistingFileName, string lpNewFileName, bool bFailIfExists);

        /// <summary>
        /// Deletes a file, if it exists. Suppresses all exceptions.
        /// </summary>
        /// <param name="path">
        /// The path to the file to delete.
        /// </param>
        /// <returns>
        /// A boolean indicating whether the file was successfully deleted or not.
        /// </returns>
        public static bool Delete(string path)
        {
            var result = true;
            try
            {
                if (System.IO.File.Exists(path))
                {
                    DeleteFile(path);
                }
            }
            catch (System.Exception)
            {
                // Cannot delete file. Ensure any create statements
                // are wrapped within using statements so that
                // FileStreams are closed properly.                
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Deletes a file
        /// </summary>
        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteFile(string name);

        /// <summary>
        /// Traverses a directory tree to find the first instance of a file with the specified name.
        /// </summary>
        /// <param name="fileName">The name of the file to find.</param>
        /// <param name="directoryPath">The path of the root directory to search in.</param>
        /// <returns>
        /// A <see cref="string"/> containing the full file path to the first found instance of a file with the specified name.
        /// </returns>
        public static string Find(string fileName, string directoryPath)
        {
            var result = string.Empty;

            if (System.IO.Directory.GetFiles(directoryPath)
                .Any(f => f != null && 
                    string.Equals(System.IO.Path.GetFileName(f), fileName, System.StringComparison.OrdinalIgnoreCase)))
            {
                return System.IO.Path.Combine(directoryPath, fileName);
            }

            foreach (var nestedDirectoryPath in System.IO.Directory.GetDirectories(directoryPath))
            {
                result = Find(fileName, nestedDirectoryPath);
                if (!string.IsNullOrWhiteSpace(result))
                {
                    return result;
                }
            }

            return result;
        }

        /// <summary>
        /// Determines whether a file is empty.
        /// </summary>
        /// <param name="path">
        /// The path to the file.
        /// </param>
        /// <returns>
        /// A boolean value indicating whether the file is empty or not.
        /// </returns>
        public static bool IsEmpty(string path)
        {
            var result = true;
            if (System.IO.File.Exists(path))
            {
                var data = System.IO.File.ReadAllText(path);
                result = !string.IsNullOrEmpty(data) && data.Length > 0;
            }

            return result;
        }
    }
}
