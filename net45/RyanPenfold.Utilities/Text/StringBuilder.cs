// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringBuilder.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Text
{
    using System;

    /// <summary>
    /// Provides extension methods for <see cref="System.Text.StringBuilder"/> instances.
    /// </summary>
    public static class StringBuilder
    {
        /// <summary>
        /// Appends a copy of the specified string to an instance of a <see cref="System.Text.StringBuilder"/>
        /// with a preceding delimiter if the instance already contains text.
        /// </summary>
        /// <param name="builder">
        /// The <see cref="System.Text.StringBuilder"/> to append to.
        /// </param>
        /// <param name="value">
        /// The string to append.
        /// </param>
        /// <param name="delimiter">
        /// A delimiter
        /// </param>
        /// <param name="trim">
        /// Denotes whether to trim the value before appending it
        /// </param>
        public static void AppendWithDelimiter(this System.Text.StringBuilder builder, string value, string delimiter = " ", bool trim = false)
        {
            // NULL-check the System.Text.StringBuilder instance
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            // Determine whether the System.Text.StringBuilder instance has content, 
            // if it does, append the delimiter.
            if (builder.Length > 0)
            {
                builder.Append(delimiter);
            }

            // Append the value
            builder.Append(trim && value != null ? value.Trim() : value);
        }

        /// <summary>
        /// Appends a copy of the specified <see cref="System.Text.StringBuilder"/> to an instance of a <see cref="System.Text.StringBuilder"/>
        /// with a preceding delimiter if the instance already contains text.
        /// </summary>
        /// <param name="builder">
        /// The <see cref="System.Text.StringBuilder"/> to append to.
        /// </param>
        /// <param name="value">
        /// The string to append.
        /// </param>
        /// <param name="delimiter">
        /// A delimiter
        /// </param>
        public static void AppendWithDelimiter(this System.Text.StringBuilder builder, System.Text.StringBuilder value, string delimiter = " ")
        {
            // NULL-check the System.Text.StringBuilder instance
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            // Determine whether the System.Text.StringBuilder instance has content, 
            // if it does, append the delimiter.
            if (builder.Length > 0)
            {
                builder.Append(delimiter);
            }

            // Append the value
            builder.Append(value);
        }
    }
}
