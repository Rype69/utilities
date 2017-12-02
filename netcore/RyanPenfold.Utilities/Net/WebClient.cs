/*
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebClient.cs" company="Inspire IT Ltd">
//   Copyright © Inspire IT Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Net
{
    /// <summary>
    /// Provides web client functions
    /// </summary>
    public abstract class WebClient
    {
        /// <summary>
        /// Encodes a response stream requested from a URL, 
        /// using UTF8 encoding, and returns it as a string.
        /// </summary>
        /// <param name="url">
        /// The url to download data from.
        /// </param>
        /// <returns>
        /// Data downloaded from the url.
        /// </returns>
        public static string DownloadData(string url)
        {
            var client = new System.Net.WebClient();
            var engine = new System.Text.UTF8Encoding();
            return engine.GetString(client.DownloadData(url));
        }
    }
}
*/