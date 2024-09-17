using Monsky.Fake.Tests.TestData;

namespace Monsky.Fake.Tests
{
    public class NumberTests
    {
        [Theory]
        [ClassData(typeof(IntMaxMinNumberTestData))]

        public void GenerateIntMaxMinNumber(int max, int min)
        {
            var number = Faker.Number(max, min);

            Assert.InRange<int>(number, min, max);
        }

        [Theory]
        [ClassData(typeof(IntMaxNumberTestData))]

        public void GenerateIntMaxNumber(int max)
        {
            var number = Faker.Number(max);

            Assert.InRange<int>(number, 0, max);
        }

        [Theory]
        [ClassData(typeof(LongMaxMinNumberTestData))]
        public void GenerateLongMaxMinNumber(long max, long min)
        {
            var number = Faker.Number(max, min);

            Assert.InRange<long>(number, min, max);
        }

        [Theory]
        [ClassData(typeof(LongMaxNumberTestData))]
        public void GenerateLongMaxNumber(long max)
        {
            var number = Faker.Number(max);

            Assert.InRange<long>(number, 0, max);
        }

        [Theory]
        [ClassData(typeof(FloatMaxMinNumberTestData))]
        public void GenerateFloatMaxMinNumber(float max, float min)
        {
            var number = Faker.Number(max, min);

            Assert.InRange<float>(number, min, max);
        }

        [Theory]
        [ClassData(typeof(FloatMaxNumberTestData))]
        public void GenerateFloatMaxNumber(float max)
        {
            var number = Faker.Number(max);

            Assert.InRange<float>(number, 0, max);
        }

        [Theory]
        [ClassData(typeof(DoubleMaxMinNumberTestData))]
        public void GenerateDoubleMaxMinNumber(double max, double min)
        {
            var number = Faker.Number(max, min);

            Assert.InRange<double>(number, min, max);
        }

        [Theory]
        [ClassData(typeof(DoubleMaxNumberTestData))]
        public void GenerateDoubleMaxNumber(double max)
        {
            var number = Faker.Number(max);

            Assert.InRange<double>(number, 0, max);
        }

        [Theory]
        [ClassData(typeof(DecimalMaxMinNumberTestData))]
        public void GenerateDecimalMaxMinNumber(decimal max, decimal min)
        {
            var number = Faker.Number(max, min);

            Assert.InRange<decimal>(number, min, max);
        }

        [Theory]
        [ClassData(typeof(DecimalMaxNumberTestData))]
        public void GenerateDecimalMaxNumber(decimal max)
        {
            var number = Faker.Number(max);

            Assert.InRange<decimal>(number, 0, max);
        }

        #region Generic Number Method
        [Theory]
        [ClassData(typeof(IntMaxMinNumberTestData))]
        public void GenerateGenericIntMaxMinNumber(int max, int min)
        {
            var number = Faker.Number<int>(max, min);

            Assert.InRange<int>(number, min, max);
        }

        [Theory]
        [ClassData(typeof(IntMaxNumberTestData))]
        public void GenerateGenericIntMaxNumber(int max)
        {
            var number = Faker.Number<int>(max);

            Assert.InRange<int>(number, 0, max);
        }

        [Theory]
        [ClassData(typeof(LongMaxMinNumberTestData))]
        public void GenerateGenericLongMaxMinNumber(long max, long min)
        {
            var number = Faker.Number<long>(max, min);

            Assert.InRange<long>(number, min, max);
        }

        [Theory]
        [ClassData(typeof(LongMaxNumberTestData))]
        public void GenerateGenericLongMaxNumber(long max)
        {
            var number = Faker.Number<long>(max);

            Assert.InRange<long>(number, 0, max);
        }

        [Theory]
        [ClassData(typeof(FloatMaxMinNumberTestData))]
        public void GenerateGenericFloatMaxMinNumber(float max, float min)
        {
            var number = Faker.Number<float>(max, min);

            Assert.InRange<float>(number, min, max);
        }

        [Theory]
        [ClassData(typeof(FloatMaxNumberTestData))]
        public void GenerateGenericFloatMaxNumber(float max)
        {
            var number = Faker.Number<float>(max);

            Assert.InRange<float>(number, 0, max);
        }

        [Theory]
        [ClassData(typeof(DoubleMaxMinNumberTestData))]
        public void GenerateGenericDoubleMaxMinNumber(double max, double min)
        {
            var number = Faker.Number<double>(max, min);

            Assert.InRange<double>(number, min, max);
        }

        [Theory]
        [ClassData(typeof(DoubleMaxNumberTestData))]
        public void GenerateGenericDoubleMaxNumber(double max)
        {
            var number = Faker.Number<double>(max);

            Assert.InRange<double>(number, 0, max);
        }

        [Theory]
        [ClassData(typeof(DecimalMaxMinNumberTestData))]
        public void GenerateGenericDecimalMaxMinNumber(decimal max, decimal min)
        {
            var number = Faker.Number<decimal>(max, min);

            Assert.InRange<decimal>(number, min, max);
        }

        [Theory]
        [ClassData(typeof(DecimalMaxNumberTestData))]
        public void GenerateGenericDecimalMaxNumber(decimal max)
        {
            var number = Faker.Number<decimal>(max);

            Assert.InRange<decimal>(number, 0, max);
        }
        #endregion
    }
}
