// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Exception.cs" company="Inspire IT Ltd">
//   Copyright © Inspire IT Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities
{
    /// <summary>
    /// Contains extension methods for the <see cref="System.Exception" /> class.
    /// </summary>
    public static class Exception
    {
        /// <summary>
        /// Gets and combines the messages from the exception and all of the nested inner exceptions
        /// </summary>
        /// <param name="exception">
        /// The exception to query
        /// </param>
        /// <param name="showLabels">
        /// Indicates whether to show labels
        /// </param>
        /// <param name="delimiter">
        /// A string that is appended between exceptions
        /// </param>
        /// <param name="showStackTrace">
        /// Indicates whether to show the stack traces
        /// </param>
        /// <returns>
        /// A concatenated message from the exception and all of the inner ones
        /// </returns>
        public static string GetAllMessages(
            this System.Exception exception,
            bool showLabels = true,
            string delimiter = ", ",
            bool showStackTrace = false)
        {
            var result = new System.Text.StringBuilder();
            var currentException = exception;
            while (currentException != null)
            {
                switch (result.Length == 0)
                {
                    case true:
                        if (showLabels)
                        {
                            result.Append("Exception Message: ");
                        }

                        break;
                    case false:
                        result.Append(delimiter);
                        if (showLabels)
                        {
                            result.Append("Inner Exception Message: ");
                        }

                        break;                    
                }

                result.Append(currentException.Message);

                if (showStackTrace && !string.IsNullOrWhiteSpace(currentException.StackTrace))
                {
                    if (result.Length > 0)
                    {
                        result.Append(delimiter);
                    }

                    if (showLabels)
                    {
                        result.Append("Stack Trace: ");
                    }

                    result.Append(currentException.StackTrace.Trim());
                }

                currentException = currentException.InnerException;
            }

            return result.ToString();
        }

        // TODO: Implement something like this:
        /*
        /// <summary>
        /// Throws an exception of the given type if the specified subject is null
        /// </summary>
        /// <param name="subject">
        /// The subject to check for null
        /// </param>
        /// <param name="params">
        /// The params to pass to 
        /// </param>
        /// <typeparam name="T">
        /// A type of <see cref="System.Exception"/> to throw
        /// </typeparam>
        public static void ThrowIfNull<T>(object subject, params object[] @params) where T : System.Exception
        {
            
        }
        */
    }
}
