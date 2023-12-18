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

        [Test]
        public void TestCalculteShortesPaths()
        {
            var x = new UniverseMap(testInput.Split("\r\n"));
            var dists = x.CalculteShortesPaths().ToList();
            Assert.That(dists.Sum(), Is.EqualTo(374));
        }
    }
}