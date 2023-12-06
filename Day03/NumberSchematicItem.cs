namespace Day03
{
    public class NumberSchematicItem : SchematicItem
    {
        public NumberSchematicItem(string value)
        {
            Value = int.Parse(value);
        }

        public int Value { get; init; }
    }
}
