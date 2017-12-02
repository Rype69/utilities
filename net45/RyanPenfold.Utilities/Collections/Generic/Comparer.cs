// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Comparer.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Collections.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A generic comparer class. Allows for the sorting of a set of objects of any type T, in either direction.
    /// </summary>
    /// <typeparam name="T">
    /// The type of object whose set requires sorting.
    /// </typeparam>
    public class Comparer<T> : IComparer<T>
    {
        /// <summary>
        /// Denotes the name of the field or property to sort by.
        /// </summary>
        private readonly string sortField;

        /// <summary>
        /// Denotes the direction of the sort. Can be ASC or DESC.
        /// </summary>
        private readonly string sortDirection = "ASC";

        /// <summary>
        /// Initializes a new instance of the <see cref="Comparer{T}"/> class.
        /// </summary>
        /// <param name="sortField">
        /// Denotes the name of the field or property to sort by.
        /// </param>
        /// <param name="sortDirection">
        /// Denotes the direction of the sort. Can be ASC or DESC.
        /// </param>
        /// <exception cref="Exception">
        /// Throws an exception if type T doesn't contain a property of field with the same name as the sort field.
        /// </exception>
        /// <exception cref="Exception">
        /// Throws an exception if the sortdirection is not set to ASC or DESC.
        /// </exception>
        public Comparer(string sortField, string sortDirection = "ASC")
        {
            // Ensure sortfield exists as a property or field on type T
            var sortFieldIsValid = typeof(T).GetProperties().Where(property => (property != null)).Any(property => property.Name == sortField)
                || typeof(T).GetFields().Where(field => (field != null)).Any(field => field.Name == sortField);

            // If sortfield exists as a property or field on type T, save to field. Else, throw exception.
            switch (sortFieldIsValid)
            {
                case true:
                    this.sortField = sortField;
                    break;
                case false:
                    throw new ApplicationException($"Property or field with name \"{sortField}\" not found on type \"{typeof(T).Name}\".");
            }

            // If sortdirection contains a valid value, save to field. Else, throw exception.
            switch (string.IsNullOrEmpty(sortDirection) || (sortDirection.ToUpper() != "ASC" && sortDirection.ToUpper() != "DESC"))
            {
                case true:

                    throw new ApplicationException("Sort direction must be \"ASC\" or \"DESC\"");

                case false:

                    if (string.IsNullOrWhiteSpace(sortDirection))
                    {
                        sortDirection = "ASC";
                    }

                    this.sortDirection = sortDirection.ToUpper();
                    break;
            }
        }

        /// <summary>
        /// Performs a case-sensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">
        /// The first object to compare.
        /// </param>
        /// <param name="y">
        /// The second object to compare
        /// </param>
        /// <returns>
        /// A value indicating whether one is less than, equal to, or greater than the other.
        /// </returns>
        /// <exception cref="ApplicationException">
        /// Throws exception if the property or field is not found
        /// </exception>
        public int Compare(T x, T y)
        {
            var result = 0;
            var property = x.GetType().GetProperty(this.sortField);
            var field = x.GetType().GetField(this.sortField);

            if (property == null && field == null)
            {
                throw new ApplicationException($"Property or field with name \"{this.sortField}\" not found in type \"{typeof(T).Name}\".");
            }

            switch (this.sortDirection)
            {
                case "ASC":
                    result = property != null 
                        ? 
                            System.Collections.Comparer.DefaultInvariant.Compare(
                            property.GetValue(x, null), property.GetValue(y, null)) 
                        : 
                            System.Collections.Comparer.DefaultInvariant.Compare(
                            field.GetValue(x), field.GetValue(y));
                    break;
                case "DESC":
                    result = property != null
                        ?
                            System.Collections.Comparer.DefaultInvariant.Compare(
                            property.GetValue(y, null), property.GetValue(x, null)) 
                        : 
                            System.Collections.Comparer.DefaultInvariant.Compare(
                            field.GetValue(y), field.GetValue(x));
                    break;
            }

            return result;
        }
    }
}
