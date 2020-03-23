// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonNetResult.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Web.Mvc
{
    using System;
    using System.Text;
    using System.Web.Mvc;

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
        /// (Overrides <see cref="ActionResult.ExecuteResult(ControllerContext)"/>.)
        /// </summary>
        /// <param name="context">The context within which the result is executed.</param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var response = context.HttpContext.Response;
            response.ContentType = !string.IsNullOrEmpty(this.ContentType)
                ? this.ContentType
                : "application/json";

            if (this.ContentEncoding != null)
            {
                response.ContentEncoding = this.ContentEncoding;
            }

            if (this.Data == null)
            {
                return;
            }

            var writer = new JsonTextWriter(response.Output) { Formatting = this.Formatting };
            var serializer = JsonSerializer.Create(this.SerializerSettings);
            serializer.Serialize(writer, this.Data);
            writer.Flush();
        }
    }
}