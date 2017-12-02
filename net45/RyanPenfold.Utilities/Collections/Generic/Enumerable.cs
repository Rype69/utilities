// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Enumerable.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Collections.Generic
{
    using System.Linq;

    /// <summary>
    /// Provides extension methods for the System.Collections.Generic.IEnumerable interface.
    /// </summary>
    public static class Enumerable
    {
        /// <summary>
        /// Creates a string from an IEnumerable by converting them each to a string and then concatenating them all together.
        /// </summary>
        /// <param name="collection">
        /// The collection.
        /// </param>
        /// <param name="delimiter">
        /// A delimiter to go between each of the strings.
        /// </param>
        /// <param name="fieldName">
        /// The name of the field of each source object that contains the data for the array
        /// </param>
        /// <param name="propertyName">
        /// The name of the property of each source object that contains the data for the array
        /// </param>
        /// <param name="encaseInQuotes">
        /// Indicates whether to encase each array item in quotes
        /// </param>
        /// <returns>
        /// A string representation of all the objects.
        /// </returns>
        public static string ToString(this System.Collections.IEnumerable collection, string delimiter, string fieldName = null, string propertyName = null, bool encaseInQuotes = false)
        {
            if (!string.IsNullOrWhiteSpace(fieldName) && !string.IsNullOrWhiteSpace(propertyName))
            {
                throw new System.ArgumentException("Both parameters \"fieldName\" and \"propertyName\" must not be set.");
            }

            var builder = new System.Text.StringBuilder();

            if (collection != null)
            {
                foreach (var item in collection.Cast<object>().Where(item => item != null))
                {
                    var stringToWrite = item.ToString();

                    if (!string.IsNullOrWhiteSpace(fieldName))
                    {
                        var fieldInfo = item.GetType().GetField(fieldName);
                        if (fieldInfo == null)
                        {
                            continue;
                        }

                        var fieldValue = fieldInfo.GetValue(item);

                        if (fieldValue != null)
                        {
                            stringToWrite = fieldValue.ToString();
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(propertyName))
                    {
                        var propertyInfo = item.GetType().GetProperty(propertyName);
                        if (propertyInfo == null)
                        {
                            continue;
                        }

                        var propertyValue = propertyInfo.GetValue(item);

                        if (propertyValue != null)
                        {
                            stringToWrite = propertyValue.ToString();
                        }
                    }

                    if (builder.Length > 0)
                    {
                        builder.Append(delimiter);
                    }

                    if (encaseInQuotes)
                    {
                        builder.Append("\"");
                    }

                    builder.Append(stringToWrite);

                    if (encaseInQuotes)
                    {
                        builder.Append("\"");
                    }
                }
            }

            return builder.ToString();
        }
    }
}
