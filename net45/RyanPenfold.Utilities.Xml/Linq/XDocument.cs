// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XDocument.cs" company="Inspire IT Ltd">
//   Copyright © Ryan Penfold. All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Xml.Linq
{
    using System.IO;

    /// <summary>
    /// Provides extension methods for the <see cref="System.Xml.Linq.XDocument"/> type.
    /// </summary>
    public static class XDocument
    {
        /// <summary>
        /// Formats an <see cref="System.Xml.Linq.XDocument"/>.
        /// </summary>
        /// <param name="doc">The document to format.</param>
        /// <returns>
        /// A formatted XML document <see cref="string"/>.
        /// </returns>
        public static string Format(this System.Xml.Linq.XDocument doc)
        {
            var sb = new System.Text.StringBuilder();

            var xw = new System.Xml.XmlTextWriter(new StringWriter(sb)) { Formatting = System.Xml.Formatting.Indented };
            doc.Save(xw);

            return sb.ToString();
        }
    }
}
