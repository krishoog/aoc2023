﻿namespace Day11
{
    public class UniverseMap
    {
        private class Cell
        {
            public char Type { get; init; }
            public int ObservedX { get; init; }
            public int ObservedY { get; init; }
            public bool ExpandedX { get; set; }
            public bool ExpandedY { get; set; }
            public long RealX { get; set; }
            public long RealY { get; set; }
        }

        private readonly List<Cell> map = [];
        private readonly int mapWidth;
        private readonly int mapHeight;
        private readonly int expansionFactor;

        public UniverseMap(IEnumerable<string> data, int expansionFactor)
        {
            (mapWidth, mapHeight) = LoadData(data);
            this.expansionFactor = expansionFactor;

            ExpandInX();
            ExpandInY();
            CalculateRealCoords();
        }

        public IEnumerable<long> CalculteShortesPaths()
        {
            var galaxies = map.Where(c => c.Type == '#').ToList();
            for (int i = 0; i < galaxies.Count; i++)
            {
                for (int j = i + 1; j < galaxies.Count; j++)
                {
                    var g1 = galaxies[i];
                    var g2 = galaxies[j];

                    yield return Math.Abs(g1.RealX - g2.RealX) + Math.Abs(g1.RealY - g2.RealY);
                }
            }
        }

        private (int, int) LoadData(IEnumerable<string> data)
        {
            int y = 0;
            int x = 0;
            foreach (var row in data)
            {
                x = 0;
                foreach (var col in row.ToCharArray())
                {
                    map.Add(new Cell() { Type = col, ObservedX = x, ObservedY = y });
                    x++;
                }

                y++;
            }

            return (x, y);
        }

        private void ExpandInX()
        {
            for (int x = 0; x < mapWidth; x++)
            {
                var col = map.Where(c => c.ObservedX == x);
                if (col.All(c => c.Type == '.'))
                {
                    foreach (var c in col)
                    {
                        c.ExpandedX = true;
                    }
                }
            }
        }

        private void ExpandInY()
        {
            for (int y = 0; y < mapHeight; y++)
            {
                var row = map.Where(c => c.ObservedY == y);
                if (row.All(c => c.Type == '.'))
                {
                    foreach (var c in row)
                    {
                        c.ExpandedY = true;
                    }
                }
            }
        }

        private void CalculateRealCoords()
        {
            long realX = 0;
            long realY = 0;
            long lastRealHeight = 0;
            foreach (var cell in map)
            {
                if (cell.ObservedX == 0)
                {
                    realX = 0;
                    realY += lastRealHeight;
                }

                cell.RealX = realX;
                cell.RealY = realY;

                realX += cell.ExpandedX ? expansionFactor : 1;
                lastRealHeight = cell.ExpandedY ? expansionFactor : 1;
            }
        }
    }
}
