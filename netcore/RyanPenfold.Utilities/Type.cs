// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Type.cs" company="Inspire IT Ltd">
//   Copyright © Inspire IT Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities
{
    // using System.Linq;

    /// <summary>
    /// Provides methods which perform operations on <see cref="System.Type"/> objects.
    /// </summary>
    public static class Type
    {
        /// <summary>
        /// Creates a <see cref="System.Type"/> object from it//s name.
        /// </summary>
        /// <param name="fullTypeName">
        /// The full type name.
        /// </param>
        /// <returns>
        /// A <see cref="System.Type"/> object.
        /// </returns>
        public static System.Type GetTypeFromName(string fullTypeName)
        {
            var strTypeName = Uri.GetRightmostnamespace(fullTypeName, ".");
            var strAssembly = fullTypeName.Substring(0, fullTypeName.Length - strTypeName.Length - 1);
            return System.Reflection.Assembly.Load(new System.Reflection.AssemblyName(strAssembly)).GetType(fullTypeName);
        }

        /*
        /// <summary>
        /// Performs a check on an object to see if it is instantiated and if it is not DBNull.
        /// </summary>
        /// <param name="value">
        /// The object to check.
        /// </param>
        /// <returns>
        /// A boolean value indicating whether the object is instantiated and is not DBNull.
        /// </returns>
        public static bool IsNotNullAndIsNotDbNull(object value)
        {
            return value != null && value != System.DBNull.Value;
        }
        */

        /// <summary>
        /// Determines whether a given type is nullable.
        /// </summary>
        /// <param name="type">The type to determine.</param>
        /// <returns>A <see cref="bool"/> indicating whether or not the <see cref="System.Type"/> is nullable.</returns>
        public static bool IsNullable(this System.Type type)
        {
            return System.Nullable.GetUnderlyingType(type) != null;
        }

        /*
        /// <summary>
        /// Find all non-abstract classes derived from the specified class.
        /// </summary>
        /// <param name="baseType">
        /// The topmost class in the class hierarchy.
        /// </param>
        /// <returns>
        /// All non-abstract classes derived from the baseType with a default constructor.
        /// </returns>
        public static System.Collections.Generic.List<System.Type> GetDerivedClasses(System.Type baseType)
        {
            var result = new System.Collections.Generic.List<System.Type>();

            // try
            // {
            // Loop through each loaded assembly and each exported type
            // looking for non-abstract types that derive from our property//s type
            foreach (var t in from a in System.AppDomain.CurrentDomain.GetAssemblies()
                              from t in a.GetTypes()
                              where (!t.IsAbstract) && t.IsSubclassOf(baseType)
                              where (t.GetConstructor(System.Type.EmptyTypes) != null)
                              where result.IndexOf(t) == -1
                              select t)
            {
                result.Add(t);
            }
            
            // }

            // catch (System.Exception)
            // {
            // This exception should only happen in a Design environment in which the
            // controls that use this method are being changed and recompiled.
            //
            // This is because of a charming //feature// that Visual Studio has while
            // you stay in a single Visual Studio session. (If you exit and re-enter Visual Studio,
            // this problem goes away.)

            // When a project is compiled, its dll is placed in a temp directory and used
            // by web pages in the solution. When it is re-compiled, the new dll is placed in a 
            // new temp directory, but the pre-existing usages of the control still point - by default -
            // to the old temp directory.

            // This has an unpleasant side effect (among many others!) of causing multiple versions of the
            // same class definition to appear in the list of loaded dll assemblies. This can cause
            // a duplication error.
            // }
            var sortedList = new System.Collections.Generic.SortedList<string, System.Type>(result.Capacity);

            foreach (var t in result)
            {
                // try
                // {
                    sortedList.Add($"{t.Name}::{t.FullName}::{t.GUID}", t);
                
                // }

                // catch (System.Exception)
                // {
                //  Ditto on the reason for an exception here.
                // }
            }

            var sortedResult = new System.Collections.Generic.List<System.Type> { Capacity = sortedList.Count };

            for (var i = 0; i <= (sortedList.Count - 1); i++)
            {
                sortedResult.Add(result[result.IndexOf(sortedList.Values[i])]);
            }

            return sortedResult;
        }
        */
    }
}