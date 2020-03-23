// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsPrimaryKeyAttribute.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Attributes
{
    /// <summary>
    /// Provides the ability to decorate a property or field with a 
    /// attribute that denotes that it is a primary key.
    /// </summary>
    public class IsPrimaryKeyAttribute : System.Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IsPrimaryKeyAttribute"/> class.
        /// </summary>
        /// <param name="value">
        /// The value indicating whether the decorated field or property is a primary key.
        /// </param>
        public IsPrimaryKeyAttribute(bool value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the decorated field or property is a primary key.
        /// </summary>
        public bool Value { get; set; }
    }
}