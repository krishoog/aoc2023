namespace Day01.Tests
{
    public class CalibrationValueExtractorTest
    {
        [TestCase("two1nine", ExpectedResult = 29)]
        [TestCase("eightwothree", ExpectedResult = 83)]
        [TestCase("abcone2threexyz", ExpectedResult = 13)]
        [TestCase("xtwone3four", ExpectedResult = 24)]
        [TestCase("4nineeightseven2", ExpectedResult = 42)]
        [TestCase("zoneight234", ExpectedResult = 14)]
        [TestCase("7pqrstsixteen", ExpectedResult = 76)]
        public int Test(string line)
        {
            var x = new CalibrationValueExtractor();
            return x.ParseLine(line);
        }
    }
}
