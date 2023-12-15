
namespace Day10
{
    public class Maze
    {
        private class Cell
        {
            private readonly List<Cell> links = [];
            public char Type { get; init; }
            public List<Cell> Links { get => links; }

            public Cell? Next(Cell from)
            {
                return Links.Where(x => !ReferenceEquals(x, from)).FirstOrDefault();
            }
        }

        private readonly Cell[][] maze = [];
        private readonly Cell startCell;

        public Maze(IEnumerable<string> lines)
        {
            maze = BuildMaze(lines, out startCell);
            LinkMaze();
        }

        public int FindLoopLength()
        {
            var loop = 0;
            foreach (var neighbor in startCell.Links)
            {
                var steps = 0;
                var previousCell = startCell;
                var currentCell = neighbor;
                while (currentCell != null && currentCell.Type != '.' && !ReferenceEquals(currentCell, startCell))
                {
                    var nextCell = currentCell.Next(previousCell);
                    previousCell = currentCell;
                    currentCell = nextCell;
                    steps++;
                }

                if (ReferenceEquals(currentCell, startCell))
                {
                    loop = steps;
                    break;
                }
            }

            return loop + 1;
        }

        private Cell[][] BuildMaze(IEnumerable<string> lines, out Cell? start)
        {
            List<Cell[]> rows = [];
            start = null;
            foreach (var line in lines)
            {
                List<Cell> cells = [];
                foreach (var c in line)
                {
                    var cell = new Cell() { Type = c };
                    if (c == 'S')
                    {
                        start = cell;
                    }
                    cells.Add(cell);
                }
                rows.Add([.. cells]);
            }

            return [.. rows];
        }

        private void LinkMaze()
        {
            for (int y = 0; y < maze.Length; y++)
            {
                for (int x = 0; x < maze[y].Length; x++)
                {
                    var cell = maze[y][x];
                    switch (cell.Type)
                    {
                        case '|':
                            AddLinkToCell(cell, x, y - 1);
                            AddLinkToCell(cell, x, y + 1);
                            break;
                        case '-':
                            AddLinkToCell(cell, x - 1, y);
                            AddLinkToCell(cell, x + 1, y);
                            break;
                        case 'L':
                            AddLinkToCell(cell, x, y - 1);
                            AddLinkToCell(cell, x + 1, y);
                            break;
                        case 'J':
                            AddLinkToCell(cell, x, y - 1);
                            AddLinkToCell(cell, x - 1, y);
                            break;
                        case '7':
                            AddLinkToCell(cell, x - 1, y);
                            AddLinkToCell(cell, x, y + 1);
                            break;
                        case 'F':
                            AddLinkToCell(cell, x + 1, y);
                            AddLinkToCell(cell, x, y + 1);
                            break;
                        case 'S':
                            AddLinkToCell(cell, x, y - 1);
                            AddLinkToCell(cell, x + 1, y);
                            AddLinkToCell(cell, x, y + 1);
                            AddLinkToCell(cell, x - 1, y);
                            break;
                    }
                }
            }
        }

        private void AddLinkToCell(Cell cell, int x, int y)
        {
            if (y >= 0 && y < maze.Length && x >= 0 && x < maze[y].Length)
            {
                cell.Links.Add(maze[y][x]);
            }
        }
    }
}
