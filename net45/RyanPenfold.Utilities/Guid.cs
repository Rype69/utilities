// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Guid.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities
{
    /// <summary>
    /// Provides extension methods for instances of the <see cref="System.Guid"/> type.
    /// </summary>
    public static class Guid
    {
        /// <summary>
        /// <see cref="System.Guid"/> byte order.
        /// </summary>
        private static readonly int[] GuidByteOrder = { 15, 14, 13, 12, 11, 10, 9, 8, 6, 7, 4, 5, 0, 1, 2, 3 };

        /// <summary>
        /// Increments a <see cref="System.Guid"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>A <see cref="System.Guid"/>.</returns>
        public static System.Guid Increment(this System.Guid value)
        {
            var bytes = value.ToByteArray();
            var carry = true;
            for (var i = 0; i < GuidByteOrder.Length && carry; i++)
            {
                var index = GuidByteOrder[i];
                var oldValue = bytes[index]++;
                carry = oldValue > bytes[index];
            }

            return new System.Guid(bytes);
        }
    }
}
