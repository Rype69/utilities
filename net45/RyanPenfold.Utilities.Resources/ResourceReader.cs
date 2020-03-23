// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResourceReader.cs" company="Inspire IT Ltd">
//   Copyright © Inspire IT Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Resources
{
    using System;
    using System.Collections;
    using System.Resources;

    /// <summary>
    /// Provides functionality for reading data from resource files.
    /// </summary>
    public class ResourceReader : IResourceReader
    {
        /// <summary>
        /// A set of resources.
        /// </summary>
        private readonly IDictionary resources;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceReader"/> class. 
        /// </summary>
        /// <param name="resources">
        /// A set of resources.
        /// </param>
        public ResourceReader(IDictionary resources)
        {
            this.resources = resources;
        }

        /// <summary>
        /// Returns an enumerator for this <see cref="ResourceReader"/> object.
        /// </summary>
        /// <returns>An enumerator for this <see cref="ResourceReader"/> object.</returns>
        IDictionaryEnumerator IResourceReader.GetEnumerator()
        {
            return this.resources.GetEnumerator();
        }

        /// <summary>
        /// Releases all operating system resources associated with this <see cref="ResourceReader"/> object.
        /// </summary>
        void IResourceReader.Close()
        {
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="IEnumerator"/>.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.resources.GetEnumerator();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        void IDisposable.Dispose()
        {            
        }
    }
}
