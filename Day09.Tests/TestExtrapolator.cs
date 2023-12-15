namespace Day09.Tests
{
    public class TestExtrapolator
    {
        [TestCase("0 3 6 9 12 15", ExpectedResult = 18)]
        [TestCase("1 3 6 10 15 21", ExpectedResult = 28)]
        [TestCase("10 13 16 21 30 45", ExpectedResult = 68)]
        public int TestExtrapolate(string input)
        {
            var x = new Extrapolator();
            return x.Extrapolate(input);
        }

        [TestCase("0 3 6 9 12 15", ExpectedResult = -3)]
        [TestCase("1 3 6 10 15 21", ExpectedResult = 0)]
        [TestCase("10 13 16 21 30 45", ExpectedResult = 5)]
        public int TestExtrapolateBack(string input)
        {
            var x = new Extrapolator();
            return x.ExtrapolateBack(input);
        }
    }
}