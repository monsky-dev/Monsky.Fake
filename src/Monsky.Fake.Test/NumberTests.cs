using Monsky.Fake.Tests.TestData;

namespace Monsky.Fake.Tests
{
    public class NumberTests
    {
        [Theory]
        [ClassData(typeof(IntNumberTestData))]

        public void GenerateIntNumber(int max, int min)
        {
            var number = Faker.Number(max, min);

            Assert.InRange<int>(number, min, max);
        }

        [Theory]
        [ClassData(typeof(LongNumberTestData))]
        public void GenerateLongNumber(long max, long min)
        {
            var number = Faker.Number(max, min);

            Assert.InRange<long>(number, min, max);
        }

        [Theory]
        [ClassData(typeof(FloatNumberTestData))]
        public void GenerateFloatNumber(float max, float min)
        {
            var number = Faker.Number(max, min);

            Assert.InRange<float>(number, min, max);
        }

        [Theory]
        [ClassData(typeof(DoubleNumberTestData))]
        public void GenerateDoubleNumber(double max, double min)
        {
            var number = Faker.Number(max, min);

            Assert.InRange<double>(number, min, max);
        }

        [Theory]
        [ClassData(typeof(DecimalNumberTestData))]
        public void GenerateDecimalNumber(decimal max, decimal min)
        {
            var number = Faker.Number(max, min);

            Assert.InRange<decimal>(number, min, max);
        }
    }
}
