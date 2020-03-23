// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Common.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit.IO
{
    /// <summary>
    /// Common functions for testing utilities.IO
    /// </summary>
    public class Common
    {
        /// <summary>
        /// Finds a driver letter on the local computer that doesn't exist
        /// </summary>
        /// <returns>
        /// A letter of a drive in the format X:\ where X doesn't exist
        /// </returns>
        public static string FindDriveLetterThatDoesntExist()
        {
            var driveLetter = string.Empty;
            for (var i = 65; i <= 90; i++)
            {
                if (System.IO.Directory.Exists($"{System.Convert.ToChar(i)}:\\"))
                {
                    continue;
                }

                driveLetter = $"{System.Convert.ToChar(i)}:\\";
                break;
            }

            return driveLetter;
        }
    }
}
