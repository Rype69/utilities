// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Integer.cs" company="Inspire IT Ltd">
//   Copyright © Inspire IT Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities
{
    using System.Text;

    /// <summary>
    /// Provides extension methods for instances of the <see cref="int"/> type.
    /// </summary>
    public static class Integer
    {
        /// <summary>
        /// Converts an <see cref="int"/> to a <see cref="System.Guid"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>A <see cref="System.Guid"/>.</returns>
        public static System.Guid ToGuid(this int value)
        {
            var bytes = new byte[16];
            System.BitConverter.GetBytes(value).CopyTo(bytes, 0);
            return new System.Guid(bytes);
        }

        /// <summary>
        /// Converts an <see cref="int"/> to its textual representation
        /// </summary>
        /// <param name="num">
        /// The number to convert to text
        /// </param>
        /// <returns>
        /// A textual representation of the given number
        /// </returns>
        public static string ToText(this int num)
        {
            StringBuilder result;

            if (num < 0)
            {
                return $"Minus {ToText(-num)}";
            }

            if (num == 0)
            {
                return "Zero";
            }

            if (num <= 19)
            {
                var oneToNineteen = new[]
                {
                    "One",
                    "Two",
                    "Three",
                    "Four",
                    "Five",
                    "Six",
                    "Seven",
                    "Eight",
                    "Nine",
                    "Ten",
                    "Eleven",
                    "Twelve",
                    "Thirteen",
                    "Fourteen",
                    "Fifteen",
                    "Sixteen",
                    "Seventeen",
                    "Eighteen",
                    "Nineteen"
                };

                return oneToNineteen[num - 1];
            }

            if (num <= 99)
            {
                result = new StringBuilder();

                var multiplesOfTen = new[]
                {
                    "Twenty",
                    "Thirty",
                    "Forty",
                    "Fifty",
                    "Sixty",
                    "Seventy",
                    "Eighty",
                    "Ninety"
                };

                result.Append(multiplesOfTen[(num / 10) - 2]);

                if (num % 10 != 0)
                {
                    result.Append(" ");
                    result.Append(ToText(num % 10));
                }

                return result.ToString();
            }

            if (num == 100)
            {
                return "One Hundred";
            }

            if (num <= 199)
            {
                return $"One Hundred and {ToText(num % 100)}";
            }

            if (num <= 999)
            {
                result = new StringBuilder((num / 100).ToText());
                result.Append(" Hundred");
                if (num % 100 != 0)
                {
                    result.Append(" and ");
                    result.Append((num % 100).ToText());
                }

                return result.ToString();
            }

            if (num <= 999999)
            {
                result = new StringBuilder((num / 1000).ToText());
                result.Append(" Thousand");
                if (num % 1000 != 0)
                {
                    switch ((num % 1000) < 100)
                    {
                        case true:
                            result.Append(" and ");
                            break;
                        case false:
                            result.Append(", ");
                            break;
                    }

                    result.Append((num % 1000).ToText());
                }

                return result.ToString();
            }

            if (num <= 999999999)
            {
                result = new StringBuilder((num / 1000000).ToText());
                result.Append(" Million");
                if (num % 1000000 != 0)
                {
                    switch ((num % 1000000) < 100)
                    {
                        case true:
                            result.Append(" and ");
                            break;
                        case false:
                            result.Append(", ");
                            break;
                    }

                    result.Append((num % 1000000).ToText());
                }

                return result.ToString();
            }

            result = new StringBuilder((num / 1000000000).ToText());
            result.Append(" Billion");
            if (num % 1000000000 != 0)
            {
                switch ((num % 1000000000) < 100)
                {
                    case true:
                        result.Append(" and ");
                        break;
                    case false:
                        result.Append(", ");
                        break;
                }

                result.Append((num % 1000000000).ToText());
            }

            return result.ToString();
        }
    }
}
