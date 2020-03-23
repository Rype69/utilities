namespace RyanPenfold.Utilities.Collections
{
    /// <summary>
    /// Compares the equality of <see cref="T"/> instances.
    /// </summary>
    public class EqualityComparer<T> : System.Collections.IEqualityComparer
    {
        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>true if the specified objects are equal; otherwise, false.</returns>
        public new bool Equals(object x, object y)
        {
            var rtn = true;
            var allProperties = typeof(T).GetProperties();
            foreach (var property in allProperties)
            {
                var xVal = property.GetValue(x);
                var yVal = property.GetValue(y);

                rtn = rtn && (xVal == null && yVal == null) || (xVal != null && yVal != null && xVal.ToString() == yVal.ToString());
            }

            return rtn;
        }

        public int GetHashCode(object obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
