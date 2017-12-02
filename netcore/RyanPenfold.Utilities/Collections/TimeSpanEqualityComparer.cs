// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimeSpanEqualityComparer.cs" company="Inspire IT Ltd">
//   Copyright © Inspire IT Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Collections
{
    using System;
    using System.Collections;

    /// <summary>
    /// Compares the equality of <see cref="TimeSpan"/> instances.
    /// </summary>
    public class TimeSpanEqualityComparer : IEqualityComparer
    {
        /// <summary>
        /// The maximum difference between the <see cref="TimeSpan"/> instances.
        /// </summary>
        private readonly TimeSpan maxDifference;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeSpanEqualityComparer"/> class. 
        /// </summary>
        /// <param name="maxDifference">
        /// The maximum difference between the <see cref="TimeSpan"/> instances.
        /// </param>
        public TimeSpanEqualityComparer(TimeSpan maxDifference)
        {
            this.maxDifference = maxDifference;
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

            if (!(x is TimeSpan) || !(y is TimeSpan))
            {
                return x.Equals(y);
            }

            var dt1 = (TimeSpan)x;
            var dt2 = (TimeSpan)y;
            var duration = (dt1 - dt2).Duration();
            return duration < this.maxDifference;
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        public int GetHashCode(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
