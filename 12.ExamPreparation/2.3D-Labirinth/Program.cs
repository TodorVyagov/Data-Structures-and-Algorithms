namespace Labirinth3D
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static int levelsCount;
        private static int rowsCount;
        private static int colsCount;
        private static char[, ,] labirinth;
        private static bool[, ,] visitedCells;
        private static byte[, ,] shortestPaths;
        private static int moves;
        private static int result;

        static void Main()
        {
            int[] startPositionCoords = Console.ReadLine().Split(new[] { ' ' }).Select(int.Parse).ToArray();
            Position startPosition = new Position
            {
                Level = startPositionCoords[0],
                Row = startPositionCoords[1],
                Col = startPositionCoords[2]
            };

            int[] labirinthSizes = Console.ReadLine().Split(new[] { ' ' }).Select(int.Parse).ToArray();
            levelsCount = labirinthSizes[0];
            rowsCount = labirinthSizes[1];
            colsCount = labirinthSizes[2];
            labirinth = new char[levelsCount, rowsCount, colsCount];
            visitedCells = new bool[levelsCount, rowsCount, colsCount];
            shortestPaths = new byte[levelsCount, rowsCount, colsCount];

            for (int level = 0; level < levelsCount; level++)
            {
                for (int row = 0; row < rowsCount; row++)
                {
                    string currentRow = Console.ReadLine();

                    for (int col = 0; col < colsCount; col++)
                    {
                        labirinth[level, row, col] = currentRow[col];
                    }
                }
            }

            moves = 0;
            result = int.MaxValue;

            // PrintLabirinth();
            // Console.WriteLine(startPosition);
            ExploreLabirinth(startPosition.Level, startPosition.Row, startPosition.Col);
            Console.WriteLine(result);
        }

        private static void ExploreLabirinth(int level, int row, int col)
        {
            // validation conditions
            if (0 > level || level >= levelsCount || 0 > row || row >= rowsCount || 0 > col || col >= colsCount)
            {
                return;
            }

            // this cell is a wall
            if (labirinth[level, row, col] == '#' || visitedCells[level, row, col])
            {
                return;
            }

            if (shortestPaths[level, row, col] < moves && shortestPaths[level, row, col] > 0)
            {
                return;
            }

            moves++;
            visitedCells[level, row, col] = true;
            shortestPaths[level, row, col] = (byte)moves;
            // exit conditions
            if (labirinth[level, row, col] == 'D' && level == 0)
            {
                SaveResult();
                visitedCells[level, row, col] = false;
                moves--;
                return;
            }
            else if (labirinth[level, row, col] == 'U' && level == levelsCount - 1)
            {
                SaveResult();
                visitedCells[level, row, col] = false;
                moves--;
                return;
            }

            // navigation
            if (labirinth[level, row, col] == 'U')
            {
                ExploreLabirinth(level + 1, row, col);
            }
            else if (labirinth[level, row, col] == 'D')
            {
                ExploreLabirinth(level - 1, row, col);
            }
            else
            {
                // explore in 4 directions
                ExploreLabirinth(level, row, col + 1); // right
                ExploreLabirinth(level, row + 1, col); // down
                ExploreLabirinth(level, row, col - 1); // left
                ExploreLabirinth(level, row - 1, col); // up
            }

            visitedCells[level, row, col] = false;
            moves--;
        }

        private static void SaveResult()
        {
            if (result > moves)
            {
                result = moves;
            }
        }

        private static void PrintLabirinth()
        {
            for (int level = 0; level < levelsCount; level++)
            {
                Console.WriteLine("Level {0}", level);
                for (int row = 0; row < rowsCount; row++)
                {
                    for (int col = 0; col < colsCount; col++)
                    {
                        Console.Write("{0, 2}", labirinth[level, row, col]);
                    }

                    Console.WriteLine();
                }
            }
        }
    }

    struct Position
    {
        public int Level { get; set; }

        public int Row { get; set; }

        public int Col { get; set; }

        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", this.Level, this.Row, this.Col);
        }
    }
}
