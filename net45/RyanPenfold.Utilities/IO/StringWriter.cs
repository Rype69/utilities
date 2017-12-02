// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringWriter.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.IO
{
    /// <summary>
    /// A <see cref="System.IO.StringWriter"/> with encoding
    /// </summary>
    public class StringWriter : System.IO.StringWriter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringWriter"/> class. 
        /// </summary>
        /// <param name="encoding">
        /// The encoding of the string writer
        /// </param>
        public StringWriter(System.Text.Encoding encoding)
        {
            this.Encoding = encoding;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringWriter"/> class 
        /// that writes to the specified <see cref="System.Text.StringBuilder"/>.
        /// </summary>
        /// <param name="stringBuilder">
        /// The <see cref="System.Text.StringBuilder"/> to write to
        /// </param>
        /// <param name="encoding">
        /// The encoding of the string writer
        /// </param>
        public StringWriter(System.Text.StringBuilder stringBuilder, System.Text.Encoding encoding)
            : base(stringBuilder)
        {
            this.Encoding = encoding;
        }

        /// <summary>
        /// Gets the encoding of the string writer
        /// </summary>
        public override System.Text.Encoding Encoding { get; }
    }
}
