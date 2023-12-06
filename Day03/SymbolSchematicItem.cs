namespace Day03
{
    public class SymbolSchematicItem : SchematicItem
    {
        private readonly HashSet<NumberSchematicItem> numberNeighbors = [];

        public SymbolSchematicItem(string value)
        {
            Value = value[0];
        }

        public char Value { get; init; }
        public HashSet<NumberSchematicItem> NumberNeighbors { get => numberNeighbors; }
        public bool IsGear { get => Value == '*' && NumberNeighbors.Count == 2; }
        public int GearRatio { get => NumberNeighbors.Select(x => x.Value).Aggregate(1, (x, y) => x * y); }
    }
}
