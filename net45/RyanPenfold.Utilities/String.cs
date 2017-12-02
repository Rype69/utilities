// --------------------------------------------------------------------------------------------------------------------
// <copyright file="String.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities
{
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Contains methods that perform operations on <see cref="System.String"/> objects.
    /// </summary>
    public static class String
    {
        /// <summary>
        /// Determines whether a <see cref="System.String"/> contains numbers.
        /// </summary>
        /// <param name="value">
        /// The <see cref="System.String"/> to check.
        /// </param>
        /// <returns>
        /// A boolean value indicating whether numbers are found in the <see cref="System.String"/>.
        /// </returns>
        public static bool ContainsNumbers(this string value)
        {
            return value.Any(char.IsDigit);
        }

        /// <summary>
        /// Counts the amount of occurrences of a given substring within a <see cref="System.String"/> object.
        /// </summary>
        /// <param name="source">
        /// The source <see cref="System.String"/>.
        /// </param>
        /// <param name="substring">
        /// The substring.
        /// </param>
        /// <returns>
        /// The amount of occurrences found of a given substring within the source <see cref="System.String"/>.
        /// </returns>
        public static int CountSubstringOccurrences(this string source, string substring)
        {
            var intReturn = 0;
            for (var intStartPos = 0; intStartPos <= (source.Length - 1); intStartPos++)
            {
                if ((intStartPos + substring.Length) > source.Length)
                {
                    continue;
                }

                var strSub = source.Substring(intStartPos, substring.Length);
                if (string.Equals(strSub, substring))
                {
                    intReturn += 1;
                }
            }

            return intReturn;
        }

        /// <summary>
        /// Determines if two strings are equal regardless of their case.
        /// </summary>
        /// <param name="string1">
        /// The first string to compare.
        /// </param>
        /// <param name="string2">
        /// The second string to compare.
        /// </param>
        /// <returns>
        /// A boolean value indicating whether two strings are equal regardless of their case.
        /// </returns>
        public static bool EqualsIgnoreCase(this string string1, string string2)
        {
            return (string.IsNullOrEmpty(string1) && string.IsNullOrEmpty(string2)) || ((!string.IsNullOrEmpty(string1) && !string.IsNullOrEmpty(string2)) && (string1.ToLower() == string2.ToLower()));
        }

        /// <summary>
        /// Converts a <see cref="string"/> from base64.
        /// </summary>
        /// <param name="base64EncodedData">A <see cref="string"/> to convert.</param>
        /// <returns>A <see cref="string"/>.</returns>
        public static string FromBase64(this string base64EncodedData)
        {
            return System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(base64EncodedData));
        }

        /// <summary>
        /// Creates a string of space-delimited words from a camel case string.
        /// </summary>
        /// <param name="text">
        /// The string to parse.
        /// </param>
        /// <param name="allowAcronymns">
        /// Denotes whether acronyms are allowed.
        /// </param>
        /// <returns>
        /// A string of space-delimited words.
        /// </returns>
        public static string FromCamelCase(this string text, bool allowAcronymns = false)
        {
            var strReturn = new System.Text.StringBuilder();
            for (var intC = 0; intC <= text.Length - 1; intC++)
            {
                var c = text[intC];
                var nc = new char?();
                if (intC < text.Length - 1)
                {
                    nc = text[intC + 1];
                }

                if (c.IsUpperCase())
                {
                    if (strReturn.Length > 0)
                    {
                        if (!allowAcronymns || (nc.HasValue && !nc.Value.IsUpperCase()))
                        {
                            strReturn.Append(" ");
                        }
                    }
                }

                strReturn.Append(c);
            }

            return strReturn.ToString();
        }

        /// <summary>
        /// Creates a literal string from a string of character codes.
        /// </summary>
        /// <param name="value">
        /// A string of character codes.
        /// </param>
        /// <returns>
        /// A literal string.
        /// </returns>
        public static string FromCharCodeString(this string value)
        {
            var result = new System.Text.StringBuilder();
            for (var intCount = 0; intCount <= (value.Length - 1); intCount += 3)
            {
                result.Append(System.Convert.ToChar(System.Convert.ToInt32(value.Substring(intCount, 3))));
            }

            return result.ToString();
        }

        /// <summary>
        /// Converts an empty string to a null value.
        /// </summary>
        /// <param name="value">
        /// The string to compare.
        /// </param>
        /// <returns>
        /// Null, if the given string is null or empty. Otherwise, it returns the original string.
        /// </returns>
        public static string FromEmptyToNothing(this string value)
        {
            string result = null;
            if ((!string.IsNullOrEmpty(value)) && (!string.IsNullOrEmpty(value.Trim())))
            {
                result = value;
            }

            return result;
        }

        /// <summary>
        /// Produces optional, URL-friendly version of a title, "like-this-one". 
        /// hand-tuned for speed, reflects performance refactoring contributed
        /// </summary>
        /// <param name="input">
        /// The string to hyphenate.
        /// </param>
        /// <param name="maxLength">
        /// The max Length of the output
        /// </param>
        /// <returns>
        /// A <see cref="string"/> with all the non-alphanumeric characters replaces with hyphens.
        /// </returns>
        /// <remarks>
        /// Written by John Gietzen (user otac0n) 
        /// </remarks>
        public static string Hyphenate(this string input, long maxLength = 80)
        {
            if (input == null)
            {
                return string.Empty;
            }

            var len = input.Length;
            var prevdash = false;
            var sb = new System.Text.StringBuilder(len);

            for (var i = 0; i < len; i++)
            {
                var c = input[i];
                if ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'))
                {
                    sb.Append(c);
                    prevdash = false;
                }
                else if (c >= 'A' && c <= 'Z')
                {
                    // tricky way to convert to lowercase
                    sb.Append((char)(c | 32));
                    prevdash = false;
                }
                else if (c == ' ' || c == ',' || c == '.' || c == '/' ||
                    c == '\\' || c == '-' || c == '_' || c == '=')
                {
                    if (!prevdash && sb.Length > 0)
                    {
                        sb.Append('-');
                        prevdash = true;
                    }
                }
                else if (c >= 128)
                {
                    var prevlen = sb.Length;
                    sb.Append(c.RemapInternationalToAscii());
                    if (prevlen != sb.Length)
                    {
                        prevdash = false;
                    }
                }

                if (i == maxLength)
                {
                    break;
                }
            }

            return prevdash ? sb.ToString().Substring(0, sb.Length - 1) : sb.ToString();
        }

        /// <summary>
        /// Replaces diacritic characters in a <see cref="System.String"/> with non-accented equivalents
        /// </summary>
        /// <param name="text">
        /// The <see cref="System.String"/> to replace diacritic characters in.
        /// </param>
        /// <returns>
        /// A <see cref="string"/> with diacritic characters replaced
        /// </returns>
        public static string RemoveDiacritics(this string text)
        {
            var normalizedString = text.Normalize(System.Text.NormalizationForm.FormD);
            var stringBuilder = new System.Text.StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            // Return result
            return stringBuilder.ToString().Normalize(System.Text.NormalizationForm.FormC);
        }

        /// <summary>
        /// Removes excess white space from a string.
        /// </summary>
        /// <param name="text">
        /// The string to parse.
        /// </param>
        /// <returns>
        /// The string without the excess white space.
        /// </returns>
        public static string RemoveWhiteSpace(this string text)
        {
            var result = text;
            result = result.Replace("\r\n", string.Empty);
            result = result.Replace("\t", string.Empty);
            while (result.Contains("  "))
            {
                result = result.Replace("  ", " ");
            }

            return result;
        }

        /// <summary>
        /// Reverses a string.
        /// </summary>
        /// <param name="value">The string to reverse.</param>
        /// <returns>A reversed string.</returns>
        public static string Reverse(this string value)
        {
            return new string(Enumerable.Range(1, value.Length)
                .Select(i => value[value.Length - i]).ToArray());
        }

        /// <summary>
        /// Performs a null check on a string and returns a String.Empty if it//s null.
        /// </summary>
        /// <param name="value">
        /// A string value.
        /// </param>
        /// <returns>
        /// A sanitized string.
        /// </returns>
        public static string Sanitise(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            return value;
        }

        /// <summary>
        /// Converts a <see cref="string"/> to base64.
        /// </summary>
        /// <param name="plainText">The <see cref="string"/> to convert.</param>
        /// <returns>A base64 <see cref="string"/>.</returns>
        public static string ToBase64(this string plainText)
        {
            return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(plainText));
        }

        /// <summary>
        /// Converts a <see cref="System.String"/> to a <see cref="System.Boolean"/>. Valid values include 0, 1, yes, no, true, and false.
        /// </summary>
        /// <param name="value">The string representation of a boolean.</param>
        /// <returns>True if value = "True" or "Yes" or "1" (case insensitive). False if value = "True" or "Yes" or "1" (case insensitive).</returns>
        /// <exception cref="System.InvalidCastException">Throws an InvalidCastException if value is not equal to any of the described values.</exception>
        public static bool ToBoolean(this string value)
        {
            bool result;
            switch (value.ToLower())
            {
                case "1":
                case "yes":
                case "true":
                    result = true;
                    break;
                case "0":
                case "no":
                case "false":
                    result = false;
                    break;
                default:
                    throw new System.InvalidCastException("String must be equal to \"true\", \"false\", \"yes\", \"no\", \"1\", or \"0\".");
            }

            return result;
        }

        /// <summary>
        /// Converts a string to camel case. 
        /// Camel case is defined as "compound words or phrases in which the 
        /// elements are joined without spaces, with each element//s initial letter 
        /// capitalized within the compound and the first letter is either upper or 
        /// lower case".
        /// </summary>
        /// <param name="value">
        /// The string to convert.
        /// </param>
        /// <param name="lowerCamelCase">
        /// Denotes whether lower camel case is required. 
        /// When set to true, the first character of the string will be lower case, 
        /// otherwise the first character of the string will be uppercase.
        /// </param>
        /// <returns>
        /// A string in camel case format.
        /// </returns>
        /// <remarks>
        /// camelCase (camel case or camel-case)—also known as medial capitals[1]—is 
        /// the practice of writing compound words or phrases in which the elements 
        /// are joined without spaces, with each element//s initial letter capitalized 
        /// within the compound and the first letter is either upper or lower case—as 
        /// in "LaBelle", BackColor, "McDonald//s", LeeAndrea, or "iPod". The name 
        /// comes from the uppercase "bumps" in the middle of the compound word, 
        /// suggestive of the humps of a camel. The practice is known by many 
        /// other names.
        /// </remarks>
        public static string ToCamelCase(this string value, bool lowerCamelCase = false)
        {
            var result = new System.Text.StringBuilder();
            if (value != null)
            {
                var blnNextOneShouldBeUpper = false;
                for (var id = 0; id <= (value.Trim().Length - 1); id++)
                {
                    var str = value.Substring(id, 1);
                    if (id == 0)
                    {
                        result.Append(lowerCamelCase ? str.ToLower() : str.ToUpper());
                    }
                    else
                    {
                        result.Append(blnNextOneShouldBeUpper ? str.ToUpper() : str.ToLower());
                        blnNextOneShouldBeUpper = str == " ";
                    }
                }
            }

            result = result.Replace(" ", string.Empty);
            return result.ToString();
        }

        public static string ToCapitalFirstLetter(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            var result = new StringBuilder();
            result.Append(input[0].ToString().ToUpper());

            if (input.Length > 1)
            {
                result.Append(input.Substring(1));
            }

            return result.ToString();
        }

        /// <summary>
        /// Converts a string to a string of character codes.
        /// </summary>
        /// <param name="value">
        /// The string to convert.
        /// </param>
        /// <returns>
        /// A string of character codes.
        /// </returns>
        public static string ToCharCodeString(this string value)
        {
            var result = new System.Text.StringBuilder();
            foreach (var b in value.Select(c => (int)c))
            {
                if (b < 10)
                {
                    result.Append("0");
                }

                if (b < 100)
                {
                    result.Append("0");
                }

                result.Append(b);
            }

            return result.ToString();
        }

        /// <summary>
        /// Converts a string of 32 characters (excluding spaces) to a <see cref="System.Guid"/>
        /// </summary>
        /// <param name="value">A string of 32 characters</param>
        /// <returns>A <see cref="System.Guid"/></returns>
        public static System.Guid ToGuid(this string value)
        {
            // NULL-check the input
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new System.ArgumentNullException(nameof(value));
            }

            // Trim / remove spaces from the input
            var trimmedValue = value.Replace(" ", string.Empty).Trim();
            
            // Validate the string as a 32-characters long
            if (trimmedValue.Length != 32)
            {
                throw new System.FormatException("Input string must be 32 characters in length (excluding spaces)");
            }

            // Compute and return result
            return new System.Guid(
                $"{trimmedValue.Substring(0, 8)}-{trimmedValue.Substring(8, 4)}-{trimmedValue.Substring(12, 4)}-{trimmedValue.Substring(16, 4)}-{trimmedValue.Substring(20, 12)}");
        }

        /// <summary>
        /// Encodes some characters in plain text with
        /// HTML equivalents
        /// </summary>
        /// <param name="value">A plain text string to encode.</param>
        /// <returns>A <see cref="string"/>.</returns>
        public static string ToHtml(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            // TODO: Replace any email addresses with "Mailto" links

            foreach (var match in System.Text.RegularExpressions.Regex.Matches(value, Net.Mail.MailAddress.RegularExpressionPattern))
            {
                value = value.Replace(match.ToString(), $"<a href=\"mailto:\">{match}</a>");
            }

            return value.Replace("\r\n", "<br />")
                        .Replace("\n", "<br />");
        }

        /// <summary>
        /// Converts a string to lower camel case format.
        /// </summary>
        /// <param name="value">
        /// The string to convert.
        /// </param>
        /// <returns>
        /// A string in lower camel case format.
        /// </returns>
        public static string ToLowerCamelCase(this string value)
        {
            return ToCamelCase(value, true);
        }

        /// <summary>
        /// Converts the first character of a string to lowercase.
        /// </summary>
        /// <param name="input">The input <see cref="string"/>.</param>
        /// <returns>A <see cref="string"/>.</returns>
        public static string ToLowerFirstLetter(this string input)
        {
            // NULL-check the parameter
            if (input == null)
            {
                throw new System.ArgumentNullException(nameof(input));
            }

            // If the length of the input is zero, return the input
            // If the length of the input is one, return input.ToLower()
            switch (input.Length)
            {
                case 0:
                    return input;
                case 1:
                    return input.ToLower();
            }

            var builder = new System.Text.StringBuilder(input[0].ToString().ToLower());
            builder.Append(input.Substring(1));
            return builder.ToString();
        }

        /// <summary>
        /// Converts a string to title case (a.k.a. Letter Case)
        /// </summary>
        /// <param name="value">
        /// The string value to convert.
        /// </param>
        /// <param name="preserveUpperCharacters">
        /// Denotes whether to preserve the upper characters already present.
        /// </param>
        /// <returns>
        /// A string in title case format.
        /// </returns>
        public static string ToTitleCase(this string value, bool preserveUpperCharacters = true)
        {
            var builder = new System.Text.StringBuilder();
            if (!string.IsNullOrEmpty(value))
            {
                var strs = value.Trim().Split(System.Convert.ToChar(" "));
                foreach (var str in strs)
                {
                    for (var i = 0; i <= (str.Length - 1); i++)
                    {
                        if ((i > 0 && i < (str.Length - 1) && str[i].IsUpperCase() &&
                            !str[i + 1].IsUpperCase()) || (i == 0 && builder.Length > 0))
                        {
                            builder.Append(" ");
                        }

                        switch (i == 0 || (char.IsUpper(str[i]) && preserveUpperCharacters))
                        {
                            case true:
                                builder.Append(char.ToUpper(str[i]));
                                break;
                            case false:
                                builder.Append(char.ToLower(str[i]));
                                break;
                        }
                    }
                }
            }

            return builder.ToString();
        }

        /// <summary>
        /// Converts a string to upper camel case format.
        /// </summary>
        /// <param name="value">
        /// The string value to convert.
        /// </param>
        /// <returns>
        /// A string in upper camel case format.
        /// </returns>
        public static string ToUpperCamelCase(this string value)
        {
            return ToCamelCase(value);
        }

        /// <summary>
        /// Converts the first character of a string to uppercase.
        /// </summary>
        /// <param name="input">The input <see cref="string"/>.</param>
        /// <returns>A <see cref="string"/>.</returns>
        public static string ToUpperFirstLetter(this string input)
        {
            // NULL-check the parameter
            if (input == null)
            {
                throw new System.ArgumentNullException(nameof(input));
            }

            // If the length of the input is zero, return the input
            // If the length of the input is one, return input.ToUpper()
            switch (input.Length)
            {
                case 0:
                    return input;
                case 1:
                    return input.ToUpper();
            }

            var builder = new System.Text.StringBuilder(input[0].ToString().ToUpper());
            builder.Append(input.Substring(1));
            return builder.ToString();
        }

        /// <summary>
        /// Truncates a <see cref="string"/> to a maximum specified length.
        /// </summary>
        /// <param name="value">
        /// The <see cref="string"/> value to truncate.
        /// </param>
        /// <param name="maxLength">
        /// The maximum length to truncate the <see cref="string"/> to
        /// </param>
        /// <returns>
        /// A truncated <see cref="string"/>
        /// </returns>
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            return value.Length > maxLength ? value.Substring(0, maxLength) : value;
        }

        /// <summary>
        /// Zero-pads a string. 
        /// That is, appends zeroes to the beginning of the string.
        /// </summary>
        /// <param name="value">
        /// A string value to zero-pad.
        /// </param>
        /// <param name="maximumAmountOfZeroes">
        /// The maximum amount of zeroes.
        /// </param>
        /// <param name="maximumLength">
        /// This denotes the maximum length of the result string. Set to -1 for an infinite length.
        /// </param>
        /// <returns>
        /// A zero-padded string.
        /// </returns>
        public static string ZeroPad(this string value, int maximumAmountOfZeroes, int maximumLength = -1)
        {
            if (value == null)
            {
                throw new System.ArgumentNullException(nameof(value));
            }

            if (maximumLength > -1 && value.Length >= maximumLength)
            {
                return value.Substring(0, maximumLength);
            }

            var result = new System.Text.StringBuilder();
            for (var i = 0; i < maximumAmountOfZeroes && (maximumLength == -1 || (maximumLength > -1 && i < maximumLength - value.Length)); i++)
            {
                result.Append("0");
            }

            result.Append(value);

            return result.ToString();
        }
    }
}
