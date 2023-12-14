using System.Text.RegularExpressions;

namespace Day08
{
    public class Map
    {
        private readonly record struct Node(string left, string right);

        private readonly Dictionary<string, Node> nodes = [];
        private const string firstNode = "AAA";
        private const string lastNode = "ZZZ";
        private string? directions;

        public void AddDirections(string directions)
        {
            this.directions = directions;
        }

        public void AddNode(string data)
        {
            var rx = new Regex(@"(\w+) = \((\w+), (\w+)\)");
            var m = rx.Match(data);

            AddNode(m.Groups[1].Value, m.Groups[2].Value, m.Groups[3].Value);
        }

        public void AddNode(string name, string left, string right)
        {
            nodes[name] = new Node(left, right);
        }

        public int Traverse()
        {
            var currentNode = firstNode;
            var steps = 0;
            while (currentNode != lastNode)
            {
                if (directions[steps % directions.Length] == 'R')
                {
                    currentNode = nodes[currentNode].right;
                }
                else
                {
                    currentNode = nodes[currentNode].left;
                }

                steps++;
            }

            return steps;
        }
    }
}
