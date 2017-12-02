// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Uri.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities
{
    using System;

    /// <summary>
    /// Provides extension methods for <see cref="System.Uri" /> objects
    /// </summary>
    public static class Uri
    {
        /// <summary>
        /// Gets the leftmost namespace of a URI string.
        /// </summary>
        /// <param name="uriString">
        /// The uri string.
        /// </param>
        /// <param name="separator">
        /// The separator.
        /// </param>
        /// <returns>
        /// The leftmost namespace of a URI string.
        /// </returns>
        public static string GetLeftmostnamespace(this string uriString, string separator)
        {
            var strReturn = uriString;
            var intCharCount = uriString.IndexOf(separator, StringComparison.Ordinal);
            if (intCharCount > 0)
            {
                strReturn = uriString.Substring(0, intCharCount);
            }
            else if (intCharCount == 0)
            {
                strReturn = string.Empty;
            }

            return strReturn;
        }

        /// <summary>
        /// Gets the rightmost namespace of a URI string.
        /// </summary>
        /// <param name="uriString">
        /// The uri string.
        /// </param>
        /// <param name="separator">
        /// The separator.
        /// </param>
        /// <returns>
        /// The rightmost namespace of a URI string.
        /// </returns>
        public static string GetRightmostnamespace(string uriString, string separator)
        {
            return uriString.Substring(uriString.LastIndexOf(separator, StringComparison.Ordinal) + 1, uriString.Length - (uriString.LastIndexOf(separator, StringComparison.Ordinal) + 1));
        }

        /// <summary>
        /// Replaces spaces with hyphens, removes all other non-alphanumeric characters, 
        ///  and replaces diacritic characters with non-accented equivalents.
        /// </summary>
        /// <param name="str">The <see cref="System.String"/> to sanitise</param>
        /// <returns>A sanitised <see cref="System.String"/> Uri path</returns>
        public static string ToSanitisedUriPath(string str)
        {
            // Result variable
            var parsed = str;

            if (!string.IsNullOrWhiteSpace(parsed))
            {
                parsed = System.Uri.UnescapeDataString(parsed);
            }

            if (parsed != null)
            {
                parsed = parsed.Replace(" ", "-");
                while (parsed.Contains("--"))
                {
                    parsed = parsed.Replace("--", "-");
                }

                parsed = parsed.RemoveDiacritics();
                parsed = parsed.Replace("[^a-zA-Z0-9-]", string.Empty);
            }

            // Return result
            return parsed;
        }

        /// <summary>
        /// Extracts the portion of a URI string that precedes the parameters.
        /// </summary>
        /// <param name="uriString">
        /// The uri string.
        /// </param>
        /// <returns>
        /// The portion of a URI string that precedes the parameters.
        /// </returns>
        public static string ToUriStringNoParameters(string uriString)
        {
            string strReturn = null;
            
            if (uriString != null)
            {
                strReturn = GetLeftmostnamespace(uriString, "?");
            }

            return strReturn;
        }
    }
}
