namespace Monsky.Fake
{
    public static partial class Faker
    {
        private static readonly Lazy<List<string>> _lazyWords = new Lazy<List<string>>(() => Settings.LoadStringListFromJsonFile("Words.json"));

        internal static readonly List<string> _words = _lazyWords.Value;

        public static string Word()
        {
            return _words[Random.Shared.Next(_words.Count)];
        }

        public static string Sentence(uint count = 15)
        {
            return string.Join(" ", Enumerable.Range(0, (int)count).Select((_, index) =>
            {
                var word = _words[Random.Shared.Next(_words.Count)].ToLower();
                return index == 0 ? char.ToUpper(word[0]) + word.Substring(1) : word;
            })) + ".";
        }

        public static string Text(uint count = 100)
        {
            if (count < 5)
                throw new ArgumentException("Minimum length is 5");

            var parts = SplitToRandomLengths((int)count);

            return string.Join(" ", Enumerable.Range(0, parts.Count).Select((_, index) =>
            {
                return Sentence((uint)parts[index]);
            }));
        }

        #region Member
        private static List<int> SplitToRandomLengths(int total)
        {
            List<int> parts = new List<int>();

            while (total > 5)
            {
                int maxPart = Math.Min(total, 10);
                int part = Random.Shared.Next(5, maxPart + 1);
                parts.Add(part);
                total -= part;
            }

            if (total > 0)
                parts.Add(total);

            return parts;
        }
        #endregion
    }
}
