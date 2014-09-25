namespace Portals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static byte[,] labyrinth;
        static bool[,] visitedCells;
        static int rowsCount;
        static int colsCount;
        static int maximumPower;
        static int currentPower;

        static void Main()
        {
            int[] xAndY = Console.ReadLine().Split(new[] { ' ' }).Select(int.Parse).ToArray();
            int startRow = xAndY[0];
            int startCol = xAndY[1];

            int[] rAndC = Console.ReadLine().Split(new[] { ' ' }).Select(int.Parse).ToArray();
            rowsCount = rAndC[0];
            colsCount = rAndC[1];

            labyrinth = new byte[rowsCount, colsCount];
            visitedCells = new bool[rowsCount, colsCount];
            maximumPower = 0;
            currentPower = 0;

            for (int row = 0; row < rowsCount; row++)
            {
                string currentRow = Console.ReadLine().Trim();

                for (int col = 0; col < colsCount; col++)
                {
                    char currentSymbol = currentRow[col * 2];
                    byte currentElement;
                    if (char.IsDigit(currentSymbol))
                    {
                        currentElement = byte.Parse(currentSymbol.ToString());
                    }
                    else
                    {
                        currentElement = 0;
                    }

                    labyrinth[row, col] = currentElement;
                }

            }

            //Console.WriteLine();
            //PrintLabyrinth();

            ExproreLabyrinth(startRow, startCol);
            Console.WriteLine(maximumPower);
        }

        static void ExproreLabyrinth(int row, int col)
        {
            // validation out of matrix
            if (row < 0 || row >= rowsCount || col < 0 || col >= colsCount)
            {
                return;
            }

            // check if visited
            if (visitedCells[row, col])
            {
                return;
            }

            // check current cell power
            if (labyrinth[row, col] == 0)
            {
                return;
            }

            // mark as visited and add power
            visitedCells[row, col] = true;
            byte currentCellPower = labyrinth[row, col];

            if (!ValidateCell(row, col, currentCellPower))
            {
                return;
            }

            currentPower += currentCellPower;

            // check if max power
            if (maximumPower < currentPower)
            {
                maximumPower = currentPower;
            }

            // exprore 4 directions
            ExproreLabyrinth(row + currentCellPower, col); // down
            ExproreLabyrinth(row, col - currentCellPower); // left
            ExproreLabyrinth(row - currentCellPower, col); // up
            ExproreLabyrinth(row, col + currentCellPower); // right

            // unmark as visited and subtract power
            visitedCells[row, col] = false;
            currentPower -= currentCellPower;
        }

        private static bool ValidateCell(int row, int col, byte currentCellPower)
        {
            bool leftValid = (col - currentCellPower >= 0) && (labyrinth[row, col - currentCellPower] > 0);
            bool rightValid = (col + currentCellPower < colsCount) && (labyrinth[row, col + currentCellPower] > 0);
            bool upValid = (row - currentCellPower >= 0) && (labyrinth[row - currentCellPower, col] > 0);
            bool downValid = (row + currentCellPower < rowsCount) && (labyrinth[row + currentCellPower, col] > 0);
            bool isValid = leftValid || rightValid || upValid || downValid;
            return isValid;
        }

        static void PrintLabyrinth()
        {
            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < colsCount; col++)
                {
                    Console.Write(labyrinth[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
