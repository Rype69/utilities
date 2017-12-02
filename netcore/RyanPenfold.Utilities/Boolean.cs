// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Boolean.cs" company="Inspire IT Ltd">
//   Copyright © Inspire IT Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities
{
    /// <summary>
    /// Provides extension methods that operate on boolean values
    /// </summary>
    public static class Boolean
    {
        /// <summary>
        /// Converts a boolean to a byte.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// 1 if value is True, 0 if it is false.
        /// </returns>
        public static byte ToByte(this bool value)
        {
            return value ? (byte)1 : (byte)0;
        }
    }
}
