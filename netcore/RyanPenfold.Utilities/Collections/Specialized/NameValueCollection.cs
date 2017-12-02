/*
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NameValueCollection.cs" company="Inspire IT Ltd">
//   Copyright © Inspire IT Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Collections.Specialized
{
    /// <summary>
    /// Provides extension methods for the 
    /// <see cref="System.Collections.Specialized.NameValueCollection" /> class.
    /// </summary>
    public static class NameValueCollection
    {
        /// <summary>
        /// Copies a <see cref="System.Collections.Specialized.NameValueCollection" /> object.
        /// </summary>
        /// <param name="subject">
        /// The collection to copy.
        /// </param>
        /// <returns>
        /// A <see cref="System.Collections.Specialized.NameValueCollection" /> object.
        /// </returns>
        public static System.Collections.Specialized.NameValueCollection Copy(this System.Collections.Specialized.NameValueCollection subject)
        {
            System.Collections.Specialized.NameValueCollection result = null;
            if (subject != null)
            {
                result = new System.Collections.Specialized.NameValueCollection();
                foreach (var key in subject.AllKeys)
                {
                    result[key] = subject[key];
                }
            }

            return result;
        }

        /// <summary>
        /// Returns a <see cref="string"/> that is converted from the contents of a <see cref="NameValueCollection"/> instance.
        /// </summary>
        /// <param name="nameValueCollection">
        /// A <see cref="NameValueCollection"/> to convert to a <see cref="string"/>.
        /// </param>
        /// <returns>
        /// A <see cref="string"/> that is converted from the contents of a <see cref="NameValueCollection"/> instance.
        /// </returns>
        public static string Parse(this System.Collections.Specialized.NameValueCollection nameValueCollection)
        {
            // Check parameter for null
            if (nameValueCollection == null)
            {
                throw new System.ArgumentNullException(nameof(nameValueCollection));
            }

            // Result variable
            var result = new System.Text.StringBuilder();

            // Loop through each of the keys and 
            // append the key & data to the result variable.
            foreach (var key in nameValueCollection.AllKeys)
            {
                // If there is already data in the result variable, 
                // append an ampersand
                if (result.Length > 0)
                {
                    result.Append("&");
                }

                // Append the key, equals, and encoded data
                result.Append(key);
                result.Append("=");
                result.Append(nameValueCollection[key]);
            }

            // Return result
            return result.ToString();
        }
    }
}
*/