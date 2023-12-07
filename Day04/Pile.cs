namespace Day04
{
    public class Pile
    {
        private readonly List<ScratchCard> cards = [];

        public void AddCard(string data)
        {
            cards.Add(new ScratchCard(data));
        }

        public int NumCards { get => cards.Sum(x => x.Instances); }

        public void ScoreCards()
        {
            for (int i = 0; i < cards.Count; i++)
            {
                var card = cards[i];
                for (int j = 0; j < card.MatchingNumbers; j++)
                {
                    var cardNumber = i + j + 1;
                    if (cardNumber >= cards.Count)
                        break;
                    cards[cardNumber].Copies += card.Instances;
                }
            }
        }
    }
}
