namespace Monsky.Fake.Tests
{
    public class WordTests
    {
        [Fact]
        public void GenerateWord()
        {
            var word = Faker.Word();

            Assert.False(string.IsNullOrWhiteSpace(word));
        }
    }
}
