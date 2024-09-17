using System.Numerics;

namespace Monsky.Fake
{
    public static partial class Faker
    {
        public static T Number<T>(T max, T min) where T : INumber<T>
        {
            if (max < min)
                throw new ArgumentException("max must be greater than min");

            if (typeof(T) == typeof(int))
                return (T)(object)Number((int)(object)max, (int)(object)min);

            if (typeof(T) == typeof(long))
                return (T)(object)Number((long)(object)max, (long)(object)min);

            if (typeof(T) == typeof(float))
                return (T)(object)Number((float)(object)max, (float)(object)min);

            if (typeof(T) == typeof(double))
                return (T)(object)Number((double)(object)max, (double)(object)min);

            if (typeof(T) == typeof(decimal))
                return (T)(object)Number((decimal)(object)max, (decimal)(object)min);

            throw new NotSupportedException($"Type {typeof(T)} is not supported.");
        }

        public static T Number<T>(T max) where T : INumber<T>
        {
            if (max < T.Zero)
                throw new ArgumentException("max must be greater than 0");

            double randomValue = Random.Shared.NextDouble();
            T result = max * T.CreateTruncating(randomValue);
            return result;
        }

        public static int Number(int max = 100, int min = 0)
        {
            if (max < min)
                throw new ArgumentException("max must be greater than or equal to min");

            return Random.Shared.Next(min, max);
        }

        public static int Number(int max = 100)
        {
            if (max < 0)
                throw new ArgumentException("max must be greater than 0");

            return Random.Shared.Next(max);
        }

        public static long Number(long max = 100, long min = 0)
        {
            if (max < min)
                throw new ArgumentException("max must be greater than or equal to min");

            return Random.Shared.NextInt64(min, max);
        }

        public static long Number(long max = 100)
        {
            if (max < 0)
                throw new ArgumentException("max must be greater than 0");

            return Random.Shared.NextInt64(max);
        }

        public static float Number(float max = 100, float min = 0)
        {
            if (max < min)
                throw new ArgumentException("max must be greater than or equal to min");

            if (min == float.MinValue && max == float.MaxValue)
            {
                if (Random.Shared.Next(0, 2) == 0)
                    return -Random.Shared.NextSingle() * float.MaxValue;
                else
                    return Random.Shared.NextSingle() * float.MaxValue;
            }

            var randomValue = Random.Shared.NextSingle();
            return min + randomValue * (max - min);
        }

        public static float Number(float max = 100)
        {
            if (max < 0)
                throw new ArgumentException("max must be greater than or equal to 0");

            var randomValue = Random.Shared.NextSingle();
            return randomValue * max;
        }

        public static double Number(double max = 100, double min = 0)
        {
            if (max < min)
                throw new ArgumentException("max must be greater than or equal to min");

            if (min == double.MinValue && max == double.MaxValue)
            {
                if (Random.Shared.Next(0, 2) == 0)
                    return -Random.Shared.NextSingle() * double.MaxValue;
                else
                    return Random.Shared.NextSingle() * double.MaxValue;
            }

            var randomValue = Random.Shared.NextDouble();
            return min + randomValue * (max - min);
        }

        public static double Number(double max = 100)
        {
            if (max < 0)
                throw new ArgumentException("max must be greater than or equal to 0");

            var randomValue = Random.Shared.NextDouble();
            return randomValue * max;
        }

        public static decimal Number(decimal max = 100, decimal min = 0)
        {
            if (max < min)
                throw new ArgumentException("max must be greater than or equal to min");

            if (min == decimal.MinValue && max == decimal.MaxValue)
            {
                if (Random.Shared.Next(0, 2) == 0)
                {
                    return -1 * (decimal)Random.Shared.NextDouble() * decimal.MaxValue;
                }
                else
                {
                    return (decimal)Random.Shared.NextDouble() * decimal.MaxValue;
                }
            }

            double randomValue = Random.Shared.NextDouble();
            return min + (decimal)randomValue * (max - min);
        }

        public static decimal Number(decimal max = 100)
        {
            if (max < 0)
                throw new ArgumentException("max must be greater than 0");

            double randomValue = Random.Shared.NextDouble();
            return (decimal)randomValue * max;
        }
    }
}
