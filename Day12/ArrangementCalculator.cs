namespace Day12
{
    public class ArrangementCalculator
    {
        private readonly int fold;

        private class Spring
        {
            private readonly Dictionary<(int, char), long> cache = [];
            public char Condition { get; init; }
            public Spring? Neighbor { get; set; }

            public long CountPaths(int[] groups, char previousCondition = '.')
            {
                int remaining = groups.Sum();
                if (cache.TryGetValue((remaining, previousCondition), out long paths))
                {
                    return paths;
                }

                if (Condition == '?')
                {
                    paths = CountPaths('.', groups, previousCondition) + CountPaths('#', groups, previousCondition);
                }
                else
                {
                    paths = CountPaths(Condition, groups, previousCondition);
                }

                cache.Add((remaining, previousCondition), paths);

                return paths;
            }

            public long CountPaths(char condition, int[] groups, char previousCondition)
            {
                if (condition == '#')
                {
                    groups = (int[])groups.Clone();
                    if (--groups[0] < 0)
                        return 0; // invalid path: group too large
                }
                else if (previousCondition == '#')
                {
                    if (groups[0] != 0)
                    {
                        return 0; // invalid path: group not completed
                    }

                    if (groups.Length > 1)
                    {
                        // go to the next group
                        groups = groups[1..];
                    }
                }

                if (Neighbor == null) // last spring
                {
                    if (groups[0] == 0 && groups.Length == 1)
                        return 1; // valid path

                    return 0; // invalid path groups not fulfilled
                }

                return Neighbor.CountPaths(groups, condition);
            }
        }

        public ArrangementCalculator(int fold)
        {
            this.fold = fold;
        }

        public long CalculateArrangements(string data)
        {
            var split = data.Split(" ");
            var springs = Unfold(CreateSprings(split[0] + "?")).ToList();
            for (int i = 1; i < springs.Count - 1; i++)
            {
                springs[i - 1].Neighbor = springs[i];
            }

            var groups = Unfold(CreateGroups(split[1])).ToArray();

            return springs[0].CountPaths(groups);
        }

        private IEnumerable<T> Unfold<T>(IEnumerable<T> input)
        {
            for (int i = 0; i < fold; i++)
                foreach (var x in input)
                    yield return x;
        }

        private static IEnumerable<Spring> CreateSprings(string conditions)
        {
            return conditions.Select(x => new Spring() { Condition = x });
        }

        private static IEnumerable<int> CreateGroups(string groups)
        {
            return groups.Split(",").Select(int.Parse);
        }
    }
}
