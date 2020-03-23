// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Math.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities
{
    using System.Globalization;

    /// <summary>
    /// Provides extension methods that perform mathematical calculations.
    /// </summary>
    public static class Math
    {
        /// <summary>
        /// Denotes whether something is increasing or decreasing.
        /// </summary>
        public enum Direction
        {
            /// <summary>
            /// Denotes an increasing direction.
            /// </summary>
            Increasing = 1,
            
            /// <summary>
            /// Denotes a decreasing direction.
            /// </summary>
            Decreasing = 2
        }

        /// <summary>
        /// Gets the ordinal of an integer (nth).
        /// </summary>
        /// <param name="value">
        /// The integer.
        /// </param>
        /// <returns>
        /// The ordinal of an integer (nth).
        /// </returns>
        public static string GetOrdinal(this int value)
        {
            string result;
            var num = System.Convert.ToString(value).Replace("-", string.Empty).Trim();
            if (num.Length >= 2)
            {
                num = num.Substring(num.Length - 2, 2);
            }

            var intNum = System.Convert.ToInt32(num);
            switch (intNum)
            {
                case 1:
                case 21:
                case 31:
                case 41:
                case 51:
                case 61:
                case 71:
                case 81:
                case 91:
                    result = "st";
                    break;
                case 2:
                case 22:
                case 32:
                case 42:
                case 52:
                case 62:
                case 72:
                case 82:
                case 92:
                    result = "nd";
                    break;
                case 3:
                case 23:
                case 33:
                case 43:
                case 53:
                case 63:
                case 73:
                case 83:
                case 93:
                    result = "rd";
                    break;
                default:
                    result = "th";
                    break;
            }

            return result;
        }

        /// <summary>
        /// Gets the percentage difference between two doubles.
        /// </summary>
        /// <param name="value">
        /// The original.
        /// </param>
        /// <param name="factor">
        /// The factor.
        /// </param>
        /// <returns>
        /// The percentage difference between two doubles.
        /// </returns>
        public static double GetPercentageDifference(this double value, double factor)
        {
            var result = 100.0;
            if (System.Convert.ToInt32(value) != 0 && System.Convert.ToInt32(factor) != 0)
            {
                result = (factor / value) * 100;
            }

            return result;
        }

        /// <summary>
        /// Rounds a double up to the specified number of places.
        /// </summary>
        /// <param name="num">
        /// The double value.
        /// </param>
        /// <param name="places">
        /// The amount of places to round to.
        /// </param>
        /// <returns>
        /// A double rounded up to the specified number of places.
        /// </returns>
        public static double Round(this double num, int places)
        {
            var n = num * System.Math.Pow(10, places);
            n = System.Math.Sign(n) * System.Math.Abs(System.Math.Floor(n + 0.5));
            return n / System.Math.Pow(10, places);
        }

        /// <summary>
        /// Rounds a number up or down to the nearest multiple of significance.
        /// </summary>
        /// <param name="value">
        /// A numeric value to round.
        /// </param>
        /// <param name="significance">
        /// The amount of significant figures to round to.
        /// </param>
        /// <returns>
        /// A rounded number.
        /// </returns>
        public static int RoundToSignificance(this double value, int significance)
        {
            var d = value / significance;
            var strD = System.Convert.ToString(d, CultureInfo.InvariantCulture);
            if (strD.IndexOf(".", System.StringComparison.Ordinal) > 0)
            {
                strD = strD.Substring(0, strD.IndexOf(".", System.StringComparison.Ordinal));
            }

            d = System.Convert.ToDouble(strD);
            return System.Convert.ToInt32(d * significance);
        }
    }
}
