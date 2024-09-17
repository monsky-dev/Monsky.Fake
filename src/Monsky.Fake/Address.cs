namespace Monsky.Fake
{
    public static partial class Faker
    {
        private static readonly Lazy<List<string>> _lazyDomains = new Lazy<List<string>>(() => Settings.LoadStringListFromJsonFile("Domains.json"));

        internal static readonly List<string> _domains = _lazyDomains.Value;

        public static string Email()
        {
            if (!string.IsNullOrWhiteSpace(Settings.Domain))
                return EmailCustomDomain();

            return EmailMonskyDomain();
        }

        public static string PhoneNumber()
        {
            return $"{Number(9_999_999, 1000)}";
        }

        #region Member
        private static string EmailCustomDomain()
        {
            var index = Random.Shared.Next(1, 3);
            string domain = Settings.Domain;
            string emailName = (index % 2 == 0 ? FirstName().ToLower() : LastName().ToLower()) + Number(100, 1).ToString();
            return $"{emailName}@{domain}";
        }

        private static string EmailMonskyDomain()
        {
            var index = Random.Shared.Next(_domains.Count);
            string domain = _domains[index];
            string emailName = (index % 2 == 0 ? FirstName().ToLower() : LastName().ToLower()) + Number(100, 1).ToString();
            return $"{emailName}@{domain}";
        }
        #endregion
    }
}
