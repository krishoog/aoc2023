namespace Day10
{
    public class Maze
    {
        private enum Color { Red, Blue };

        private enum Direction { NorthEast, SouthWest };

        private class Cell
        {
            private readonly List<Cell> links = [];
            public char Type { get; init; }
            public int X { get; init; }
            public int Y { get; init; }
            public List<Cell> Links { get => links; }
            public bool IsMainLoop { get; set; }
            public Color? Color { get; set; }

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

        public int FindLoop()
        {
            var loop = 0;
            foreach (var neighbor in startCell.Links)
            {
                List<Cell> loopCells = [startCell];
                var previousCell = startCell;
                var currentCell = neighbor;
                while (currentCell != null && currentCell.Type != '.' && !ReferenceEquals(currentCell, startCell))
                {
                    loopCells.Add(currentCell);
                    var nextCell = currentCell.Next(previousCell);
                    previousCell = currentCell;
                    currentCell = nextCell;
                }

                if (ReferenceEquals(currentCell, startCell))
                {
                    loopCells.ForEach(x => x.IsMainLoop = true);
                    MarkColors(loopCells);
                    loop = loopCells.Count;
                    break;
                }
            }

            return loop;
        }

        public int CountEnclosed()
        {
            return Math.Min(
                maze.Sum(y => y.Count(x => x.Color == Color.Red)),
                maze.Sum(y => y.Count(x => x.Color == Color.Blue)));
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
                    var cell = new Cell() { Type = c, X = cells.Count, Y = rows.Count };
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
                foreach (var cell in maze[y])
                {
                    switch (cell.Type)
                    {
                        case '|':
                            AddNorthToCell(cell);
                            AddSouthToCell(cell);
                            break;
                        case '-':
                            AddEastToCell(cell);
                            AddWestToCell(cell);
                            break;
                        case 'L':
                            AddNorthToCell(cell);
                            AddEastToCell(cell);
                            break;
                        case 'J':
                            AddNorthToCell(cell);
                            AddWestToCell(cell);
                            break;
                        case '7':
                            AddWestToCell(cell);
                            AddSouthToCell(cell);
                            break;
                        case 'F':
                            AddEastToCell(cell);
                            AddSouthToCell(cell);
                            break;
                        case 'S':
                            AddNorthToCell(cell, "LJ");
                            AddEastToCell(cell, "LF");
                            AddSouthToCell(cell, "F7");
                            AddWestToCell(cell, "J7");
                            break;
                    }
                }
            }
        }

        private void AddNorthToCell(Cell cell, string exclude = "")
        {
            AddLinkToCell(cell, 0, -1, exclude);
        }

        private void AddEastToCell(Cell cell, string exclude = "")
        {
            AddLinkToCell(cell, +1, 0, exclude);
        }

        private void AddSouthToCell(Cell cell, string exclude = "")
        {
            AddLinkToCell(cell, 0, +1, exclude);
        }

        private void AddWestToCell(Cell cell, string exclude = "")
        {
            AddLinkToCell(cell, -1, 0, exclude);
        }

        private void AddLinkToCell(Cell cell, int x, int y, string exclude)
        {
            var link = GetCellOrNull(cell.X + x, cell.Y + y);
            if (link != null && !exclude.ToCharArray().Any(x => x == link.Type))
            {
                cell.Links.Add(link);
            }
        }

        private void MarkColors(List<Cell> mainLoop)
        {
            MarkAdjecentColors(mainLoop);
            GrowColor(Color.Red);
            GrowColor(Color.Blue);
        }

        private void MarkAdjecentColors(List<Cell> mainLoop)
        {
            var dir = (mainLoop[1].X > mainLoop[0].X || mainLoop[1].Y < mainLoop[0].Y) ? Direction.NorthEast : Direction.SouthWest;
            foreach (var cell in mainLoop)
            {
                List<(Cell?, Color)> adjecent = [];
                var d = dir == Direction.NorthEast ? 1 : -1;
                switch (cell.Type)
                {
                    case '|':
                        adjecent.Add((GetCellOrNull(cell.X + d, cell.Y), Color.Red));
                        adjecent.Add((GetCellOrNull(cell.X - d, cell.Y), Color.Blue));
                        break;
                    case '-':
                        adjecent.Add((GetCellOrNull(cell.X, cell.Y + d), Color.Red));
                        adjecent.Add((GetCellOrNull(cell.X, cell.Y - d), Color.Blue));
                        break;
                    case 'L':
                        dir = Direction.NorthEast;
                        break;
                    case '7':
                        dir = Direction.SouthWest;
                        break;
                    case 'J':
                    case 'F':
                        adjecent.Add((GetCellOrNull(cell.X + d, cell.Y), Color.Red));
                        adjecent.Add((GetCellOrNull(cell.X - d, cell.Y), Color.Blue));
                        adjecent.Add((GetCellOrNull(cell.X, cell.Y + d), Color.Red));
                        adjecent.Add((GetCellOrNull(cell.X, cell.Y - d), Color.Blue));
                        break;
                }

                foreach (var (c, color) in adjecent)
                {
                    if (c != null && !c.IsMainLoop)
                    {
                        c.Color = color;
                    }
                }
            }
        }

        private void GrowColor(Color color)
        {
            Stack<Cell> colored = [];
            for (int y = 0; y < maze.Length; y++)
            {
                foreach (var cell in maze[y].Where(x => x.Color == color))
                {
                    colored.Push(cell);
                }
            }

            while (colored.TryPop(out var cell))
            {
                List<Cell?> neighbors = [
                    GetCellOrNull(cell.X, cell.Y - 1),
                    GetCellOrNull(cell.X + 1, cell.Y),
                    GetCellOrNull(cell.X, cell.Y + 1),
                    GetCellOrNull(cell.X - 1, cell.Y)];
                foreach (var neighbor in neighbors)
                {
                    if (neighbor != null && !neighbor.IsMainLoop && neighbor.Color == null)
                    {
                        neighbor.Color = color;
                        colored.Push(neighbor);
                    }
                }
            }
        }

        private Cell? GetCellOrNull(int x, int y)
        {
            if (y >= 0 && y < maze.Length && x >= 0 && x < maze[y].Length)
            {
                return maze[y][x];
            }

            return null;
        }
    }
}
