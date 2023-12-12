namespace Day07
{
    public class CamelCards
    {
        private readonly List<Hand> hands = [];

        public void AddCard(string data)
        {
            var split = data.Split(" ");
            var hand = new Hand(split[0]) { Bid = int.Parse(split[1]) };
            hands.Add(hand);
        }

        public int TotalWinnings()
        {
            RankCards();

            return hands.Select((hand, index) => (index + 1) * hand.Bid).Sum();
        }

        private void RankCards()
        {
            hands.Sort((a, b) =>
            {
                if (a.Type != b.Type)
                    return a.Type > b.Type ? -1 : 1;

                for (int i = 0; i < 5; i++)
                {
                    if (a.HighCard(i) != b.HighCard(i))
                        return a.HighCard(i) < b.HighCard(i) ? -1 : 1;
                }

                return 0;
            });
        }
    }
}
