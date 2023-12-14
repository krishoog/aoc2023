using System.Text.RegularExpressions;

namespace Day08
{
    public class Map
    {
        private class Node
        {
            public Node(string label)
            {
                Label = label;
            }

            public string Label { get; init; }
            public Node? Left { get; set; }
            public Node? Right { get; set; }

            public Node NextNode(char direction)
            {
                return direction == 'R' ? Right : Left;
            }
        }

        private readonly Dictionary<string, (string, string)> nodes = [];
        private const string firstNodeLabel = "AAA";
        private const string lastNodeLabel = "ZZZ";
        private const string multipathFirstNodeLabelEnding = "A";
        private const string multipathLastNodeLabelEnding = "Z";
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
            nodes[name] = (left, right);
        }

        public int Traverse()
        {
            var node = BuildGraph(firstNodeLabel);

            return CountSteps(node, lastNodeLabel);
        }

        public long MultipathTraverse()
        {
            var graphs = nodes.Where(x => x.Key.EndsWith(multipathFirstNodeLabelEnding)).Select(x => BuildGraph(x.Key));
            var steps = graphs.Select(x => (long)CountSteps(x, multipathLastNodeLabelEnding));

            return LCM(steps);
        }

        private int CountSteps(Node node, string label)
        {
            var steps = 0;
            while (!node.Label.EndsWith(label))
            {
                node = node.NextNode(directions[steps % directions.Length]);
                steps++;
            }

            return steps;
        }

        private Node BuildGraph(string rootNodeLabel)
        {
            var stack = new Stack<Node>();
            var repository = new Dictionary<string, Node>();
            var root = CreateNode(rootNodeLabel, stack, repository);
            while (stack.Count > 0)
            {
                var current = stack.Pop();

                current.Left = FindOrCreateNode(nodes[current.Label].Item1, stack, repository);
                current.Right = FindOrCreateNode(nodes[current.Label].Item2, stack, repository);
            }

            return root;
        }

        private Node FindOrCreateNode(string label, Stack<Node> stack, Dictionary<string, Node> repository)
        {
            if (!repository.TryGetValue(label, out Node? node))
            {
                node = CreateNode(label, stack, repository);
            }

            return node;
        }

        private static Node CreateNode(string label, Stack<Node> stack, Dictionary<string, Node> repository)
        {
            var node = new Node(label);

            repository[label] = node;
            stack.Push(node);

            return node;
        }

        // https://stackoverflow.com/a/29717490
        static long LCM(IEnumerable<long> numbers)
        {
            return numbers.Aggregate(lcm);
        }
        static long lcm(long a, long b)
        {
            return Math.Abs(a * b) / GCD(a, b);
        }
        static long GCD(long a, long b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
    }
}
