namespace Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static int numberOfEmployees;
        private static int[,] graph;
        private static bool[] visitedElements;
        private static List<int> sortedElements = new List<int>();

        static void Main()
        {
            numberOfEmployees = int.Parse(Console.ReadLine());
            graph = new int[numberOfEmployees, numberOfEmployees];
            visitedElements = new bool[numberOfEmployees];

            for (int i = 0; i < numberOfEmployees; i++)
            {
                string currentEmployeeDependancies = Console.ReadLine();
                for (int charIndex = 0; charIndex < currentEmployeeDependancies.Length; charIndex++)
                {
                    if (currentEmployeeDependancies[charIndex] == 'Y')
                    {
                        graph[i, charIndex] = 1;
                    }
                }
            }

            for (int i = 0; i < numberOfEmployees; i++)
            {
                if (visitedElements[i] == false)
                {
                    Dfs(i);
                }
            }

            long totalSalaries = 0;
            long[] salaries = new long[numberOfEmployees];
            foreach (int elementIndex in sortedElements)
            {
                bool isManager = false;

                for (int col = 0; col < numberOfEmployees; col++)
                {
                    if (graph[elementIndex, col] == 1)
                    {
                        salaries[elementIndex] += salaries[col];
                        isManager = true;
                    }
                }

                if (!isManager)
                {
                    salaries[elementIndex] = 1;
                }

                totalSalaries += salaries[elementIndex];
            }

            //Console.WriteLine(string.Join(", ", salaries));
            Console.WriteLine(totalSalaries);
        }

        public static void Dfs(int startIndex)
        {
            visitedElements[startIndex] = true;

            for (int k = 0; k < numberOfEmployees; k++)
            {
                if ((graph[startIndex, k] == 1) && (visitedElements[k] == false))
                {
                    Dfs(k);
                }
            }

            sortedElements.Add(startIndex);
        }
    }
}
