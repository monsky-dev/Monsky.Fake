using System.Collections;

namespace Monsky.Fake.Tests.TestData
{
    public class IntMaxMinNumberTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 100, 50 };
            yield return new object[] { 0, -50 };
            yield return new object[] { -100, -500 };
            yield return new object[] { int.MaxValue, int.MinValue };
            yield return new object[] { int.MaxValue, 0 };
            yield return new object[] { 0, int.MinValue };
            yield return new object[] { 1, 0 };
            yield return new object[] { 9999, -9999 };
            yield return new object[] { 99999, -99999 };
            yield return new object[] { 999999, -999999 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class IntMaxNumberTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 100 };
            yield return new object[] { 0 };
            yield return new object[] { int.MaxValue };
            yield return new object[] { 1 };
            yield return new object[] { 9999 };
            yield return new object[] { 9999 };
            yield return new object[] { 999999 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class LongMaxMinNumberTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 100L, 50L };
            yield return new object[] { 0L, -50L };
            yield return new object[] { -100L, -500L };
            yield return new object[] { long.MaxValue, long.MinValue };
            yield return new object[] { long.MaxValue, 0L };
            yield return new object[] { 0L, long.MinValue };
            yield return new object[] { 1L, 0L };
            yield return new object[] { 9999L, -9999L };
            yield return new object[] { 99999L, -99999L };
            yield return new object[] { 999999L, -999999L };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class LongMaxNumberTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 100L };
            yield return new object[] { 0L };
            yield return new object[] { long.MaxValue };
            yield return new object[] { 0L };
            yield return new object[] { 1L };
            yield return new object[] { 9999L };
            yield return new object[] { 99999L };
            yield return new object[] { 999999L };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class FloatMaxMinNumberTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 100f, 50f };
            yield return new object[] { 0f, -50f };
            yield return new object[] { -100f, -500f };
            yield return new object[] { float.MaxValue, float.MinValue };
            yield return new object[] { float.MaxValue, 0 };
            yield return new object[] { 0f, float.MinValue };
            yield return new object[] { 1f, 0f };
            yield return new object[] { 9999f, -9999f };
            yield return new object[] { 99999f, -99999f };
            yield return new object[] { 999999f, -999999f };
            yield return new object[] { 123.2323f, 123.22f };
            yield return new object[] { 111.1111f, 111.111f };
            yield return new object[] { 921313.213123f, 123123.3123123f };
            yield return new object[] { 98713.123123f, -23813.2313f };
            yield return new object[] { 222.222f, -222.222f };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class FloatMaxNumberTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 100f };
            yield return new object[] { 0f };
            yield return new object[] { float.MaxValue };
            yield return new object[] { 1f };
            yield return new object[] { 9999f };
            yield return new object[] { 999999f };
            yield return new object[] { 123.2323f };
            yield return new object[] { 111.1111f };
            yield return new object[] { 921313.213123f };
            yield return new object[] { 98713.123123f };
            yield return new object[] { 222.222f };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class DoubleMaxMinNumberTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 100d, 50d };
            yield return new object[] { 0d, -50d };
            yield return new object[] { -100d, -500d };
            yield return new object[] { double.MaxValue, double.MinValue };
            yield return new object[] { double.MaxValue, 0d };
            yield return new object[] { 0d, double.MinValue };
            yield return new object[] { 1d, 0d };
            yield return new object[] { 9999d, -9999d };
            yield return new object[] { 99999d, -99999d };
            yield return new object[] { 999999d, -999999d };
            yield return new object[] { 123.2323d, 123.22d };
            yield return new object[] { 111.1111d, 111.111d };
            yield return new object[] { 921313.213123d, 123123.3123123d };
            yield return new object[] { 98713.123123d, -23813.2313d };
            yield return new object[] { 222.222d, -222.222d };

        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class DoubleMaxNumberTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 100d };
            yield return new object[] { 0d };
            yield return new object[] { double.MaxValue };
            yield return new object[] { 1d };
            yield return new object[] { 9999d };
            yield return new object[] { 99999d };
            yield return new object[] { 999999d };
            yield return new object[] { 123.2323d };
            yield return new object[] { 111.1111d };
            yield return new object[] { 921313.213123d };
            yield return new object[] { 98713.123123d };
            yield return new object[] { 222.222d };

        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class DecimalMaxMinNumberTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 100m, 50m };
            yield return new object[] { 0m, -50m };
            yield return new object[] { -100m, -500m };
            yield return new object[] { decimal.MaxValue, decimal.MinValue };
            yield return new object[] { decimal.MaxValue, 0 };
            yield return new object[] { 0m, decimal.MinValue };
            yield return new object[] { 1m, 0m };
            yield return new object[] { 9999m, -9999m };
            yield return new object[] { 99999m, -99999m };
            yield return new object[] { 999999m, -999999m };
            yield return new object[] { 123.2323m, 123.22m };
            yield return new object[] { 111.1111m, 111.111m };
            yield return new object[] { 921313.213123m, 123123.3123123m };
            yield return new object[] { 98713.123123m, -23813.2313m };
            yield return new object[] { 222.222m, -222.222m };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class DecimalMaxNumberTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 100m };
            yield return new object[] { 0m };
            yield return new object[] { decimal.MaxValue };
            yield return new object[] { 0m };
            yield return new object[] { 1m };
            yield return new object[] { 9999m };
            yield return new object[] { 99999m };
            yield return new object[] { 999999m };
            yield return new object[] { 123.2323m };
            yield return new object[] { 111.1111m };
            yield return new object[] { 921313.213123m };
            yield return new object[] { 98713.123123m };
            yield return new object[] { 222.222m };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
