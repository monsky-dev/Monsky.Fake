using System.Text.RegularExpressions;

namespace Monsky.Fake.Tests
{
    public class EmailTests
    {
        private const string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        public EmailTests()
        {
            Settings.Domain = string.Empty;
        }

        [Fact]
        public void GenerateDomain()
        {
            var email = Faker.Email();

            Assert.False(string.IsNullOrWhiteSpace(email));
            Assert.EndsWith("monsky.dev", email);
            Assert.Matches(emailPattern, email);
        }

        [Fact]
        public void GenerateCustomDomain()
        {
            Settings.Domain = "test.de";
            var email = Faker.Email();

            Assert.False(string.IsNullOrWhiteSpace(email));
            Assert.EndsWith("@test.de", email);
            Assert.Matches(emailPattern, email);
        }
    }
}
