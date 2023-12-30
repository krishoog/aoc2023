using System.Text;

namespace Day13
{
    public class ReflectionFinder
    {
        public int ReflectionNumber(string[] data)
        {
            for (int reflectCol = 1; reflectCol <= data[0].Length - 1; reflectCol++)
            {
                var length = Math.Min(reflectCol, data[0].Length - reflectCol);
                var symmetric = data.All(x => IsSymmetric(x.Substring(reflectCol - length, length * 2)));
                if (symmetric)
                {
                    return reflectCol;
                }
            }

            for (int reflectRow = 1; reflectRow <= data.Length - 1; reflectRow++)
            {
                var length = Math.Min(reflectRow, data.Length - reflectRow);
                bool symmetric = true;
                for (int col = 0; col < data[0].Length && symmetric; col++)
                {
                    var builder = new StringBuilder();
                    for (int i = 0; i < length * 2; i++)
                    {
                        builder.Append(data[reflectRow - length + i][col]);
                    }
                    symmetric = IsSymmetric(builder.ToString());
                }

                if (symmetric)
                {
                    return reflectRow * 100;
                }
            }

            return 0;
        }

        private static bool IsSymmetric(string input)
        {
            for (int i = 0; i < input.Length / 2; i++)
            {
                if (input[i] != input[^(i + 1)])
                    return false;
            }

            return true;
        }
    }
}
