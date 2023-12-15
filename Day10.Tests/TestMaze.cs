namespace Day10.Tests
{
    public class TestMaze
    {
        private readonly string testInput =
            """
            7-F7-
            .FJ|7
            SJLL7
            |F--J
            LJ.LJ
            """;

        [Test]
        public void Test()
        {
            var x = new Maze(testInput.Split("\r\n"));
            Assert.That(x.FindLoopLength(), Is.EqualTo(16));
        }
    }
}