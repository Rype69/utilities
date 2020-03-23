// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Car.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit.Collections.Generic
{
    /// <summary>
    /// Used for testing the 
    /// <see cref="RyanPenfold.Utilities.Collections.Generic.Enumerable" /> 
    /// class.
    /// </summary>
    public class Car
    {
        /// <summary>
        /// Gets or sets the Manufacturer.
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the Model.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Returns a string that represents this car.
        /// </summary>
        /// <returns>
        /// A string that represents this car.
        /// </returns>
        public override string ToString()
        {
            var result = new System.Text.StringBuilder();
            if (!string.IsNullOrWhiteSpace(this.Manufacturer))
            {
                result.Append(this.Manufacturer);
            }

            if (!string.IsNullOrWhiteSpace(this.Model))
            {
                if (result.Length > 0)
                {
                    result.Append(" ");
                }

                result.Append(this.Model);
            }

            return result.ToString();
        }
    }
}
