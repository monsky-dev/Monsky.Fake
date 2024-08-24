using System.Reflection;
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
