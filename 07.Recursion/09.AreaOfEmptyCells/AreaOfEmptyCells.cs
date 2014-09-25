namespace AreaOfEmptyCells
{
    using System;

    internal class AreaOfEmptyCells
    {
        static int[,] matrix = new int[,]
        {
            {0,0,1,0,0},
            {0,1,1,0,0},
            {0,1,0,1,0},
            {1,0,0,0,9}
        };
        static int maxEmptyCells = 0;
        static int currentEmptyCellsCount = 0;

        private static void Main()
        {
            // Write a recursive program to find the largest connected area of adjacent empty cells in a matrix.
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    currentEmptyCellsCount = 0;
                    EmptyCellsCounter(row, col);
                }
            }

            Console.WriteLine("The largest connected area of adjacent empty cells has {0} cells", maxEmptyCells);
        }

        private static void EmptyCellsCounter(int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] == 0)
            {
                // mark current cell as visited
                matrix[row, col] = 1;
                currentEmptyCellsCount++;
                if (currentEmptyCellsCount > maxEmptyCells)
                {
                    maxEmptyCells = currentEmptyCellsCount;
                }
            }
            else // if (matrix[row, col] != 0)
            {
                // cell is visited or blocked by wall
                return;
            }

            // traverse all directions
            EmptyCellsCounter(row - 1, col); // up
            EmptyCellsCounter(row, col + 1); // right
            EmptyCellsCounter(row + 1, col); // down
            EmptyCellsCounter(row, col - 1); // left

        }
    }
}
