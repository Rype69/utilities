// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Hash.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Security.Cryptography
{
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Provides hashing functionality
    /// </summary>
    public class Hash
    {
        /// <summary>
        /// Generates a hash for a given object
        /// </summary>
        /// <param name="obj">An <see cref="object"/> to generate a hash for</param>
        /// <returns>A hash</returns>
        public static string Generate(object obj)
        {
            // NULL-check obj
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            // Create a new instance of the ASCIIEncoding class to pass to the overload to
            // convert the string into an array of ASCII bytes.
            var encoding = new ASCIIEncoding();

            // Result variable with initial encrypt
            var hash = string.Format(
                                "{2}{1}{0}{1}{2}", 
                                Uri.EscapeUriString(obj.ToString()), 
                                obj.GetHashCode(), 
                                "RyanPenfold.com");

            // Loop through a set of hash algorithm types, generate a hash and return result
            return new[] 
            { 
                typeof(SHA512Managed),
                typeof(MD5CryptoServiceProvider),
                typeof(RIPEMD160Managed),
                typeof(SHA384Managed)
            }.Aggregate(hash, (current, hashAlgorithmType) => Generate(current, Activator.CreateInstance(hashAlgorithmType) as HashAlgorithm, encoding));
        }

        /// <summary>
        /// Verifies a hash for a given object
        /// </summary>
        /// <param name="hash">A hash to verify</param>
        /// <param name="obj">An <see cref="object"/> to verify a hash of</param>
        /// <returns>A value indicating whether the hash is correct</returns>
        public static bool Verify(string hash, object obj)
        {
            // NULL-check hash
            if (string.IsNullOrWhiteSpace(hash))
            {
                throw new ArgumentNullException(nameof(hash));
            }

            // NULL-check obj
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            // Make comparison and return result
            return string.Equals(hash, Generate(obj));
        }

        /// <summary>
        /// Generates a hash for a given input string
        /// </summary>
        /// <param name="input">A <see cref="string"/> to generate a hash for</param>
        /// <param name="hashGenerator">The type of hash generator to use</param>
        /// <param name="encoding">An instance of <see cref="Encoding"/> to convert the string into an array of bytes.</param>
        /// <returns>A hash</returns>
        private static string Generate(string input, HashAlgorithm hashGenerator, Encoding encoding)
        {
            // Convert the string into an array of bytes.
            var messageBytes = encoding.GetBytes(input);

            // Create the hash value from the array of bytes.
            var hashValue = hashGenerator.ComputeHash(messageBytes);

            // Create new string builder
            var hashStringBuilder = new StringBuilder();

            // Create a string from the hash
            foreach (var characterCode in hashValue)
            {
                hashStringBuilder.Append(Convert.ToChar(characterCode));
            }

            // Return result
            return hashStringBuilder.ToString();
        }
    }
}
