
namespace Day09
{
    public class Extrapolator
    {
        public int Extrapolate(string line)
        {
            return Extrapolate(line.Split(" ").Select(int.Parse));
        }

        public int Extrapolate(IEnumerable<int> sequence)
        {
            var d = Differentiate(sequence);
            if (d.All(x => x == 0))
                return sequence.Last();

            return sequence.Last() + Extrapolate(d);
        }

        public IEnumerable<int> Differentiate(IEnumerable<int> input)
        {
            var list = input.ToList();
            for (int i = 0; i < list.Count - 1; i++)
                yield return list[i + 1] - list[i];
        }
    }
}
