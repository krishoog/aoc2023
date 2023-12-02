using System.Text.RegularExpressions;

namespace Day02
{
    public class CubeGameParser
    {
        private string data;

        public CubeGameParser(string data)
        {
            (Game, this.data) = ParseGameAndDraws(data);
        }

        public int Game { get; init; }

        public IEnumerable<CubeDraw> Draws => ParseDraws();

        private (int, string) ParseGameAndDraws(string data)
        {
            var rx = new Regex(@"^Game\s(\d+): (.+)$", RegexOptions.Compiled);
            var m = rx.Match(data);

            var game = int.Parse(m.Groups[1].Value);
            var drawsData = m.Groups[2].Value;

            return (game, drawsData);
        }

        private IEnumerable<CubeDraw> ParseDraws()
        {
            var rx = new Regex(@"(\d+)\s(\w+)", RegexOptions.Compiled);

            foreach (var drawData in data.Split(';'))
            {
                var draw = new CubeDraw();
                foreach (var colorData in drawData.Split(","))
                {
                    var m = rx.Match(colorData);
                    var number = int.Parse(m.Groups[1].Value);
                    var color = m.Groups[2].Value;
                    switch (color)
                    {
                        case "red": draw = draw with { Red = number }; break;
                        case "green": draw = draw with { Green = number }; break;
                        case "blue": draw = draw with { Blue = number }; break;
                    }
                }

                yield return draw;
            }
        }
    }
}
