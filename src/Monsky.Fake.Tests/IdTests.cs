namespace Monsky.Fake.Tests
{
    public class IdTests
    {
        private const string guidPattern = @"^[a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12}$";
        private const string reverseGuidPattern = @"^[a-fA-F0-9]{12}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{8}$";
        private const string defaultIdPattern = @"^\d{5}-\d[A-Z]\d[A-Z]-[A-Z]\d[A-Z]\d-[A-Z]{2}$";

        [Fact]
        public void GenerateGuid()
        {
            var guid = Faker.Guid();
            var guidString = guid.ToString();
            var splittedGuidString = guidString.Split('-');

            Assert.IsType<Guid>(guid);
            Assert.Equal(36, guidString.Length);
            Assert.Matches(guidPattern, guidString);
        }

        [Fact]
        public void GenerateGuidString()
        {
            var guid = Faker.GuidString();

            Assert.IsType<string>(guid);
            Assert.Equal(36, guid.Length);
            Assert.Matches(guidPattern, guid);
        }

        [Fact]
        public void GenerateReverseGuidString()
        {
            var guid = Faker.ReverseGuidString();

            Assert.IsType<string>(guid);
            Assert.Equal(36, guid.Length);
            Assert.Matches(reverseGuidPattern, guid);
        }

        [Fact]
        public void GenerateId()
        {
            var id = Faker.Id();

            Assert.IsType<string>(id);
            Assert.Matches(defaultIdPattern, id);
        }

        [Theory]
        [InlineData(44)]
        [InlineData(22)]
        [InlineData(256)]
        [InlineData(0)]
        public void GenerateIdCustomLength(int length)
        {
            var id = Faker.Id(56);

            Assert.IsType<string>(id);
            Assert.Equal(56, id.Length);
            Assert.Matches("^[a-zA-Z0-9]+$", id);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("     ")]
        [InlineData(null)]
        public void GenerateId_InvalidPattern_UseDefaultPattern(string? pattern)
        {
            var id = Faker.Id(pattern!);

            Assert.IsType<string>(id);
            Assert.Matches(defaultIdPattern, id);
        }

        [Theory]
        [InlineData("******_******_######-######-YYYY", @"^[A-Z]{6}_[A-Z]{6}_\d{6}-\d{6}-YYYY$")]
        [InlineData("######################", @"^\d{20}")]
        [InlineData("#####/*****/#####-*#*#*#", @"^\d{5}/[A-Z]{5}/\d{5}-[A-Z]\d[A-Z]\d[A-Z]\d$")]
        [InlineData("****-****-****-******-yyy", @"^[A-Z]{4}-[A-Z]{4}-[A-Z]{4}-[A-Z]{6}-YYY$")]
        [InlineData("******_******_######-######-24", @"^[A-Z]{6}_[A-Z]{6}_\d{6}-\d{6}-24$")]
        [InlineData("******_******_######-######-2024", @"^[A-Z]{6}_[A-Z]{6}_\d{6}-\d{6}-2024$")]
        [InlineData("******+******+######+######+2024", @"^[A-Z]{6}\+[A-Z]{6}\+\d{6}\+\d{6}\+2024$")]
        public void GenerateId_CustomPattern(string idPattern, string regexIdPattern)
        {
            var id = Faker.Id(idPattern);

            Assert.IsType<string>(id);
            Assert.Matches(regexIdPattern, id);
        }
    }
}
