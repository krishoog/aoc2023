namespace Day12.Tests
{
    public class ArrangementCalculatorTest
    {
        [TestCase("???.### 1,1,3", ExpectedResult = 1)]
        [TestCase(".??..??...?##. 1,1,3", ExpectedResult = 4)]
        [TestCase("?#?#?#?#?#?#?#? 1,3,1,6", ExpectedResult = 1)]
        [TestCase("????.#...#... 4,1,1", ExpectedResult = 1)]
        [TestCase("????.######..#####. 1,6,5", ExpectedResult = 4)]
        [TestCase("?###???????? 3,2,1", ExpectedResult = 10)]
        public int Test(string data)
        {
            var x = new ArrangementCalculator();
            return x.CalculateArrangements(data);
        }
    }
}