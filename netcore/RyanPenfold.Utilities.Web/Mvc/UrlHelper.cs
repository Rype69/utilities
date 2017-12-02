/*
namespace RyanPenfold.Utilities.Web.Mvc
{
    using System;

    public static class UrlHelper
    {
        public static string Content(this System.Web.Mvc.UrlHelper urlHelper, string contentPath, bool toAbsolute = false)
        {
            var path = urlHelper.Content(contentPath);
            var url = new Uri(System.Web.HttpContext.Current.Request.Url, path);

            return toAbsolute ? url.AbsoluteUri : path;
        }
    }
}
*/