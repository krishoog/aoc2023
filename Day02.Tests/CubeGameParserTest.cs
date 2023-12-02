namespace Day02.Tests
{
    public class CubeGameParserTest
    {
        [TestCase("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", ExpectedResult = 1)]
        [TestCase("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", ExpectedResult = 2)]
        public int TestGame(string data)
        {
            var x = new CubeGameParser(data);
            return x.Game;
        }

        [TestCase("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", ExpectedResult = 3)]
        [TestCase("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", ExpectedResult = 3)]
        [TestCase("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", ExpectedResult = 3)]
        public int TestDraws(string data)
        {
            var x = new CubeGameParser(data);
            return x.Draws.Count();
        }
    }
}
