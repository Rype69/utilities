// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Random.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities
{
    using System.Linq;

    /// <summary>
    /// Provides extension methods and methods relating to <see cref="System.Random"/> instances.
    /// </summary>
    public static class Random
    {
        /// <summary>
        /// A random generator.
        /// </summary>
        private static readonly System.Random RandomGenerator;

        /// <summary>
        /// Initializes static members of the <see cref="Random"/> class.
        /// </summary>
        static Random()
        {
            var ticksString = System.DateTime.Now.Ticks.ToString(System.Globalization.CultureInfo.InvariantCulture);
            RandomGenerator = ticksString.Length > 9
                ? new System.Random(System.Convert.ToInt32(ticksString.Substring(ticksString.Length - 9, 9)))
                : new System.Random(System.Convert.ToInt32(ticksString));
        }

        /// <summary>
        /// Produces a random <see cref="bool"/> value.
        /// </summary>
        /// <returns>A <see cref="bool"/>.</returns>
        public static bool NextBoolean()
        {
            return RandomGenerator.Next() % 2 == 0;
        }

        /// <summary>
        /// Produces a random a<see cref="byte"/> value.
        /// </summary>
        /// <returns> A <see cref="byte"/>.</returns>
        public static byte NextByte()
        {
            return NextByte(byte.MinValue, byte.MaxValue);
        }

        /// <summary>
        /// Produces a random a<see cref="byte"/> value.
        /// </summary>
        /// <param name="maxValue">The lower bounds of a value to produce.</param>
        /// <returns> A <see cref="byte"/>.</returns>
        public static byte NextByte(byte maxValue)
        {
            return NextByte(byte.MinValue, maxValue);
        }

        /// <summary>
        /// Produces a random a<see cref="byte"/> value.
        /// </summary>
        /// <param name="minValue">The upper bounds of a value to produce.</param>
        /// <param name="maxValue">The lower bounds of a value to produce.</param>
        /// <returns> A <see cref="byte"/>.</returns>
        public static byte NextByte(byte minValue, byte maxValue)
        {
            if (minValue > maxValue)
            {
                throw new System.ArgumentOutOfRangeException(nameof(minValue), "cannot be greater than maxValue.");
            }

            return (byte)RandomGenerator.Next(minValue, maxValue);
        }

        /// <summary>
        /// Produces a random array of <see cref="byte"/>s.
        /// </summary>
        /// <param name="length">
        /// The length of the array.
        /// </param>
        /// <returns>
        /// An array of <see cref="byte"/>s.
        /// </returns>
        public static byte[] NextBytes(long length = 16)
        {
            var buffer = new byte[length];
            RandomGenerator.NextBytes(buffer);
            return buffer;
        }

        /// <summary>
        /// Produces a random <see cref="char"/>.
        /// </summary>
        /// <returns>A <see cref="char"/></returns>
        public static char NextChar()
        {
            return (char)NextUInt16();
        }

        /// <summary>
        /// Produces a random <see cref="System.DateTime"/>.
        /// </summary>
        /// <param name="includeTime">Indicates whether to include the time portion.</param>
        /// <returns>A <see cref="System.DateTime"/></returns>
        public static System.DateTime NextDateTime(bool includeTime = true)
        {
            return NextDateTime(System.DateTime.MinValue, System.DateTime.MaxValue, includeTime);
        }

        /// <summary>
        /// Produces a random <see cref="System.DateTime"/>.
        /// </summary>
        /// <param name="maxValue">The upper bounds of a value to produce.</param>
        /// <param name="includeTime">Indicates whether to include the time portion.</param>
        /// <returns>A <see cref="System.DateTime"/>.</returns>
        public static System.DateTime NextDateTime(System.DateTime maxValue, bool includeTime = true)
        {
            return NextDateTime(System.DateTime.MinValue, maxValue, includeTime);
        }

        /// <summary>
        /// Produces a random <see cref="System.DateTime"/>.
        /// </summary>
        /// <param name="minValue">The upper bounds of a value to produce.</param>
        /// <param name="maxValue">The lower bounds of a value to produce.</param>
        /// <param name="includeTime">Indicates whether to include the time portion.</param>
        /// <returns>A <see cref="System.DateTime"/>.</returns>
        public static System.DateTime NextDateTime(System.DateTime minValue, System.DateTime maxValue, bool includeTime = true)
        {
            if (minValue > maxValue)
            {
                throw new System.ArgumentOutOfRangeException(nameof(minValue), "cannot be greater than maxValue.");
            }

            var year = NextInt32(minValue.Year, maxValue.Year);
            int month;
            var minDay = 1;
            int maxDay;

            if (year == minValue.Year)
            {
                month = RandomGenerator.Next(minValue.Month, 12);
                minDay = minValue.Day;
                maxDay = DateTime.MaxDayOfMonth((byte)month, (short)year);
            }
            else if (year == maxValue.Year)
            {
                month = RandomGenerator.Next(1, maxValue.Month);
                maxDay = maxValue.Day;
            }
            else
            {
                month = RandomGenerator.Next(1, 12);
                maxDay = DateTime.MaxDayOfMonth((byte)month, (short)year);
            }

            var day = NextInt32(minDay, maxDay);

            int hour;
            int minute;
            int second;
            int millisecond;

            const int MinHour = 0;
            const int MaxHour = 23;
            const int MinMinute = 0;
            const int MaxMinute = 59;
            const int MinSecond = 0;
            const int MaxSecond = 59;
            const int MinMillisecond = 0;
            const int MaxMillisecond = 999;

            if (year == minValue.Year && month == minValue.Month && day == minValue.Day)
            {
                hour = RandomGenerator.Next(minValue.Hour, MaxHour);

                if (hour == minValue.Hour)
                {
                    minute = RandomGenerator.Next(minValue.Minute, MaxMinute);

                    if (minute == minValue.Minute)
                    {
                        second = RandomGenerator.Next(minValue.Second, MaxSecond);
                        millisecond = RandomGenerator.Next(second == minValue.Second ? minValue.Millisecond : MinMillisecond, MaxMillisecond);
                    }
                    else
                    {
                        second = RandomGenerator.Next(MinSecond, MaxSecond);
                        millisecond = RandomGenerator.Next(MinMillisecond, MaxMillisecond);
                    }
                }
                else
                {
                    minute = RandomGenerator.Next(MinMinute, MaxMinute);
                    second = RandomGenerator.Next(MinSecond, MaxSecond);
                    millisecond = RandomGenerator.Next(MinMillisecond, MaxMillisecond);
                }
            }
            else if (year == maxValue.Year && month == maxValue.Month && day == maxValue.Day)
            {
                hour = RandomGenerator.Next(MinHour, maxValue.Hour);

                if (hour == maxValue.Hour)
                {
                    minute = RandomGenerator.Next(1, maxValue.Hour);

                    if (minute == maxValue.Minute)
                    {
                        second = RandomGenerator.Next(MinSecond, maxValue.Second);
                        millisecond = RandomGenerator.Next(MinMillisecond, second == maxValue.Second ? maxValue.Millisecond : MaxMillisecond);
                    }
                    else
                    {
                        second = RandomGenerator.Next(MinSecond, MaxSecond);
                        millisecond = RandomGenerator.Next(MinMillisecond, MaxMillisecond);
                    }
                }
                else
                {
                    minute = RandomGenerator.Next(MinMinute, MaxMinute);
                    second = RandomGenerator.Next(MinSecond, MaxSecond);
                    millisecond = RandomGenerator.Next(MinMillisecond, MaxMillisecond);
                }
            }
            else
            {
                hour = RandomGenerator.Next(MinHour, MaxHour);
                minute = RandomGenerator.Next(MinMinute, MaxMinute);
                second = RandomGenerator.Next(MinSecond, MaxSecond);
                millisecond = RandomGenerator.Next(MinMillisecond, MaxMillisecond);
            }

            return new System.DateTime(
                        year, 
                        month, 
                        day,
                        includeTime ? hour : 0,
                        includeTime ? minute : 0,
                        includeTime ? second : 0,
                        includeTime ? millisecond : 0);
        }

        /// <summary>
        /// Produces a random <see cref="System.DateTimeOffset"/> value.
        /// </summary>
        /// <returns>A <see cref="System.DateTimeOffset"/>.</returns>
        public static System.DateTimeOffset NextDateTimeOffset()
        {
            return NextDateTimeOffset(System.DateTime.MinValue, System.DateTime.MaxValue);
        }

        /// <summary>
        /// Produces a random <see cref="System.DateTimeOffset"/> value.
        /// </summary>
        /// <param name="maxValue">The upper bounds of a value to produce.</param>
        /// <returns>A <see cref="System.DateTimeOffset"/>.</returns>
        public static System.DateTimeOffset NextDateTimeOffset(System.DateTimeOffset maxValue)
        {
            return NextDateTimeOffset(System.DateTime.MinValue, maxValue.DateTime);
        }

        /// <summary>
        /// Produces a random <see cref="System.DateTimeOffset"/> value.
        /// </summary>
        /// <param name="minValue">The lower bounds of a value to produce.</param>
        /// <param name="maxValue">The upper bounds of a value to produce.</param>
        /// <returns>A <see cref="System.DateTimeOffset"/>.</returns>
        public static System.DateTimeOffset NextDateTimeOffset(System.DateTimeOffset minValue, System.DateTimeOffset maxValue)
        {
            if (minValue > maxValue)
            {
                throw new System.ArgumentOutOfRangeException(nameof(minValue), "cannot be greater than maxValue.");
            }

            return new System.DateTimeOffset(NextDateTime(minValue.DateTime, maxValue.DateTime));
        }

        /// <summary>
        /// Produces a random <see cref="decimal"/> value.
        /// </summary>
        /// <returns>A <see cref="decimal"/>.</returns>
        public static decimal NextDecimal()
        {
            var scale = NextByte(1, 29);
            var sign = NextBoolean();
            return new decimal(
                NextInt32(),
                NextInt32(),
                NextInt32(),
                sign,
                scale);
        }

        /// <summary>
        /// Produces a random <see cref="decimal"/> value.
        /// </summary>
        /// <param name="maxValue">The upper bounds of a value to produce.</param>
        /// <returns>A <see cref="decimal"/>.</returns>
        public static decimal NextDecimal(decimal maxValue)
        {
            return NextDecimal(decimal.MinValue, maxValue);
        }

        /// <summary>
        /// Produces a random <see cref="decimal"/> value.
        /// </summary>
        /// <param name="minValue">The lower bounds of a value to produce.</param>
        /// <param name="maxValue">The upper bounds of a value to produce.</param>
        /// <returns>A <see cref="decimal"/>.</returns>
        public static decimal NextDecimal(decimal minValue, decimal maxValue)
        {
            if (minValue > maxValue)
            {
                throw new System.ArgumentOutOfRangeException(nameof(minValue), "cannot be greater than maxValue.");
            }

            var nextDecimalSample = NextDecimal();
            return (maxValue * nextDecimalSample) + (minValue * (1 - nextDecimalSample));
        }

        /// <summary>
        /// Produces a random <see cref="double"/> value.
        /// </summary>
        /// <returns>A <see cref="double"/>.</returns>
        public static double NextDouble()
        {
            return NextDouble(double.MinValue, double.MaxValue);
        }

        /// <summary>
        /// Produces a random <see cref="double"/> value.
        /// </summary>
        /// <param name="maxValue">The upper bounds of a value to produce.</param>
        /// <returns>A <see cref="double"/>.</returns>
        public static double NextDouble(double maxValue)
        {
            return NextDouble(double.MinValue, maxValue);
        }

        /// <summary>
        /// Produces a random <see cref="double"/> value.
        /// </summary>
        /// <param name="minValue">The lower bounds of a value to produce.</param>
        /// <param name="maxValue">The upper bounds of a value to produce.</param>
        /// <returns>A <see cref="double"/>.</returns>
        public static double NextDouble(double minValue, double maxValue)
        {
            return (RandomGenerator.NextDouble() * (maxValue - minValue)) + minValue;
        }
        
        /// <summary>
         /// Produces a random <see cref="short"/> value.
         /// </summary>
         /// <returns>A <see cref="short"/>.</returns>
        public static short NextInt16()
        {
            return NextInt16(short.MinValue, short.MaxValue);
        }

        /// <summary>
        /// Produces a random <see cref="short"/> value.
        /// </summary>
        /// <param name="maxValue">The upper bounds of a value to produce.</param>
        /// <returns>A <see cref="short"/>.</returns>
        public static short NextInt16(short maxValue)
        {
            return NextInt16(short.MinValue, maxValue);
        }

        /// <summary>
        /// Produces a random <see cref="short"/> value.
        /// </summary>
        /// <param name="minValue">The lower bounds of a value to produce.</param>
        /// <param name="maxValue">The upper bounds of a value to produce.</param>
        /// <returns>A <see cref="short"/>.</returns>
        public static short NextInt16(short minValue, short maxValue)
        {
            if (minValue > maxValue)
            {
                throw new System.ArgumentOutOfRangeException(nameof(minValue), "cannot be greater than maxValue.");
            }

            return (short)RandomGenerator.Next(minValue, maxValue);
        }

        /// <summary>
        /// Produces a random <see cref="int"/> value.
        /// </summary>
        /// <returns>A <see cref="int"/>.</returns>
        public static int NextInt32()
        {
            return RandomGenerator.Next();
        }

        /// <summary>
        /// Produces a random <see cref="int"/> value.
        /// </summary>
        /// <param name="maxValue">The upper bounds of a value to produce.</param>
        /// <returns>A <see cref="int"/>.</returns>
        public static int NextInt32(int maxValue)
        {
            return RandomGenerator.Next(maxValue);
        }

        /// <summary>
        /// Produces a random <see cref="int"/> value.
        /// </summary>
        /// <param name="minValue">The lower bounds of a value to produce.</param>
        /// <param name="maxValue">The upper bounds of a value to produce.</param>
        /// <returns>A <see cref="int"/>.</returns>
        public static int NextInt32(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new System.ArgumentOutOfRangeException(nameof(minValue), "cannot be greater than maxValue.");
            }

            return RandomGenerator.Next(minValue, maxValue);
        }

        /// <summary>
        /// Produces a random <see cref="long"/> value.
        /// </summary>
        /// <returns>A <see cref="long"/>.</returns>
        public static long NextInt64()
        {
            return NextInt64(long.MinValue, long.MaxValue);
        }

        /// <summary>
        /// Produces a random <see cref="long"/> value.
        /// </summary>
        /// <param name="maxValue">The upper bounds of a value to produce.</param>
        /// <returns>A <see cref="long"/>.</returns>
        public static long NextInt64(long maxValue)
        {
            return NextInt64(long.MinValue, maxValue);
        }

        /// <summary>
        /// Produces a random <see cref="long"/> value.
        /// </summary>
        /// <param name="minValue">The lower bounds of a value to produce..</param>
        /// <param name="maxValue">The upper bounds of a value to produce.</param>
        /// <returns>A <see cref="long"/>.</returns>
        public static long NextInt64(long minValue, long maxValue)
        {
            if (minValue > maxValue)
            {
                throw new System.ArgumentOutOfRangeException(nameof(minValue), "cannot be greater than maxValue.");
            }

            var buffer = new byte[8];
            RandomGenerator.NextBytes(buffer);

            return System.Math.Abs(System.BitConverter.ToInt64(buffer, 0) % (maxValue - minValue)) + minValue;
        }

        /// <summary>
        /// Produces a random <see cref="float"/> value.
        /// </summary>
        /// <returns>A <see cref="float"/>.</returns>
        public static float NextSingle()
        {
            return NextSingle(float.MinValue, float.MaxValue);
        }

        /// <summary>
        /// Produces a random <see cref="float"/> value.
        /// </summary>
        /// <param name="maxValue">The upper bounds of a value to produce.</param>
        /// <returns>A <see cref="float"/>.</returns>
        public static float NextSingle(float maxValue)
        {
            return NextSingle(float.MinValue, maxValue);
        }

        /// <summary>
        /// Produces a random <see cref="float"/> value.
        /// </summary>
        /// <param name="minValue">The lower bounds of a value to produce.</param>
        /// <param name="maxValue">The upper bounds of a value to produce.</param>
        /// <returns>A <see cref="float"/>.</returns>
        public static float NextSingle(float minValue, float maxValue)
        {
            return (float)(RandomGenerator.NextDouble() * (maxValue - minValue)) + minValue;
        }

        /// <summary>
        /// Produces a random <see cref="string"/> value.
        /// </summary>
        /// <param name="length">The length of string to produce.</param>
        /// <returns>A <see cref="string"/>.</returns>
        public static string NextString(int length = 10)
        {
            return new string(Enumerable.Repeat("!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~", length)
              .Select(s => s[RandomGenerator.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Produces a random <see cref="System.TimeSpan"/> instance.
        /// </summary>
        /// <returns>A <see cref="System.TimeSpan"/> instance.</returns>
        public static System.TimeSpan NextTimeSpan()
        {
            return new System.TimeSpan(0, NextInt32(0, 23), NextInt32(0, 59), NextInt32(0, 59), NextInt32(0, 999));
        }

        /// <summary>
        /// Produces a random <see cref="ushort"/> value.
        /// </summary>
        /// <returns>A <see cref="ushort"/>.</returns>
        public static ushort NextUInt16()
        {
            return (ushort)RandomGenerator.Next(ushort.MinValue, ushort.MaxValue);
        }
    }
}
