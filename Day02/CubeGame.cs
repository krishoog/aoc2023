namespace Day02
{
    public class CubeGame
    {
        private readonly CubeGameParser parser;

        public CubeGame(string data)
        {
            parser = new CubeGameParser(data);
        }

        public int GameId { get => parser.Game; }

        public bool IsPossible(int red, int green, int blue)
        {
            foreach (var draw in parser.Draws)
            {
                if (draw.Red > red || draw.Green > green || draw.Blue > blue)
                    return false;
            }

            return true;
        }
    }
}
