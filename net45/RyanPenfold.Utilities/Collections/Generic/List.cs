// --------------------------------------------------------------------------------------------------------------------
// <copyright file="List.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Collections.Generic
{
    using System.Linq;

    /// <summary>
    /// Provides extension methods for the System.Collections.Generic.IList interface.
    /// </summary>
    public static class List
    {
        /// <summary>
        /// Merges two ILists of type T where each item is only added if there isn't already one there with the same value in the specified field
        /// </summary>
        /// <param name="collection1">
        /// The collection 1.
        /// </param>
        /// <param name="collection2">
        /// The collection 2.
        /// </param>
        /// <param name="fieldName">
        /// The field name.
        /// </param>
        /// <typeparam name="T">
        /// The generic type parameter
        /// </typeparam>
        public static void DistinctAdd<T>(this System.Collections.Generic.IList<T> collection1, System.Collections.Generic.IList<T> collection2, string fieldName)
        {
            if ((collection1 == null) || (collection2 == null))
            {
                return;
            }

            foreach (var item in collection2)
            {
                var anotherItem = item;
                var prop = typeof(T).GetProperty(fieldName);
                var field = typeof(T).GetField(fieldName);
                System.Collections.Generic.IEnumerable<T> results = null;
                if (prop != null)
                {
                    // ReSharper disable ImplicitlyCapturedClosure
                    results = collection1.Where(x => prop.GetValue(x, null) == prop.GetValue(anotherItem, null));
                    // ReSharper restore ImplicitlyCapturedClosure
                }

                if (field != null)
                {
                    // ReSharper disable ImplicitlyCapturedClosure
                    results = collection1.Where(x => field.GetValue(x) == field.GetValue(anotherItem));
                    // ReSharper restore ImplicitlyCapturedClosure
                }

                if (results == null || !results.Any())
                {
                    collection1.Add(item);
                }
            }
        }

        /// <summary>
        /// Sorts a list of objects by property or field name and direction.
        /// </summary>
        /// <param name="list">
        /// A list of objects to sort
        /// </param>
        /// <param name="sortField">
        /// Denotes the name of the field or property to sort by.
        /// </param>
        /// <param name="sortDirection">
        /// Denotes the direction of the sort. Can be ASC or DESC.
        /// </param>
        /// <typeparam name="T">
        /// The type of object whose list requires sorting.
        /// </typeparam>
        /// <returns>
        /// A sorted list of objects of type T.
        /// </returns>
        public static System.Collections.Generic.List<T> Sort<T>(this System.Collections.Generic.List<T> list, string sortField, string sortDirection)
        {
            if ((list != null) && (!string.IsNullOrEmpty(sortField)))
            {
                list.Sort(new Comparer<T>(sortField, sortDirection));
            }

            return list;
        }

        public static string ToJavaScriptArray(this System.Collections.Generic.IList<System.Tuple<string, decimal>> input)
        {
            if (input == null)
                throw new System.ArgumentNullException(nameof(input));

            var builder = new System.Text.StringBuilder("[");
            foreach (var couple in input)
            {
                if (builder.Length > 1)
                    builder.Append(",");

                builder.Append("[");
                builder.Append("\"");
                builder.Append(couple.Item1);
                builder.Append("\", ");
                builder.Append(couple.Item2);
                builder.Append("]");
            }

            builder.Append("]");

            return builder.ToString();
        }

        /// <summary>
        /// Adds an item to an <see cref="System.Collections.Generic.IList{T}"/> if it isn't already present.
        /// </summary>
        /// <typeparam name="T">
        /// The type of object to add.
        /// </typeparam>
        /// <param name="list">
        /// The list to add the item to.
        /// </param>
        /// <param name="item">
        /// The item to add to the collection.
        /// </param>
        public static void UniqueAdd<T>(this System.Collections.Generic.IList<T> list, T item)
        {
            if (list == null)
            {
                throw new System.ArgumentNullException(nameof(list));
            }

            if (!list.Contains(item))
            {
                list.Add(item);
            }
        }
    }
}
