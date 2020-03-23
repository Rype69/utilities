// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventLog.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Diagnostics
{
    using System.Diagnostics;

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
        /// <remarks>Ryan Penfold 11 November 2012</remarks>
        public static void WriteEntry(string applicationName, string message, EventLogEntryType type, int eventId)
        {
            if (!System.Diagnostics.EventLog.SourceExists(applicationName))
            {
                System.Diagnostics.EventLog.CreateEventSource(applicationName, "Application");
            }

            System.Diagnostics.EventLog.WriteEntry(applicationName, message, type, eventId);
        }
    }
}
