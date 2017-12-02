// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HttpContext.cs" company="Ryan Penfold Ltd">
//   Copyright © Ryan Penfold Ltd. All rights reserved.
// </copyright>
// <date>
//   04 March 2012
// </date>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace RyanPenfold.Utilities.Web
{
    /// <summary>
    /// An adapter for the <see cref="System.Web.HttpContextBase"/> type.
    /// </summary>
    public class HttpContext
    {
        /// <summary>
        /// Gets or sets security information for the current HTTP request.
        /// </summary>
        public System.Security.Principal.IPrincipal User { get; set; }

        // TODO: Refactor code so all calls to GetGlobalResourceObject call this method

        /// <summary>
        /// Gets an application-level resource object based on the specified <see cref="System.Web.Compilation.ResourceExpressionFields.ClassKey"/> and <see cref="System.Web.Compilation.ResourceExpressionFields.ResourceKey"/> properties.
        /// </summary>
        /// <typeparam name="T">
        /// The type to which to cast the resource as. This type must be a class.
        /// </typeparam>
        /// <param name="classKey">
        /// A string that represents the <see cref="System.Web.Compilation.ResourceExpressionFields.ClassKey"/> property of the requested resource object.
        /// </param>
        /// <param name="resourceKey">
        /// A string that represents the <see cref="System.Web.Compilation.ResourceExpressionFields.ResourceKey"/> property of the requested resource object.
        /// </param>
        /// <returns>
        /// An instance of <see cref="T"/> that represents the requested application-level resource object; otherwise, null if a resource object is not found or if a resource object is found but it does not have the requested property.
        /// </returns>
        public static T GetGlobalResourceObject<T>(string classKey, string resourceKey) where T : class
        {
            return System.Web.HttpContext.GetGlobalResourceObject(classKey, resourceKey) as T;
        }

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