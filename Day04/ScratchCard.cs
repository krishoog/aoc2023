namespace Day04
{
    public class ScratchCard
    {
        public ScratchCard(string data)
        {
            var numbers = data.Split(": ")[1].Split(" | ");
            var winning = SplitNumbers(numbers[0]).ToHashSet();
            var ours = SplitNumbers(numbers[1]);
            var countOursWinning = ours.Where(winning.Contains).Count(); ;
            Points = countOursWinning == 0 ? 0 : 1 << countOursWinning - 1;
        }

        public int Points { get; init; }

        private static IEnumerable<int> SplitNumbers(string numbers)
        {
            return numbers.Split(" ").Where(x => x.Length > 0).Select(int.Parse);
        }
    }
}