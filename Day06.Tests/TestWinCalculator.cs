namespace Day06.Tests
{
    public class TestWinCalculator
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(7, 9, ExpectedResult = 4)]
        [TestCase(15, 40, ExpectedResult = 8)]
        [TestCase(30, 200, ExpectedResult = 9)]
        public long Test(long time, long distance)
        {
            var x = new WinCalculator();
            return x.WaysToWin(time, distance);
        }
    }
}