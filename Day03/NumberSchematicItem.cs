namespace Day03
{
    public class NumberSchematicItem : SchematicItem
    {
        public NumberSchematicItem(string value)
        {
            Value = int.Parse(value);
        }

        public bool IsPartNumber { get => SymbolNeighbors.Count > 0; }
        public int Value { get; init; }
    }
}
