// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StreamSerializer.cs" company="Ryan Penfold">
//     Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Runtime.Serialization
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;

    /// <summary>
    /// Serializes objects to, and deserializes objects from <see cref="Stream"/>s.
    /// </summary>
    public static class StreamSerializer
    {
        /// <summary>
        /// Serializes an object of type <see cref="T"/> to a <see cref="TStream"/> instance.
        /// </summary>
        /// <typeparam name="T">
        /// The type of object to serialize to a <see cref="Stream"/>
        /// </typeparam>
        /// <typeparam name="TStream">
        /// The type of <see cref="Stream"/> to serialize to
        /// </typeparam>
        /// <param name="subject">
        /// An object to serialize
        /// </param>
        /// <param name="formatter">
        /// An instance to format serialized objects.
        /// </param>
        /// <returns>
        /// A <see cref="TStream"/> instance
        /// </returns>
        public static TStream ToStream<T, TStream>(this T subject, IFormatter formatter = null) where T : class where TStream : Stream, new()
        {
            // NULL-check the subject
            if (subject == null)
            {
                throw new ArgumentNullException(nameof(subject));
            }

            var stream = new TStream();

            if (formatter == null)
            {
                formatter = new BinaryFormatter();
            }

            formatter.Serialize(stream, subject);
            return stream;
        }

        /// <summary>
        /// Deserializes an object of type <see cref="T"/> from a <see cref="TStream"/> instance.
        /// </summary>
        /// <typeparam name="T">
        /// The type of object to deserialize from a <see cref="Stream"/>
        /// </typeparam>
        /// <typeparam name="TStream">
        /// The type of <see cref="Stream"/> to deserialize from
        /// </typeparam>
        /// <param name="stream">
        /// A <see cref="Stream"/> containing a serialized object
        /// </param>
        /// <param name="formatter">
        /// An instance to format serialized objects.
        /// </param>
        /// <returns>
        /// A <see cref="T"/>instance
        /// </returns>
        public static T FromStream<T, TStream>(this TStream stream, IFormatter formatter = null) where T : class where TStream : Stream, new()
        {
            // NULL-check the stream
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (formatter == null)
            {
                formatter = new BinaryFormatter();
            }

            stream.Seek(0, SeekOrigin.Begin);
            return formatter.Deserialize(stream) as T;
        }
    }
}
