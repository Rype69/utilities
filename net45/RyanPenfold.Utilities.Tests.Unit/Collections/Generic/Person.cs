// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Person.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit.Collections.Generic
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Used for testing the 
    /// <see cref="RyanPenfold.Utilities.Collections.Generic.List" />
    /// and the 
    /// <see cref="RyanPenfold.Utilities.Collections.Generic.Enumerable" /> 
    /// class.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// The Person//s FirstName.
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate",
            Justification = "A public field is required here for testing.")]
        public string FirstName;

        /// <summary>
        /// Gets or sets the Person//s Surname.
        /// </summary>
        public string Surname { get; set; }
    }
}