namespace Day12
{
    public class ArrangementCalculator
    {
        private class Spring
        {
            public char Condition { get; init; }
            public Spring? Neighbor { get; set; }

            public int CountPaths(int[] groups, char previousCondition = '.')
            {
                if (Condition == '?')
                {
                    return CountPaths('.', groups, previousCondition) + CountPaths('#', groups, previousCondition);
                }

                return CountPaths(Condition, groups, previousCondition);
            }

            public int CountPaths(char condition, int[] groups, char previousCondition)
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

        public int CalculateArrangements(string data)
        {
            var split = data.Split(" ");

            var springs = split[0].Select(x => new Spring() { Condition = x }).ToList();
            for (int i = 1; i < springs.Count; i++)
            {
                springs[i - 1].Neighbor = springs[i];
            }

            var groups = split[1].Split(",").Select(int.Parse).ToArray();

            return springs[0].CountPaths(groups);
        }
    }
}
