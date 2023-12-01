using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01
{
    public class CalibrationValueExtractor
    {
        public int ParseLine(string line)
        {
            var charArray = line.ToCharArray();
            var builder = new StringBuilder();
            builder.Append(FirstNumber(charArray));
            builder.Append(FirstNumber(charArray.Reverse()));

            return int.Parse(builder.ToString());
        }

        private char FirstNumber(IEnumerable<char> array)
        {
            foreach (char c in array)
            {
                if (char.IsNumber(c))
                    return c;
            }

            return '0';
        }
    }
}
