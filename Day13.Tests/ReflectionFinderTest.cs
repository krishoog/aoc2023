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
        public int Test0(string data)
        {
            var x = new ReflectionFinder(0);

            return x.ReflectionNumber(data.Split("\r\n").ToArray());
        }

        [TestCase(input1, ExpectedResult = 300)]
        [TestCase(input2, ExpectedResult = 100)]
        public int Test1(string data)
        {
            var x = new ReflectionFinder(1);

            return x.ReflectionNumber(data.Split("\r\n").ToArray());
        }
    }
}