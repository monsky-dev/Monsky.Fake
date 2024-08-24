namespace Monsky.Fake.Tests
{
    public class SentenceTests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(5, 5)]
        [InlineData(10, 10)]
        [InlineData(100, 100)]
        [InlineData(5000, 5000)]
        public void GenerateSentence(int count, int expected)
        {
            var sentence = Faker.Sentence(count);

            Assert.NotNull(sentence);
            Assert.Equal(expected, sentence.Split(" ").Length);
            Assert.True(sentence.EndsWith('.'));
        }
    }
}
