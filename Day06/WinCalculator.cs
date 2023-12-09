namespace Day06
{
    public class WinCalculator
    {
        public int WaysToWin(int time, int distance)
        {
            // Solve: x^2 - time * x + distance > 0
            var discriminant = time * time - 4 * (distance + 1);
            var rootD = Math.Sqrt(discriminant);
            var high = (time + rootD) / 2;
            var low = (time - rootD) / 2;

            var waysToWin = (int)(Math.Floor(high) - Math.Ceiling(low)) + 1;

            return waysToWin;
        }
    }
}
