﻿namespace Day03
{
    public class SchematicItem
    {
        private readonly HashSet<SymbolSchematicItem> symbolNeighbors = [];

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public HashSet<SymbolSchematicItem> SymbolNeighbors { get => symbolNeighbors; }

        public IEnumerable<(int, int)> GetNeighbors()
        {
            for (int x = X - 1; x <= X + 1; x++)
            {
                for (int y = Y - 1; y <= Y + 1; y++)
                {
                    yield return (x, y);
                }
            }
        }
    }
}
