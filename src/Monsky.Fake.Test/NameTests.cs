namespace Monsky.Fake.Tests
{
    public class NameTests
    {
        [Fact]
        public void GenerateFirstName()
        {
            var firstName = Faker.FirstName();

            Assert.False(string.IsNullOrWhiteSpace(firstName));
        }

        [Fact]
        public void GenerateLastName()
        {
            var lastName = Faker.LastName();

            Assert.False(string.IsNullOrWhiteSpace(lastName));
        }

        [Fact]
        public void GenerateFullName()
        {
            var fullName = Faker.FullName();

            Assert.False(string.IsNullOrWhiteSpace(fullName));
            Assert.Equal(2, fullName.Split(" ").Length);
        }
    }
}
