namespace Day08.Tests
{
    public class TestMap
    {
        [Test]
        public void TestTraverse1()
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
        public void TestTraverse2()
        {
            var x = new Map();
            x.AddDirections("LLR");
            x.AddNode("AAA = (BBB, BBB)");
            x.AddNode("BBB = (AAA, ZZZ)");
            x.AddNode("ZZZ = (ZZZ, ZZZ)");

            Assert.That(x.Traverse(), Is.EqualTo(6));
        }

        [Test]
        public void TestMultipathTraverse()
        {
            var x = new Map();
            x.AddDirections("LR");
            x.AddNode("11A = (11B, XXX)");
            x.AddNode("11B = (XXX, 11Z)");
            x.AddNode("11Z = (11B, XXX)");
            x.AddNode("22A = (22B, XXX)");
            x.AddNode("22B = (22C, 22C)");
            x.AddNode("22C = (22Z, 22Z)");
            x.AddNode("22Z = (22B, 22B)");
            x.AddNode("XXX = (XXX, XXX)");

            Assert.That(x.MultipathTraverse(), Is.EqualTo(6));
        }
    }
}