// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AliasAttribute.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Attributes
{
    /// <summary>
    /// Provides the ability to give a type an alias.
    /// </summary>
    public class AliasAttribute : System.Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AliasAttribute"/> class.
        /// </summary>
        /// <param name="value">
        /// The alias value.
        /// </param>
        public AliasAttribute(string value)
        {
            this.Value = value;
        }
        
        /// <summary>
        /// Gets or sets the value of the attribute.
        /// </summary>
        public string Value { get; set; }
    }
}
