// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MappedDataType.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit.Attributes
{
    using RyanPenfold.Utilities.Attributes;

    /// <summary>
    /// Used for testing the 
    /// <see cref="RyanPenfold.Utilities.Attributes.IsPrimaryKeyAttribute" /> class.
    /// </summary>
    public class MappedDataType
    {
        /// <summary>
        /// Gets or sets ID.
        /// </summary>
        [IsPrimaryKey(true)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Text.
        /// </summary>
        [IsPrimaryKey(false)]
        public int Text { get; set; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        public int Description { get; set; }
    }
}
