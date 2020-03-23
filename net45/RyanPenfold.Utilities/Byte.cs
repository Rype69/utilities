// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Byte.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities
{
    /// <summary>
    /// Provides extension methods that operate on byte values
    /// </summary>
    public static class Byte
    {
        /// <summary>
        /// Converts a byte to a boolean.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// True if value is 1, false if it is 0.
        /// </returns>
        public static bool ToBoolean(this byte value)
        {
            return value == 1;
        }
    }
}
