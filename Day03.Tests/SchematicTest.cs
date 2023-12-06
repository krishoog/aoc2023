namespace Day03.Tests
{
    public class SchematicTest
    {
        private Schematic schematic;

        [SetUp]
        public void SetUp()
        {
            schematic = new Schematic(10, 10);
            schematic.LoadRow("467..114..");
            schematic.LoadRow("...*......");
            schematic.LoadRow("..35..633.");
            schematic.LoadRow("......#...");
            schematic.LoadRow("617*......");
            schematic.LoadRow(".....+.58.");
            schematic.LoadRow("..592.....");
            schematic.LoadRow("......755.");
            schematic.LoadRow("...$.*....");
            schematic.LoadRow(".664.598..");
        }

        [Test]
        public void TestLoadRow()
        {
            Assert.That(schematic.Numbers.Count, Is.EqualTo(10));
            Assert.That(schematic.Symbols.Count, Is.EqualTo(6));
        }

        [Test]
        public void TestMarkPartNumbers()
        {
            schematic.MarkPartNumbers();
            Assert.That(schematic.PartNumbers.Sum(x => x.Value), Is.EqualTo(4361));
        }
    }
}