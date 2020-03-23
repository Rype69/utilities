// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonNetResult.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Web.Mvc
{
    using System;
    using System.Text;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Net.Http.Headers;
    using Newtonsoft.Json;

    /// <summary>
    /// Used to send JSON-formatted content to the response
    /// </summary>
    public class JsonNetResult : ActionResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonNetResult"/> class. 
        /// </summary>
        public JsonNetResult()
        {
            this.SerializerSettings = new JsonSerializerSettings();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonNetResult"/> class. 
        /// </summary>
        public JsonNetResult(object data) : this()
        {
            this.Data = data;
        }

        /// <summary>
        /// Gets or sets the content encoding.
        /// </summary>
        public Encoding ContentEncoding { get; set; }

        /// <summary>
        /// Gets or sets the type of the content.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets the formatting
        /// </summary>
        public Formatting Formatting { get; set; }

        /// <summary>
        /// Gets or sets the serializer settings
        /// </summary>
        public JsonSerializerSettings SerializerSettings { get; set; }

        /// <summary>
        /// Enables processing of the result of an action method by a custom type that inherits from the <see cref="ActionResult"/> class.
        /// (Overrides <see cref="ActionResult.ExecuteResult(ActionContext)"/>.)
        /// </summary>
        /// <param name="context">The context within which the result is executed.</param>
        public override void ExecuteResult(ActionContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var response = context.HttpContext.Response;

            var mediaType = new MediaTypeHeaderValue(!string.IsNullOrEmpty(ContentType)
                ? ContentType
                : "application/json");

            if (this.ContentEncoding != null)
            {
                mediaType.Encoding = ContentEncoding;
            }

            response.ContentType = mediaType.ToString();

            if (Data == null)
            {
                return;
            }

            var writer = new JsonTextWriter(new System.IO.StreamWriter(response.Body)) { Formatting = Formatting };
            var serializer = JsonSerializer.Create(SerializerSettings);
            serializer.Serialize(writer, Data);
            writer.Flush();
        }
    }
}