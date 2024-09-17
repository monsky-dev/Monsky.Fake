namespace Monsky.Fake.Tests
{
    public class TextTests
    {
        [Theory]
        [InlineData(5, 5)]
        [InlineData(10, 10)]
        [InlineData(100, 100)]
        [InlineData(5000, 5000)]
        [InlineData(50000, 50000)]
        [InlineData(500000, 500000)]
        public void GenerateText(uint count, int expected)
        {
            var text = Faker.Text(count);

            Assert.NotNull(text);
            Assert.False(string.IsNullOrWhiteSpace(text));
            Assert.Equal(expected, text.Split(' ').Length);
        }
    }
}
