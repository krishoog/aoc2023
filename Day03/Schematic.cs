using System.Text.RegularExpressions;

namespace Day03
{
    public class Schematic
    {
        private readonly int width;
        private readonly int height;
        private readonly SchematicItem[,] grid;
        private readonly List<NumberSchematicItem> numbers = [];
        private readonly List<SymbolSchematicItem> symbols = [];
        private int currentRow = 0;

        public Schematic(int width, int height)
        {
            this.width = width;
            this.height = height;
            grid = new SchematicItem[height, width];
        }

        public List<NumberSchematicItem> Numbers { get => numbers; }
        public IEnumerable<NumberSchematicItem> PartNumbers { get => numbers.Where(x => x.IsPartNumber); }
        public IEnumerable<SymbolSchematicItem> Gears { get => symbols.Where(x => x.IsGear); }
        public List<SymbolSchematicItem> Symbols { get => symbols; }

        public void LoadRow(string data)
        {
            var rx = new Regex(@"^(\d+|\.+|[^\.\d])", RegexOptions.Compiled);
            int currentColumn = 0;
            while (data.Length > 0)
            {
                var m = rx.Match(data);
                var item = CreateSchematicItem(m.Groups[1].Value, currentColumn, currentRow);

                for (int i = item.X; i < item.X + item.Width; i++)
                {
                    grid[currentRow, i] = item;
                }

                currentColumn += item.Width;
                data = data[item.Width..];
            }

            currentRow++;
        }

        public void LinkSymbolNeighbors()
        {
            foreach (var symbol in symbols)
            {
                foreach (var (x, y) in symbol.GetNeighbors())
                {
                    if (x < 0 || y < 0 || x >= width || y >= height)
                        continue;
                    grid[y, x].SymbolNeighbors.Add(symbol);
                }
            }
        }

        public void LinkSymbolNumberNeighbors()
        {
            foreach (var number in numbers)
            {
                foreach (var symbol in number.SymbolNeighbors)
                {
                    symbol.NumberNeighbors.Add(number);
                }
            }
        }

        private SchematicItem CreateSchematicItem(string itemValue, int x, int y)
        {
            SchematicItem item;
            switch (itemValue[0])
            {
                case var c when char.IsNumber(c):
                    numbers.Add(new NumberSchematicItem(itemValue));
                    item = numbers.Last();
                    break;
                case '.':
                    item = new VoidSchematicItem();
                    break;
                default:
                    symbols.Add(new SymbolSchematicItem(itemValue));
                    item = symbols.Last();
                    break;
            }

            item.X = x;
            item.Y = y;
            item.Width = itemValue.Length;

            return item;
        }
    }
}
