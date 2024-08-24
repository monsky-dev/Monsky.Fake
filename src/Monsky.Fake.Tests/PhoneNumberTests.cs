namespace Monsky.Fake.Tests
{
    public class PhoneNumberTests
    {
        [Fact]
        public void GeneratePhoneNumber()
        {
            var phoneNumber = Faker.PhoneNumber();
            var parsedPhoneNumber = int.Parse(phoneNumber);

            Assert.False(string.IsNullOrWhiteSpace(phoneNumber));
            Assert.InRange(phoneNumber.Length, 4, 7);
            Assert.InRange(parsedPhoneNumber, 1000, 9_999_999);
        }
    }
}
