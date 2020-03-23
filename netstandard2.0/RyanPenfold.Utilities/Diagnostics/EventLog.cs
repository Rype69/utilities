// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventLog.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Diagnostics
{
    /// <summary>
    /// Provides static methods relating to event logging
    /// </summary>
    public class EventLog
    {
        /// <summary>
        /// Writes to the event log
        /// </summary>
        /// <param name="applicationName">The name of the application</param>
        /// <param name="message">The message</param>
        /// <param name="type">The entry type</param>
        /// <param name="eventId">The identifier of the event</param>
        /// <remarks>Ryan Penfold 03 April 2018</remarks>
        public static void WriteEntry(string applicationName, string message, object type, int eventId)
        {
            throw new System.NotImplementedException("This method has not been implemented in the version of this library targeting .NET Core 2.0.");
        }
    }
}
