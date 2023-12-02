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

        public CubeSet MinimumSet()
        {
            var min = new CubeSet(0, 0, 0);
            foreach (var draw in parser.Draws)
            {
                min = min with
                {
                    Red = int.Max(min.Red, draw.Red),
                    Green = int.Max(min.Green, draw.Green),
                    Blue = int.Max(min.Blue, draw.Blue)
                };
            }

            return min;
        }
    }
}
