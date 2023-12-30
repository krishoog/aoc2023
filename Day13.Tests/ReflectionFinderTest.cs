namespace Day13.Tests
{
    public class ReflectionFinderTest
    {
        private const string input1 =
            """
            #.##..##.
            ..#.##.#.
            ##......#
            ##......#
            ..#.##.#.
            ..##..##.
            #.#.##.#.
            """;

        private const string input2 =
            """
            #...##..#
            #....#..#
            ..##..###
            #####.##.
            #####.##.
            ..##..###
            #....#..#
            """;

        [TestCase(input1, ExpectedResult = 5)]
        [TestCase(input2, ExpectedResult = 400)]
        public int Test(string data)
        {
            var x = new ReflectionFinder();

            return x.ReflectionNumber(data.Split("\r\n").ToArray());
        }
    }
}