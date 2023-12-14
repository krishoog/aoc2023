using System.Text.RegularExpressions;

namespace Day08
{
    public class Map
    {
        private readonly record struct Node(string left, string right);

        private readonly Dictionary<string, Node> nodes = [];
        private const string firstNode = "AAA";
        private const string lastNode = "ZZZ";
        private const string multipathFirstNodeEnding = "A";
        private const string multipathLastNodeEnding = "Z";
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

        public int MultipathTraverse()
        {
            var currentNodes = nodes.Where(x => x.Key.EndsWith(multipathFirstNodeEnding)).Select(x => x.Key).ToArray();
            var steps = 0;
            while (!currentNodes.All(x => x.EndsWith(multipathLastNodeEnding)))
            {
                if (directions[steps % directions.Length] == 'R')
                {
                    for (int i = 0; i < currentNodes.Length; i++)
                    {
                        currentNodes[i] = nodes[currentNodes[i]].right;
                    }
                }
                else
                {
                    for (int i = 0; i < currentNodes.Length; i++)
                    {
                        currentNodes[i] = nodes[currentNodes[i]].left;
                    }
                }

                steps++;
            }

            return steps;
        }
    }
}
