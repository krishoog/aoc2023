namespace Day07.Tests
{
    public class TestHand
    {
        [TestCase("32T3K", ExpectedResult = HandType.OnePair)]
        [TestCase("T55J5", ExpectedResult = HandType.ThreeOfAKind)]
        [TestCase("KK677", ExpectedResult = HandType.TwoPair)]
        [TestCase("KTJJT", ExpectedResult = HandType.TwoPair)]
        [TestCase("QQQJA", ExpectedResult = HandType.ThreeOfAKind)]
        [TestCase("AAAAA", ExpectedResult = HandType.FiveOfAKind)]
        [TestCase("AA8AA", ExpectedResult = HandType.FourOfAKind)]
        [TestCase("23332", ExpectedResult = HandType.FullHouse)]
        [TestCase("22332", ExpectedResult = HandType.FullHouse)]
        [TestCase("TTT98", ExpectedResult = HandType.ThreeOfAKind)]
        [TestCase("23432", ExpectedResult = HandType.TwoPair)]
        [TestCase("A23A4", ExpectedResult = HandType.OnePair)]
        [TestCase("23456", ExpectedResult = HandType.HighCard)]
        public HandType TestType(string data)
        {
            var x = new Hand(data);

            return x.Type;
        }

        [TestCase("32T3K", 0, ExpectedResult = 3)]
        [TestCase("T55J5", 1, ExpectedResult = 5)]
        [TestCase("KK677", 0, ExpectedResult = 13)]
        [TestCase("KTJJT", 0, ExpectedResult = 13)]
        [TestCase("QQQJA", 0, ExpectedResult = 12)]
        [TestCase("AAAAA", 0, ExpectedResult = 14)]
        [TestCase("AA8AA", 0, ExpectedResult = 14)]
        [TestCase("23332", 0, ExpectedResult = 2)]
        [TestCase("22332", 0, ExpectedResult = 2)]
        [TestCase("TTT98", 0, ExpectedResult = 10)]
        [TestCase("23432", 0, ExpectedResult = 2)]
        [TestCase("A23A4", 0, ExpectedResult = 14)]
        [TestCase("23456", 0, ExpectedResult = 2)]
        public int TestHighCard(string data, int index)
        {
            var x = new Hand(data);

            return x.HighCard(index);
        }
    }
}