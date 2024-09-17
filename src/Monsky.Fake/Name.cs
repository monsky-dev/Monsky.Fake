namespace Monsky.Fake
{
    public static partial class Faker
    {
        private static readonly Lazy<List<string>> _lazyFirstNames = new Lazy<List<string>>(() => Settings.LoadStringListFromJsonFile("FirstNames.json"));
        private static readonly Lazy<List<string>> _lazyLastNames = new Lazy<List<string>>(() => Settings.LoadStringListFromJsonFile("LastNames.json"));

        internal static readonly List<string> _firstNames = _lazyFirstNames.Value;
        internal static readonly List<string> _lastNames = _lazyLastNames.Value;

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
    }
}
