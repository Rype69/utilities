// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataType.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit.Attributes
{
    using System.Collections.Generic;

    using Utilities.Attributes;

    /// <summary>
    /// Used for testing the 
    /// <see cref="ControlTypeAttribute" /> class.
    /// </summary>
    public class DataType
    {
        /// <summary>
        /// Gets or sets Field1.
        /// </summary>
        [ControlType("CheckBoxList", typeof(object), "Text", "Id", true, false)]
        public List<bool> Field1 { get; set; }
    }
}