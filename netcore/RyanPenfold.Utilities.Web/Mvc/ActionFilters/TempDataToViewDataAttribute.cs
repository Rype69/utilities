/*
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TempDataToViewDataAttribute.cs" company="Inspire IT Ltd">
//   Copyright © Inspire IT Ltd. All rights reserved.
// </copyright>
// <date>
//   25th March 2014
// </date>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Web.Mvc.ActionFilters
{
    using System.Web.Mvc;

    /// <summary>
    /// Represents an attribute that copies temp data to view data
    /// </summary>
    public class TempDataToViewDataAttribute : ActionFilterAttribute, ITempDataToViewDataAttribute
    {
        /// <summary>
        /// Called by the ASP.NET MVC framework before the action method executes
        /// </summary>
        /// <param name="filterContext">
        /// The filter context.
        /// </param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // NULL-check the filter context
            if (filterContext == null || 
                filterContext.Controller == null ||
                filterContext.Controller.TempData == null ||
                filterContext.Controller.ViewData == null)
            {
                return;
            }

            // Set the viewdata
            if (filterContext.Controller.TempData["ViewData"] is ViewDataDictionary)
            {
                foreach (var viewDatum in filterContext.Controller.TempData["ViewData"] as ViewDataDictionary)
                {
                    filterContext.Controller.ViewData[viewDatum.Key] = viewDatum.Value;
                }
            }
        }
    }
}
*/