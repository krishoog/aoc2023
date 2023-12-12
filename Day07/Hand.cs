using System.Text.RegularExpressions;

namespace Day07
{
    public enum HandType
    {
        FiveOfAKind,
        FourOfAKind,
        FullHouse,
        ThreeOfAKind,
        TwoPair,
        OnePair,
        HighCard
    }

    public class Hand
    {
        private readonly string data;

        public Hand(string data)
        {
            this.data = data;
        }

        public int Bid { get; set; }

        public HandType Type
        {
            get
            {
                var sortedData = SortData();

                var rxSameCards = new Regex(@"([^J])\1+");
                var counts = new int[6];
                foreach (Match m in rxSameCards.Matches(sortedData))
                {
                    counts[m.Length]++;
                }

                var rxJokers = new Regex(@"[J]+");
                var jokers = rxJokers.Match(sortedData).Length;
                // Use every joker to make it a better set
                for (int i = 0; i < jokers; i++)
                {
                    var used = false;
                    for (int j = 5; !used && j >= 2; j--)
                    {
                        if (counts[j - 1] > 0)
                        {
                            counts[j]++;
                            counts[j - 1]--;
                            used = true;
                        }
                    }

                    if (!used)
                    {
                        counts[2]++;
                    }
                }

                if (counts[5] > 0)
                    return HandType.FiveOfAKind;
                if (counts[4] > 0)
                    return HandType.FourOfAKind;
                if (counts[3] > 0 && counts[2] > 0)
                    return HandType.FullHouse;
                if (counts[3] > 0)
                    return HandType.ThreeOfAKind;
                if (counts[2] >= 2)
                    return HandType.TwoPair;
                if (counts[2] > 0)
                    return HandType.OnePair;
                return HandType.HighCard;
            }
        }

        public int HighCard(int index)
        {
            return data[index] switch
            {
                'A' => 14,
                'K' => 13,
                'Q' => 12,
                'J' => 1, // 11 when not joker
                'T' => 10,
                _ => int.Parse(data.Substring(index, 1)),
            };
        }

        private string SortData()
        {
            var chars = data.ToArray();
            Array.Sort(chars);

            return new string(chars);
        }
    }
}
