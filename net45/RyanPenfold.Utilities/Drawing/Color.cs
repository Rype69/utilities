// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Color.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// <date>
//   12 April 2012
// </date>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Drawing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Provides utility functions relating to colors
    /// </summary>
    public static class Color
    {
        /// <summary>
        /// Generates a set of distinct colors
        /// </summary>
        /// <param name="quantity">The amount of colors to generate</param>
        /// <returns>A <see cref="System.Collections.Generic.List{T}" /> object.</returns>
        public static IList<System.Drawing.Color> Generate(long quantity)
        {
            var result = new List<System.Drawing.Color>();

            if (quantity < 1)
            {
                return result;
            }

            var colourGroups = new Dictionary<string, long>
                                   {
                                       ["Pinks"] = 0,
                                       ["Reds"] = 0,
                                       ["Oranges"] = 0,
                                       ["Yellows"] = 0,
                                       ["Greens"] = 0,
                                       ["Cyans"] = 0,
                                       ["Blues"] = 0,
                                       ["Purples"] = 0
                                   };
            // #FF00FF Pinks
            // #FF0000 Reds
            // #FF8000 Oranges
            // #FFFF00 Yellows
            // #00FF00 Greens
            // #00FFFF Cyans
            // #0000FF Blues
            // #8000FF Purples

            var iterations = Convert.ToInt64(Math.Floor(Convert.ToDecimal(quantity / colourGroups.Count)));

            for (var count = 0; count <= (colourGroups.Keys.Count - 1); count++)
            {
                colourGroups[colourGroups.Keys.ElementAt(count)] += iterations;
            }

            var remainder = quantity % colourGroups.Count;

            switch (remainder)
            {
                case 1:
                    colourGroups["Yellows"] += 1;
                    break;
                case 2:
                    colourGroups["Reds"] += 1;
                    colourGroups["Greens"] += 1;
                    break;
                case 3:
                    colourGroups["Reds"] += 1;
                    colourGroups["Oranges"] += 1;
                    colourGroups["Greens"] += 1;
                    break;
                case 4:
                    colourGroups["Reds"] += 1;
                    colourGroups["Yellows"] += 1;
                    colourGroups["Greens"] += 1;
                    colourGroups["Blues"] += 1;
                    break;
                case 5:
                    colourGroups["Reds"] += 1;
                    colourGroups["Yellows"] += 1;
                    colourGroups["Greens"] += 1;
                    colourGroups["Cyans"] += 1;
                    colourGroups["Blues"] += 1;
                    break;
                case 6:
                    colourGroups["Reds"] += 1;
                    colourGroups["Oranges"] += 1;
                    colourGroups["Yellows"] += 1;
                    colourGroups["Greens"] += 1;
                    colourGroups["Cyans"] += 1;
                    colourGroups["Blues"] += 1;
                    break;
                case 7:
                    colourGroups["Reds"] += 1;
                    colourGroups["Oranges"] += 1;
                    colourGroups["Yellows"] += 1;
                    colourGroups["Greens"] += 1;
                    colourGroups["Cyans"] += 1;
                    colourGroups["Blues"] += 1;
                    colourGroups["Purples"] += 1;
                    break;
            }

            foreach (var key in colourGroups.Keys)
            {
                for (var item = 1; item <= colourGroups[key]; item++)
                {
                    switch (key)
                    {
                        case "Pinks":
                            switch (colourGroups[key] > 1)
                            {
                                case true:
                                    result.Add(System.Drawing.Color.FromArgb(255, 0, 255 - Convert.ToInt32((255 / colourGroups[key]) * item)));
                                    break;
                                case false:
                                    result.Add(System.Drawing.Color.FromArgb(255, 0, 255));
                                    break;
                            }

                            break;
                        case "Reds":
                            switch (colourGroups[key] > 1)
                            {
                                case true:
                                    result.Add(System.Drawing.Color.FromArgb(255, Convert.ToInt32((128 / colourGroups[key]) * item), 0));
                                    break;
                                case false:
                                    result.Add(System.Drawing.Color.FromArgb(255, 0, 0));
                                    break;
                            }

                            break;
                        case "Oranges":
                            switch (colourGroups[key] > 1)
                            {
                                case true:
                                    result.Add(System.Drawing.Color.FromArgb(255, 127 + Convert.ToInt32((128 / colourGroups[key]) * item), 0));
                                    break;
                                case false:
                                    result.Add(System.Drawing.Color.FromArgb(255, 128, 0));
                                    break;
                            }

                            break;
                        case "Yellows":
                            switch (colourGroups[key] > 1)
                            {
                                case true:
                                    result.Add(System.Drawing.Color.FromArgb(255 - Convert.ToInt32((255 / colourGroups[key]) * item), 255, 0));
                                    break;
                                case false:
                                    result.Add(System.Drawing.Color.FromArgb(255, 255, 0));
                                    break;
                            }

                            break;
                        case "Greens":
                            switch (colourGroups[key] > 1)
                            {
                                case true:
                                    result.Add(System.Drawing.Color.FromArgb(0, 255, Convert.ToInt32((255 / colourGroups[key]) * item)));
                                    break;
                                case false:
                                    result.Add(System.Drawing.Color.FromArgb(0, 255, 0));
                                    break;
                            }

                            break;
                        case "Cyans":
                            switch (colourGroups[key] > 1)
                            {
                                case true:
                                    result.Add(System.Drawing.Color.FromArgb(0, 255 - Convert.ToInt32((255 / colourGroups[key]) * item), 255));
                                    break;
                                case false:
                                    result.Add(System.Drawing.Color.FromArgb(0, 255, 255));
                                    break;
                            }

                            break;
                        case "Blues":
                            switch (colourGroups[key] > 1)
                            {
                                case true:
                                    result.Add(System.Drawing.Color.FromArgb(Convert.ToInt32((128 / colourGroups[key]) * item), 0, 255));
                                    break;
                                case false:
                                    result.Add(System.Drawing.Color.FromArgb(0, 0, 255));
                                    break;
                            }

                            break;
                        case "Purples":
                            switch (colourGroups[key] > 1)
                            {
                                case true:
                                    result.Add(System.Drawing.Color.FromArgb(127 + Convert.ToInt32((128 / colourGroups[key]) * item), 0, 255));
                                    break;
                                case false:
                                    result.Add(System.Drawing.Color.FromArgb(128, 0, 255));
                                    break;
                            }

                            break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Gets a color that is the inverse of the given color
        /// </summary>
        /// <param name="color">A color to invert</param>
        /// <returns>A color that is the inverse of the given color</returns>
        public static System.Drawing.Color ToInverse(this System.Drawing.Color color)
        {
            return System.Drawing.Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
        }

        /// <summary>
        /// Gets a font color for a given background color
        /// </summary>
        /// <param name="color">A background color that requires a font color</param>
        /// <returns>A font color for a given background color</returns>
        public static System.Drawing.Color GetFontColor(this System.Drawing.Color color)
        {
            System.Drawing.Color result;

            if (color.B < 26)
            {
                if (color.R < 26)
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
                else if (color.R < 77)
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
                else if (color.R < 128)
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
                else if (color.R < 179)
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
                else if (color.R < 230)
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
                else
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
            }
            else if (color.B < 77)
            {
                if (color.R < 26)
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
                else if (color.R < 77)
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
                else if (color.R < 128)
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
                else if (color.R < 179)
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
                else if (color.R < 230)
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
                else
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
            }
            else if (color.B < 128)
            {
                if (color.R < 26)
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
                else if (color.R < 77)
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
                else if (color.R < 128)
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
                else if (color.R < 179)
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
                else if (color.R < 230)
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
                else
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
            }
            else if (color.B < 179)
            {
                if (color.R < 26)
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
                else if (color.R < 77)
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
                else if (color.R < 128)
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
                else if (color.R < 179)
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
                else if (color.R < 230)
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
                else
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
            }
            else if (color.B < 230)
            {
                if (color.R < 26)
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
                else if (color.R < 77)
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
                else if (color.R < 128)
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
                else if (color.R < 179)
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
                else if (color.R < 230)
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
                else
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
            }
            else
            {
                if (color.R < 26)
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
                else if (color.R < 77)
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
                else if (color.R < 128)
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
                else if (color.R < 179)
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.White;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
                else if (color.R < 230)
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
                else
                {
                    if (color.G < 26)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 77)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 128)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 179)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else if (color.G < 230)
                    {
                        result = System.Drawing.Color.Black;
                    }
                    else
                    {
                        result = System.Drawing.Color.Black;
                    }
                }
            }

            return result;
        }
    }
}
