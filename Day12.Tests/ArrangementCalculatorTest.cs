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
        public int Test1(string data)
        {
            var x = new ArrangementCalculator(1);
            return x.CalculateArrangements(data);
        }

        [TestCase("???.### 1,1,3", ExpectedResult = 1)]
        [TestCase(".??..??...?##. 1,1,3", ExpectedResult = 16384)]
        [TestCase("?#?#?#?#?#?#?#? 1,3,1,6", ExpectedResult = 1)]
        [TestCase("????.#...#... 4,1,1", ExpectedResult = 16)]
        [TestCase("????.######..#####. 1,6,5", ExpectedResult = 2500)]
        [TestCase("?###???????? 3,2,1", ExpectedResult = 506250)]
        public int Test5(string data)
        {
            var x = new ArrangementCalculator(5);
            return x.CalculateArrangements(data);
        }
    }
}