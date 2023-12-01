using System.Text;

namespace Day01
{
    public class CalibrationValueExtractor
    {
        public int ParseLine(string line)
        {
            var builder = new StringBuilder();
            builder.Append(FirstNumber(line));
            builder.Append(LastNumber(line));

            return int.Parse(builder.ToString());
        }

        private char FirstNumber(string line)
        {
            while (line.Length > 0)
            {
                switch (line)
                {
                    case var x when x.StartsWith("zero"): return '0';
                    case var x when x.StartsWith("one"): return '1';
                    case var x when x.StartsWith("two"): return '2';
                    case var x when x.StartsWith("three"): return '3';
                    case var x when x.StartsWith("four"): return '4';
                    case var x when x.StartsWith("five"): return '5';
                    case var x when x.StartsWith("six"): return '6';
                    case var x when x.StartsWith("seven"): return '7';
                    case var x when x.StartsWith("eight"): return '8';
                    case var x when x.StartsWith("nine"): return '9';
                    case var x when char.IsNumber(x[0]): return x[0];
                    default: line = line[1..]; break;
                }
            }

            return '0';
        }

        private char LastNumber(string line)
        {
            while (line.Length > 0)
            {
                switch (line)
                {
                    case var x when x.EndsWith("zero"): return '0';
                    case var x when x.EndsWith("one"): return '1';
                    case var x when x.EndsWith("two"): return '2';
                    case var x when x.EndsWith("three"): return '3';
                    case var x when x.EndsWith("four"): return '4';
                    case var x when x.EndsWith("five"): return '5';
                    case var x when x.EndsWith("six"): return '6';
                    case var x when x.EndsWith("seven"): return '7';
                    case var x when x.EndsWith("eight"): return '8';
                    case var x when x.EndsWith("nine"): return '9';
                    case var x when char.IsNumber(x[^1]): return x[^1];
                    default: line = line[..^1]; break;
                }
            }

            return '0';
        }
    }
}
