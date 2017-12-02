/*
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HttpContext.cs" company="Inspire IT Ltd">
//   Copyright © Inspire IT Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Web
{
    using System;

    /// <summary>
    /// Provides utility functions and extension methods on <see cref="System.Web.HttpContext"/> instances.
    /// </summary>
    public static class HttpContext
    {
        /// <summary>
        /// Gets an application-level resource string based on the specified <see cref="System.Web.Compilation.ResourceExpressionFields.ClassKey"/> and <see cref="System.Web.Compilation.ResourceExpressionFields.ResourceKey"/> properties.
        /// </summary>
        /// <param name="classKey">
        /// A string that represents the <see cref="System.Web.Compilation.ResourceExpressionFields.ClassKey"/> property of the requested resource object.
        /// </param>
        /// <param name="resourceKey">
        /// A string that represents the <see cref="System.Web.Compilation.ResourceExpressionFields.ResourceKey"/> property of the requested resource object.
        /// </param>
        /// <returns>
        /// An string that represents the requested application-level resource object; otherwise, null if a resource object is not found or if a resource object is found but it does not have the requested property.
        /// </returns>
        public static string GetGlobalResourceString(string classKey, string resourceKey)
        {
            // TODO: uncomment return System.Web.HttpContext.GetGlobalResourceObject(classKey, resourceKey) as string;

            var result = System.Web.HttpContext.GetGlobalResourceObject(classKey, resourceKey) as string;
            if (string.IsNullOrWhiteSpace(result))
            {
                throw new Exception($"Cannot find global resource \"{resourceKey}\".");
            }

            return result;
        }
    }
}
*/