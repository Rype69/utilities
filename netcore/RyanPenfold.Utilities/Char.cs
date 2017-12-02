// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Char.cs" company="Inspire IT Ltd">
//   Copyright © Inspire IT Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities
{
    /// <summary>
    /// Provides extension methods that operate on char values
    /// </summary>
    public static class Char
    {
        /// <summary>
        /// Determines whether a char is uppercase
        /// </summary>
        /// <param name="value">
        /// The char value
        /// </param>
        /// <returns>
        /// True if the char is uppercase, False otherwise.
        /// </returns>
        public static bool IsUpperCase(this char value)
        {
            return value >= 65 && value <= 90;
        }

        /// <summary>
        /// Remaps international character to an ASCII one
        /// </summary>
        /// <param name="c">The character to remap</param>
        /// <returns>A remapped character</returns>
        /// <remarks>Written by Jeff Atwood</remarks>
        public static string RemapInternationalToAscii(this char c)
        {
            var s = c.ToString().ToLowerInvariant();

            if ("àåáâäãåą".Contains(s))
            {
                return "a";
            }

            if ("èéêëę".Contains(s))
            {
                return "e";
            }

            if ("ìíîïı".Contains(s))
            {
                return "i";
            }

            if ("òóôõöøőð".Contains(s))
            {
                return "o";
            }

            if ("ùúûüŭů".Contains(s))
            {
                return "u";
            }

            if ("çćčĉ".Contains(s))
            {
                return "c";
            }

            if ("żźž".Contains(s))
            {
                return "z";
            }

            if ("śşšŝ".Contains(s))
            {
                return "s";
            }

            if ("ñń".Contains(s))
            {
                return "n";
            }

            if ("ýÿ".Contains(s))
            {
                return "y";
            }

            if ("ğĝ".Contains(s))
            {
                return "g";
            }

            if (c == 'ř')
            {
                return "r";
            }

            if (c == 'ł')
            {
                return "l";
            }

            if (c == 'đ')
            {
                return "d";
            }

            if (c == 'ß')
            {
                return "ss";
            }

            if (c == 'Þ')
            {
                return "th";
            }

            if (c == 'ĥ')
            {
                return "h";
            }

            if (c == 'ĵ')
            {
                return "j";
            }

            return string.Empty;
        }
    }
}
