namespace Day08.Tests
{
    public class TestMap
    {
        [Test]
        public void Test1()
        {
            var x = new Map();
            x.AddDirections("RL");
            x.AddNode("AAA = (BBB, CCC)");
            x.AddNode("BBB = (DDD, EEE)");
            x.AddNode("CCC = (ZZZ, GGG)");
            x.AddNode("DDD = (DDD, DDD)");
            x.AddNode("EEE = (EEE, EEE)");
            x.AddNode("GGG = (GGG, GGG)");
            x.AddNode("ZZZ = (ZZZ, ZZZ)");

            Assert.That(x.Traverse(), Is.EqualTo(2));
        }

        [Test]
        public void Test2()
        {
            var x = new Map();
            x.AddDirections("LLR");
            x.AddNode("AAA = (BBB, BBB)");
            x.AddNode("BBB = (AAA, ZZZ)");
            x.AddNode("ZZZ = (ZZZ, ZZZ)");

            Assert.That(x.Traverse(), Is.EqualTo(6));
        }
    }
}