using System;
using System.Text;

namespace Monsky.Fake
{
    public static partial class Faker
    {
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public static string GuidString()
        {
            return Guid().ToString();
        }

        public static string ReverseGuidString()
        {
            return new string(Guid().ToString().Reverse().ToArray());
        }

        public static Guid Guid()
        {
            return System.Guid.NewGuid();
        }

        public static string Id(uint length)
        {
            return new string(Enumerable.Repeat(chars, (int)length)
                .Select(s => s[Random.Shared.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Generates a custom ID string based on a specified pattern.
        /// The pattern can contain the following placeholders:
        /// - '#' for digits (0-9)
        /// - '*' for uppercase letters (A-Z)
        /// 
        /// Any other characters in the pattern will be treated as literals and included in the result.
        /// However, be cautious when using special characters as they may interfere with the pattern parsing.
        /// 
        /// Additionally, the entire pattern is automatically converted to uppercase, so any lowercase letters
        /// in the pattern will be transformed into their uppercase equivalents.
        /// 
        /// If no pattern is provided, the default pattern "#####-#*#*-*#*#-**" is used.
        /// Example result for the default pattern: "12345-A1B2-3C4D-EF".
        /// </summary>
        /// <param name="pattern">
        /// The pattern that defines the structure of the ID. Use:
        /// - '#' for a random digit (0-9)
        /// - '*' for a random uppercase letter (A-Z)
        /// Any other characters will remain unchanged in the result.
        /// Special characters might cause issues and should be used with caution.
        /// If null or empty, the default pattern "#####-#*#*-*#*#-**" will be used.
        /// </param>
        /// <returns>
        /// A generated ID string based on the provided pattern. 
        /// The result will match the pattern where digits and letters are placed randomly,
        /// and all letters are uppercase.
        /// </returns>
        public static string Id(string pattern = "#####-#*#*-*#*#-**")
        {
            if (string.IsNullOrWhiteSpace(pattern))
                pattern = "#####-#*#*-*#*#-**";

            var sb = new StringBuilder();

            pattern = pattern.ToUpper();

            for (int i = 0; i < pattern.Length; i++)
            {
                char c = pattern[i];

                if (c == '#')
                {
                    sb.Append(Random.Shared.Next(0, 10));
                }
                else if (c == '*')
                {
                    sb.Append((char)Random.Shared.Next('A', 'Z' + 1));
                }
                else
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }
    }
}
