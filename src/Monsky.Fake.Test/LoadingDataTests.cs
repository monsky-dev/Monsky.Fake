using Monsky.Fake;

namespace Monsky.Fake.Tests
{
    public class LoadingDataTests
    {
        [Fact]

        public void LoadingFirstNames()
        {
            var firstNames = Faker._firstNames;

            Assert.NotNull(firstNames);
            Assert.True(firstNames.Any());
        }

        [Fact]

        public void LoadingLastNames()
        {
            var lastNames = Faker._lastNames;

            Assert.NotNull(lastNames);
            Assert.True(lastNames.Any());
        }

        [Fact]

        public void LoadingDomains()
        {
            var domains = Faker._domains;

            Assert.NotNull(domains);
            Assert.True(domains.Any());
        }

        [Fact]

        public void LoadingWords()
        {
            var words = Faker._words;

            Assert.NotNull(words);
            Assert.True(words.Any());
        }
    }
}
