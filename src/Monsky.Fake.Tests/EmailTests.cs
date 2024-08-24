using System.Text.RegularExpressions;

namespace Monsky.Fake.Tests
{
    public class EmailTests
    {
        private const string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        [Fact]
        public void GenerateDomain()
        {
            var email = Faker.Email();

            Assert.False(string.IsNullOrWhiteSpace(email));
            Assert.EndsWith("monsky.dev", email);
            Assert.Matches(emailPattern, email);
        }
    }
}
