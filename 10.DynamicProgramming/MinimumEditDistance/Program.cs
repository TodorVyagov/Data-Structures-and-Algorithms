using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumEditDistance
{
    class Program
    {
        private const double InsertCost = 0.8;
        private const double DeleteCost = 0.9;
        private const double ReplaceCost = 1;

        static void Main(string[] args)
        {
            Console.Write("aunt -> ant cost = ");
            Console.WriteLine(ComputeLevenshteinDistance("aunt", "ant"));

            Console.Write("Sam -> Samantha cost = ");
            Console.WriteLine(ComputeLevenshteinDistance("Sam", "Samantha"));

            Console.Write("flomax -> volmax cost = ");
            Console.WriteLine(ComputeLevenshteinDistance("flomax", "volmax"));

            Console.Write("developer => enveloped cost = ");
            Console.WriteLine(ComputeLevenshteinDistance("developer", "enveloped"));
        }

        public static double ComputeLevenshteinDistance(string initialWord, string destinationWord)
        {
            int n = initialWord.Length;
            int m = destinationWord.Length;
            double[,] costsTable = new double[n + 1, m + 1];

            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            for (int row = 0; row <= n; row++)
            {
                costsTable[row, 0] = row * DeleteCost;
            }

            for (int j = 0; j <= m; j++)
            {
                costsTable[0, j] = j * InsertCost;
            }

            for (int row = 1; row <= n; row++)
            {
                for (int col = 1; col <= m; col++)
                {
                    double cost = (destinationWord[col - 1] == initialWord[row - 1]) ? 0 : ReplaceCost;

                    double delete = costsTable[row - 1, col] + DeleteCost;
                    double replace = costsTable[row - 1, col - 1] + cost;
                    double insert = costsTable[row, col - 1] + InsertCost;
                    costsTable[row, col] = Math.Min(Math.Min(delete, replace), insert);
                }
            }

            return costsTable[n, m];
        }
    }
}