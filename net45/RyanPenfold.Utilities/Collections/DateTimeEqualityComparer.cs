// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeEqualityComparer.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Collections
{
    /// <summary>
    /// Compares the equality of <see cref="DateTime"/> instances.
    /// </summary>
    public class DateTimeEqualityComparer : System.Collections.IEqualityComparer
    {
        /// <summary>
        /// The maximum difference between the <see cref="DateTime"/> instances.
        /// </summary>
        private readonly System.TimeSpan _maxDifference;

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeEqualityComparer"/> class. 
        /// </summary>
        /// <param name="maxDifference">
        /// The maximum difference between the <see cref="DateTime"/> instances.
        /// </param>
        public DateTimeEqualityComparer(System.TimeSpan maxDifference)
        {
            this._maxDifference = maxDifference;
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>true if the specified objects are equal; otherwise, false.</returns>
        public new bool Equals(object x, object y)
        {
            if (x == null || y == null)
            {
                return false;
            }

            if (!(x is System.DateTime) || !(y is System.DateTime))
            {
                return x.Equals(y);
            }

            var dt1 = (System.DateTime)x;
            var dt2 = (System.DateTime)y;
            var duration = (dt1 - dt2).Duration();
            return duration < this._maxDifference;
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        public int GetHashCode(object obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
