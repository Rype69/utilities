// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Aircraft.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit
{
    using System.Collections.Generic;

    /// <summary>
    /// For the purpose of unit testing.
    /// </summary>
    public class Aircraft : Vehicle
    {
        /// <summary>
        /// Gets or sets the length of the aircraft
        /// </summary>
        public double Length { get; set; }

        /// <summary>
        /// Gets or sets the name of this type of aircraft
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// Gets or sets the amount of passengers this 
        /// type of aircraft can contain.
        /// </summary>
        public int PassengerCapacity { get; set; }

        /// <summary>
        /// Gets or sets the wingspan of this type of aircraft
        /// </summary>
        public double Wingspan { get; set; }

        /// <summary>
        /// Gets or sets the passenger names.
        /// </summary>
        public string[] PassengerNames { get; set; }

        /// <summary>
        /// Gets or sets the names of the crew members.
        /// </summary>
        public List<string> CrewMemberNames { get; set; }

        /// <summary>
        /// Gets or sets the date built.
        /// </summary>
        public System.DateTime DateBuilt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the aircraft is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public char Code { get; set; }    
    }
}