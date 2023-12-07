namespace Day05.Tests
{
    public class TestMapper
    {
        private readonly Mapper mapper = new();

        [SetUp]
        public void SetUp()
        {
            mapper.AddRange(50, 98, 2);
            mapper.AddRange(52, 50, 48);
        }

        [TestCase(79, ExpectedResult = 81)]
        [TestCase(14, ExpectedResult = 14)]
        [TestCase(55, ExpectedResult = 57)]
        [TestCase(13, ExpectedResult = 13)]
        [TestCase(98, ExpectedResult = 50)]
        [TestCase(99, ExpectedResult = 51)]
        [TestCase(100, ExpectedResult = 100)]
        public long Test(long source)
        {
            return mapper.Map(source);
        }
    }
}