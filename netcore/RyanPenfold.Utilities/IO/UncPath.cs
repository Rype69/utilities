// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UncPath.cs" company="Inspire IT Ltd">
//   Copyright © Inspire IT Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.IO
{
    /// <summary>
    /// Provides static methods for operations on string representations of UNC paths.
    /// </summary>
    public static class UncPath
    {
        /*
        /// <summary>
        /// Gets the path of the application directory.
        /// </summary>
        /// <returns>
        /// The path of the application directory
        /// </returns>
        public static string GetApplicationDirectory()
        {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
        }
        */

        /// <summary>
        /// Builds a UNC path by concatenating the root path and relative path strings.
        /// </summary>
        /// <param name="rootPath">
        /// The root path.
        /// </param>
        /// <param name="path">
        /// The relative path.
        /// </param>
        /// <param name="delimiter">
        /// The delimiter.
        /// </param>
        /// <returns>
        /// The full path.
        /// </returns>
        public static string Build(string rootPath, string path, string delimiter = "/")
        {
            var builder = new System.Text.StringBuilder(rootPath);
            if (!builder.ToString().EndsWith(delimiter))
            {
                builder.Append(delimiter);
            }

            builder.Append(path);
            if (!builder.ToString().EndsWith(delimiter))
            {
                builder.Append(delimiter);
            }

            return builder.ToString();
        }

        /// <summary>
        /// Gets the leftmost namespace of a UNC path string.
        /// </summary>
        /// <param name="path">
        /// The UNC path.
        /// </param>
        /// <param name="separator">
        /// The separator / delimiter.
        /// </param>
        /// <returns>
        /// The leftmost namespace of a UNC path string.
        /// </returns>
        public static string GetLeftmostnamespace(this string path, string separator)
        {
            return Uri.GetLeftmostnamespace(path, separator);
        }

        /// <summary>
        /// Gets the rightmost namespace of a UNC path string.
        /// </summary>
        /// <param name="path">
        /// The UNC path.
        /// </param>
        /// <param name="separator">
        /// The separator / delimiter.
        /// </param>
        /// <returns>
        /// The rightmost namespace of a UNC path string.
        /// </returns>
        public static string GetRightmostnamespace(this string path, string separator)
        {
            return Uri.GetRightmostnamespace(path, separator);
        }
    }
}
