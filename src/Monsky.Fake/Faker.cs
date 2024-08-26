using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Monsky.Fake;

public sealed class Faker
{
    private static readonly Lazy<List<string>> _lazyFirstNames = new Lazy<List<string>>(() => LoadStringListFromJsonFile("FirstNames.json"));
    private static readonly Lazy<List<string>> _lazyLastNames = new Lazy<List<string>>(() => LoadStringListFromJsonFile("LastNames.json"));
    private static readonly Lazy<List<string>> _lazyWords = new Lazy<List<string>>(() => LoadStringListFromJsonFile("Words.json"));
    private static readonly Lazy<List<string>> _lazyDomains = new Lazy<List<string>>(() => LoadStringListFromJsonFile("Domains.json"));

    internal static readonly List<string> _firstNames = _lazyFirstNames.Value;
    internal static readonly List<string> _lastNames = _lazyLastNames.Value;
    internal static readonly List<string> _words = _lazyWords.Value;
    internal static readonly List<string> _domains = _lazyDomains.Value;

    #region Names
    public static string FirstName()
    {
        return _firstNames[Random.Shared.Next(_firstNames.Count)];
    }

    public static string LastName()
    {
        return _lastNames[Random.Shared.Next(_firstNames.Count)];
    }

    public static string FullName()
    {
        return $"{_firstNames[Random.Shared.Next(_firstNames.Count)]} {_lastNames[Random.Shared.Next(_lastNames.Count)]}";
    }
    #endregion

    #region Words/Sentences
    public static string Word()
    {
        return _words[Random.Shared.Next(_words.Count)];
    }

    public static string Sentence(int count = 15)
    {
        return string.Join(" ", Enumerable.Range(0, count).Select((_, index) =>
        {
            var word = _words[Random.Shared.Next(_words.Count)].ToLower();
            return index == 0 ? char.ToUpper(word[0]) + word.Substring(1) : word;
        })) + ".";
    }
    #endregion

    #region Address
    public static string Email()
    {
        var index = Random.Shared.Next(_domains.Count);
        string domain = _domains[index];
        string emailName = (index % 2 == 0 ? FirstName().ToLower() : LastName().ToLower()) + Number(100, 1).ToString();
        return $"{emailName}@{domain}";
    }

    public static string PhoneNumber()
    {
        return $"{Number(9_999_999, 1000)}";
    }
    #endregion

    #region Numbers
    public static int Number(int max = 100, int min = 0)
    {
        if (max < min)
            throw new ArgumentException("max must be greater than or equal to min");

        return Random.Shared.Next(min, max);
    }

    public static long Number(long max = 100, long min = 0)
    {
        if (max < min)
            throw new ArgumentException("max must be greater than or equal to min");

        return Random.Shared.NextInt64(min, max);
    }

    public static float Number(float max = 100, float min = 0)
    {
        if (max < min)
            throw new ArgumentException("max must be greater than or equal to min");

        if (min == float.MinValue && max == float.MaxValue)
        {
            if (Random.Shared.Next(0, 2) == 0)
                return -Random.Shared.NextSingle() * float.MaxValue;
            else
                return Random.Shared.NextSingle() * float.MaxValue;
        }

        var randomValue = Random.Shared.NextSingle();
        return min + randomValue * (max - min);
    }

    public static double Number(double max = 100, double min = 0)
    {
        if (max < min)
            throw new ArgumentException("max must be greater than or equal to min");

        if (min == double.MinValue && max == double.MaxValue)
        {
            if (Random.Shared.Next(0, 2) == 0)
                return -Random.Shared.NextSingle() * double.MaxValue;
            else
                return Random.Shared.NextSingle() * double.MaxValue;
        }

        var randomValue = Random.Shared.NextDouble();
        return min + randomValue * (max - min);
    }

    public static decimal Number(decimal max = 100, decimal min = 0)
    {
        if (max < min)
            throw new ArgumentException("max must be greater than or equal to min");

        if (min == decimal.MinValue && max == decimal.MaxValue)
        {
            if (Random.Shared.Next(0, 2) == 0)
            {
                return -1 * (decimal)Random.Shared.NextDouble() * decimal.MaxValue;
            }
            else
            {
                return (decimal)Random.Shared.NextDouble() * decimal.MaxValue;
            }
        }

        double randomValue = Random.Shared.NextDouble();
        return min + (decimal)randomValue * (max - min);
    }
    #endregion

    #region Ids
    public static string GuidString()
    {
        return System.Guid.NewGuid().ToString();
    }

    public static Guid Guid()
    {
        return System.Guid.NewGuid();
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
            int currentYear = DateTimeOffset.UtcNow.Year;
            int shortYear = currentYear % 100;

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
    #endregion

    #region Member
    private static List<string> LoadStringListFromJsonFile(string resourceName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var fullResourceName = $"Monsky.Fake.Data.{resourceName}";

        using Stream? stream = assembly.GetManifestResourceStream(fullResourceName);
        if (stream == null)
            throw new FileNotFoundException($"Embedded resource '{fullResourceName}' not found.");

        using (StreamReader reader = new StreamReader(stream))
        {
            string json = reader.ReadToEnd();
            return JsonSerializer.Deserialize<List<string>>(json) ?? throw new ArgumentNullException("No strings were loaded.");
        }
    }
    #endregion
}
