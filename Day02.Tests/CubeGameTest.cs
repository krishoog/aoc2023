namespace Day02.Tests
{
    public class CubeGameTest
    {
        [TestCase("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", ExpectedResult = true)]
        [TestCase("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", ExpectedResult = true)]
        [TestCase("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", ExpectedResult = false)]
        [TestCase("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", ExpectedResult = false)]
        [TestCase("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", ExpectedResult = true)]
        public bool TestIsPossible(string data)
        {
            var x = new CubeGame(data);
            return x.IsPossible(red: 12, green: 13, blue: 14);
        }

        [TestCase("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", ExpectedResult = 48)]
        [TestCase("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", ExpectedResult = 12)]
        [TestCase("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", ExpectedResult = 1560)]
        [TestCase("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", ExpectedResult = 630)]
        [TestCase("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", ExpectedResult = 36)]
        public int TestMinimumSetPower(string data)
        {
            var x = new CubeGame(data);
            return x.MinimumSet().Power;
        }
    }
}