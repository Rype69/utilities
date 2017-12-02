// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Array.cs" company="Inspire IT Ltd">
//   Copyright © Inspire IT Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities
{
    /// <summary>
    /// Provides utility methods for the System.Array class
    /// </summary>
    public static class Array
    {
        /// <summary>
        /// Gets the lowest id of an empty element in an array.
        /// </summary>
        /// <param name="arrayIn">
        /// The array to search.
        /// </param>
        /// <returns>
        /// The lowest id of an empty element in an array.
        /// </returns>
        public static int GetLowestEmptyId(this System.Array arrayIn)
        {
            var intResult = -1;
            var intCount = 0;
            foreach (var o in arrayIn)
            {
                if (o == null && intResult == -1)
                {
                    intResult = intCount;
                    break;
                }

                intCount += 1;
            }

            return intResult;
        }

        /// <summary>
        /// Creates a string from each of the objects in a System.Array and concatenates them all together.
        /// </summary>
        /// <param name="array">
        /// The array to build a string from.
        /// </param>
        /// <param name="separator">
        /// The separator.
        /// </param>
        /// <returns>
        /// The concatenated string.
        /// </returns>
        public static string Concatenate(this System.Array array, string separator)
        {
            var result = new System.Text.StringBuilder();
            if (array != null)
            {
                for (var intCount = 0; intCount <= (array.Length - 1); intCount++)
                {
                    if (intCount > 0)
                    {
                        result.Append(separator);
                    }

                    result.Append(array.GetValue(intCount));
                }
            }

            return result.ToString();
        }
    }
}