namespace Day04
{
    public class ScratchCard
    {
        public ScratchCard(string data)
        {
            var numbers = data.Split(": ")[1].Split(" | ");
            var winning = SplitNumbers(numbers[0]).ToHashSet();
            var ours = SplitNumbers(numbers[1]);
            MatchingNumbers = ours.Where(winning.Contains).Count(); ;
            Points = MatchingNumbers == 0 ? 0 : 1 << MatchingNumbers - 1;
        }

        public int Points { get; init; }

        public int MatchingNumbers { get; init; }

        public int Copies { get; set; }

        public int Instances { get => Copies + 1; }

        private static IEnumerable<int> SplitNumbers(string numbers)
        {
            return numbers.Split(" ").Where(x => x.Length > 0).Select(int.Parse);
        }
    }
}