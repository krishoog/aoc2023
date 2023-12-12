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
                var rx5K = new Regex(@"(.)\1{4}");
                var rx4K = new Regex(@"(.)\1{3}");
                var rxFH1 = new Regex(@"(.)\1{2}(.)\2{1}");
                var rxFH2 = new Regex(@"(.)\1{1}(.)\2{2}");
                var rx3K = new Regex(@"(.)\1{2}");
                var rx2P = new Regex(@"(.)\1.?(.)\2");
                var rx1P = new Regex(@"(.)\1");

                return SortData() switch
                {
                    var x when rx5K.IsMatch(x) => HandType.FiveOfAKind,
                    var x when rx4K.IsMatch(x) => HandType.FourOfAKind,
                    var x when rxFH1.IsMatch(x) => HandType.FullHouse,
                    var x when rxFH2.IsMatch(x) => HandType.FullHouse,
                    var x when rx3K.IsMatch(x) => HandType.ThreeOfAKind,
                    var x when rx2P.IsMatch(x) => HandType.TwoPair,
                    var x when rx1P.IsMatch(x) => HandType.OnePair,
                    _ => HandType.HighCard,
                };
            }
        }

        public int HighCard(int index)
        {
            return data[index] switch
            {
                'A' => 14,
                'K' => 13,
                'Q' => 12,
                'J' => 11,
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
