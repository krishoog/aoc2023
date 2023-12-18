namespace Day11.Tests
{
    public class TestUniverseMap
    {
        private const string testInput =
            """
            ...#......
            .......#..
            #.........
            ..........
            ......#...
            .#........
            .........#
            ..........
            .......#..
            #...#.....
            """;

        [TestCase(2, ExpectedResult = 374)]
        [TestCase(10, ExpectedResult = 1030)]
        [TestCase(100, ExpectedResult = 8410)]
        public long TestCalculteShortesPaths(int expansion)
        {
            var x = new UniverseMap(testInput.Split("\r\n"), expansion);
            return x.CalculteShortesPaths().Sum();
        }
    }
}