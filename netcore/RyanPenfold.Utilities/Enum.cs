// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Enum.cs" company="Inspire IT Ltd">
//   Copyright © Inspire IT Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities
{
    /// <summary>
    /// Provides extension methods that operate on <see cref="System.Enum"/> values.
    /// </summary>
    public static class Enum
    {
        /// <summary>
        /// Converts a string value to a <see cref="System.Enum"/>.
        /// </summary>
        /// <param name="value">
        /// The string value.
        /// </param>
        /// <typeparam name="T">
        /// The Type of <see cref="System.Enum"/>
        /// </typeparam>
        /// <returns>
        /// An <see cref="System.Enum"/> value parsed from a string.
        /// </returns>
        /// <exception cref="System.Exception">
        /// Exception is thrown if the given string value is not valid for the specified type of enumeration.
        /// </exception>
        public static System.Enum ToEnum<T>(this string value)
        {
            System.Enum result = null;
            switch (System.Enum.IsDefined(typeof(T), value))
            {
                case true:
                    result = (System.Enum)System.Enum.Parse(typeof(T), value, true);
                    break;
                case false:
                    throw new System.Exception($"\"{value}\" is not a valid value for type {typeof(T).Name}.");
            }

            return result;
        }
    }
}
