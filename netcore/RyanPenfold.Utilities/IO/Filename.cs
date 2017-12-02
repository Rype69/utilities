// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Filename.cs" company="Inspire IT Ltd">
//   Copyright © Inspire IT Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.IO
{
    /// <summary>
    /// Provides static methods for performing operations on filenames.
    /// </summary>
    /// <remarks>Ryan Penfold 21st November 2012</remarks>
    public class Filename
    {
        /// <summary>
        /// Removes illegal characters from a filename
        /// </summary>
        /// <param name="filename">The filename to sanitise</param>
        /// <returns>A filename string with all the illegal characters removed</returns>
        /// <remarks>Ryan Penfold 21st November 2012</remarks>
        public static string RemoveIllegalCharacters(string filename)
        {
            var regexSearch = $"{System.IO.Path.GetInvalidFileNameChars()}{System.IO.Path.GetInvalidPathChars()}";
            var r = new System.Text.RegularExpressions.Regex(
                $"[{System.Text.RegularExpressions.Regex.Escape(regexSearch)}]");
            return r.Replace(filename, string.Empty);
        }
    }
}