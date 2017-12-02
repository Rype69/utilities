// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateTime.cs" company="Inspire IT Ltd">
//   Copyright © Inspire IT Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities
{
    /// <summary>
    /// Provides extension methods that operate on DateTime values.
    /// </summary>
    public static class DateTime
    {
        /// <summary>
        /// Determine the maximum day of a specific month.
        /// </summary>
        /// <param name="month">A month value.</param>
        /// <param name="year">A year value.</param>
        public static byte MaxDayOfMonth(byte month, short year)
        {
            byte result;

            if (month < System.DateTime.MinValue.Month)
            {
                throw new System.ArgumentOutOfRangeException(nameof(month), $"cannot be less than {System.DateTime.MinValue.Month}.");
            }

            if (month > System.DateTime.MaxValue.Month)
            {
                throw new System.ArgumentOutOfRangeException(nameof(month), $"cannot be greater than {System.DateTime.MaxValue.Month}.");
            }

            if (year < System.DateTime.MinValue.Year)
            {
                throw new System.ArgumentOutOfRangeException(nameof(year), $"cannot be less than {System.DateTime.MinValue.Year}.");
            }

            if (year > System.DateTime.MaxValue.Year)
            {
                throw new System.ArgumentOutOfRangeException(nameof(year), $"cannot be greater than {System.DateTime.MaxValue.Year}.");
            }

            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    result = 31;
                    break;
                case 2:
                    result = System.DateTime.IsLeapYear(year) ? (byte)29 : (byte)28;
                    break;
                default:
                    result = 30;
                    break;
            }

            return result;
        }

        /// <summary>
        /// Creates a long date string including ordinal from a System.DateTime.
        /// </summary>
        /// <param name="value">
        /// The source date.
        /// </param>
        /// <param name="includeDayOfWeek">
        /// Denotes whether to include day of week.
        /// </param>
        /// <returns>
        /// A long date string including ordinal.
        /// </returns>
        public static string ToLongDateStringIncludingOrdinal(this System.DateTime value, bool includeDayOfWeek = false)
        {
            var strDayOfWeek = string.Empty;

            if (includeDayOfWeek)
            {
                strDayOfWeek = $"{value.DayOfWeek} ";
            }

            return $"{strDayOfWeek}{value.Day}{value.Day.GetOrdinal()} {value.ToString("MMMM")} {value.Year}";
        }

        /// <summary>
        /// Returns a date string in the form shortDayOfWeek, dayOfMonth shortMonth yyyy hh:mm:ss UTC
        /// For example Fri, 3 Aug 2001 20:47:11 UTC
        /// </summary>
        /// <param name="value">
        /// A datetime value to parse.
        /// </param>
        /// <returns>
        /// A date string in the form shortDayOfWeek, dayOfMonth shortMonth yyyy hh:mm:ss UTC
        /// For example Fri, 3 Aug 2001 20:47:11 UTC
        /// </returns>
        public static string ToCookieForm(this System.DateTime value)
        {
            var result = new System.Text.StringBuilder();
            result.Append(value.DayOfWeek.ToString().Substring(0, 3));
            result.Append(", ");
            result.Append(value.Day);
            result.Append(" ");
            result.Append(value.ToString("MMMM").Substring(0, 3));
            result.Append(" ");
            result.Append(value.Year);
            result.Append(" ");
            result.Append(value.ToString("HH:mm:ss"));
            result.Append(" UTC");
            return result.ToString();
        }

        /// <summary>
        /// Converts a string value to a System.DateTime
        /// </summary>
        /// <param name="value">
        /// The date string.
        /// </param>
        /// <param name="format">
        /// The format where 103 = dd/MM/yyyy
        /// </param>
        /// <returns>
        /// A System.DateTime
        /// </returns>
        /// <exception cref="System.Exception">
        /// Exception is thrown if the given string value does not meet the expected format.
        /// </exception>
        public static System.DateTime ToDateTime(this string value, int format)
        {
            var result = new System.DateTime();
            switch (format)
            {
                case 103:
                    // Validate
                    if ((!string.IsNullOrEmpty(value)) && System.Text.RegularExpressions.Regex.IsMatch(value.Trim(), "^(((0[1-9]|[12]\\d|3[01])\\/(0[13578]|1[02])\\/((1[6-9]|[2-9]\\d)\\d{2}))|((0[1-9]|[12]\\d|30)\\/(0[13456789]|1[012])\\/((1[6-9]|[2-9]\\d)\\d{2}))|((0[1-9]|1\\d|2[0-8])\\/02\\/((1[6-9]|[2-9]\\d)\\d{2}))|(29\\/02\\/((1[6-9]|[2-9]\\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"))
                    {
                        // Build
                        var dateParts = value.Trim().Split(System.Convert.ToChar("/"));
                        result = result.AddYears(System.Convert.ToInt32(dateParts[2]) - 1);
                        result = result.AddMonths(System.Convert.ToInt32(dateParts[1]) - 1);
                        result = result.AddDays(System.Convert.ToInt32(dateParts[0]) - 1);
                    }
                    else
                    {
                        throw new System.Exception($"String \"{value}\" is not of expected format \"{format}\".");
                    }

                    break;
                case -1:
                    // Validate
                    if ((!string.IsNullOrEmpty(value)) && value.Contains(" "))
                    {
                        var strDate = value.Trim().Split(System.Convert.ToChar(" "));
                        if (strDate.Length == 2)
                        {
                            if (System.Text.RegularExpressions.Regex.IsMatch(strDate[0].Trim(), "^(((0[1-9]|[12]\\d|3[01])\\/(0[13578]|1[02])\\/((1[6-9]|[2-9]\\d)\\d{2}))|((0[1-9]|[12]\\d|30)\\/(0[13456789]|1[012])\\/((1[6-9]|[2-9]\\d)\\d{2}))|((0[1-9]|1\\d|2[0-8])\\/02\\/((1[6-9]|[2-9]\\d)\\d{2}))|(29\\/02\\/((1[6-9]|[2-9]\\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"))
                            {
                                // Build
                                var dateParts = strDate[0].Trim().Split(System.Convert.ToChar("/"));
                                result = result.AddYears(System.Convert.ToInt32(dateParts[2]) - 1);
                                result = result.AddMonths(System.Convert.ToInt32(dateParts[1]) - 1);
                                result = result.AddDays(System.Convert.ToInt32(dateParts[0]) - 1);
                            }
                            else
                            {
                                throw new System.Exception($"String \"{value}\" is not of expected format \"{System.Convert.ToString(format)}\".");
                            }

                            if (System.Text.RegularExpressions.Regex.IsMatch(strDate[1].Trim(), "^([0-1][0-9]|[2][0-3]):([0-5][0-9])$"))
                            {
                                // Build
                                var timeParts = strDate[1].Trim().Split(System.Convert.ToChar(":"));
                                result = result.AddHours(System.Convert.ToInt32(timeParts[0]));
                                result = result.AddMinutes(System.Convert.ToInt32(timeParts[1]));
                            }
                            else
                            {
                                throw new System.Exception($"String \"{value}\" is not of expected format \"{System.Convert.ToString(format)}\".");
                            }
                        }
                        else
                        {
                            throw new System.Exception($"String \"{value}\" is not of expected format \"{System.Convert.ToString(format)}\".");
                        }
                    }
                    else
                    {
                        throw new System.Exception($"String \"{value}\" is not of expected format \"{System.Convert.ToString(format)}\".");
                    }

                    break;
            }

            return result;
        }

        /// <summary>
        /// Truncates the milliseconds from a <see cref="DateTime"/> object
        /// </summary>
        /// <param name="source">The <see cref="DateTime"/> to truncate</param>
        /// <returns>A <see cref="DateTime"/></returns>
        public static System.DateTime TruncateToSeconds(this System.DateTime source)
        {
            // Return result
            return new System.DateTime(source.Ticks - (source.Ticks % System.TimeSpan.TicksPerSecond), source.Kind);
        }
    }
}
