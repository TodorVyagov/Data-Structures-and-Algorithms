namespace PathsInMatrix
{
    using System;

    internal class PathsInMatrix
    {
        static int[,] matrix = new int[,]
        {
            {0,0,0,0,0},
            {0,1,1,0,0},
            {0,1,0,1,0},
            {1,0,0,0,9}
        };
        static int counterOfPaths = 0;

        private static void Main()
        {
            // Task 7. We are given a matrix of passable and non-passable cells. Write a recursive program for finding 
            // all paths between two cells in the matrix.
            // we satrt from [0,0]
            FindPaths(0, 0);
            PrintMatrix();
            Console.WriteLine("All possible paths are: " + counterOfPaths);

            // Task 8. Modify the above program to check whether a path exists between two cells without finding 
            // all possible paths. Test it over an empty 100 x 100 matrix.
            // One way is to break the recursion when we find a way to the destination cell
            // Smarter way is to use BFS and find the shortest path, but this program cannot be modified to do this.
            // Use a Queue and put there all new possible unvisited adjacent cells.
            matrix = new int[100, 100];
            matrix[99, 99] = 9;
            // the method is the same, but when we find a way just stop the program.
            FindPath(0, 0);
        }

        private static void FindPaths(int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row,col] == 9)
            {
                // 9 is our destination cell
                counterOfPaths++;
                return;
            }
            else if (matrix[row, col] != 0)
            {
                // cell is visited or blocked by wall
                return;
            }

            // mark current cell as visited
            matrix[row, col] = 1;

            // traverse all directions
            FindPaths(row - 1, col); // up
            FindPaths(row, col + 1); // right
            FindPaths(row + 1, col); // down
            FindPaths(row, col - 1); // left

            matrix[row, col] = 0;
        }

        private static void FindPath(int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] == 9)
            {
                // 9 is our destination cell
                Console.WriteLine("Such path exists!");
                Environment.Exit(0);
            }
            else if (matrix[row, col] != 0)
            {
                // cell is visited or blocked by wall
                return;
            }

            // mark current cell as visited
            matrix[row, col] = 1;

            // traverse all directions
            FindPath(row - 1, col); // up
            FindPath(row, col + 1); // right
            FindPath(row + 1, col); // down
            FindPath(row, col - 1); // left

            matrix[row, col] = 0;
        }

        static void PrintMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
