namespace Day10.Tests
{
    public class TestMaze
    {
        private const string testInput1 =
            """
            7-F7-
            .FJ|7
            SJLL7
            |F--J
            LJ.LJ
            """;

        private const string testInput2 =
            """
            ...........
            .S-------7.
            .|F-----7|.
            .||.....||.
            .||.....||.
            .|L-7.F-J|.
            .|..|.|..|.
            .L--J.L--J.
            ...........
            """;

        private const string testInput3 =
            """
            .F----7F7F7F7F-7....
            .|F--7||||||||FJ....
            .||.FJ||||||||L7....
            FJL7L7LJLJ||LJ.L-7..
            L--J.L7...LJS7F-7L7.
            ....F-J..F7FJ|L7L7L7
            ....L7.F7||L7|.L7L7|
            .....|FJLJ|FJ|F7|.LJ
            ....FJL-7.||.||||...
            ....L---J.LJ.LJLJ...
            """;

        private const string testInput4 =
            """
            FF7FSF7F7F7F7F7F---7
            L|LJ||||||||||||F--J
            FL-7LJLJ||||||LJL-77
            F--JF--7||LJLJ7F7FJ-
            L---JF-JLJ.||-FJLJJ7
            |F|F-JF---7F7-L7L|7|
            |FFJF7L7F-JF7|JL---7
            7-L-JL7||F7|L7F-7F7|
            L.L7LFJ|||||FJL7||LJ
            L7JLJL-JLJLJL--JLJ.L
            """;

        [Test]
        public void TestFindLoop()
        {
            var x = new Maze(testInput1.Split("\r\n"));
            Assert.That(x.FindLoop(), Is.EqualTo(16));
        }

        [TestCase(testInput2, ExpectedResult = 4)]
        [TestCase(testInput3, ExpectedResult = 8)]
        [TestCase(testInput4, ExpectedResult = 10)]
        public int TestCountEnclosed(string input)
        {
            var x = new Maze(input.Split("\r\n"));
            x.FindLoop();
            return x.CountEnclosed();
        }
    }
}