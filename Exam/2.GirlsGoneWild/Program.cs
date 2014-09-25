namespace GirlsGoneWild
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static SortedSet<string> uniqueWays = new SortedSet<string>();
        static string letters;
        static int[] combinationsArr;
        static int lettersCount;
        static int girlsCount;
        static int[] variationsArr;
        static bool[] used;

        static void Main()
        {
            int combinationsN = int.Parse(Console.ReadLine());
            letters = Console.ReadLine().Trim();
            girlsCount = int.Parse(Console.ReadLine());
            lettersCount = letters.Length;
            combinationsArr = new int[girlsCount];
            used = new bool[lettersCount];
            variationsArr = new int[girlsCount];
            GenerateCombinations(combinationsN, girlsCount);

            Console.WriteLine(uniqueWays.Count);
            foreach (var line in uniqueWays)
            {
                Console.WriteLine(line);
            }
        }
        static void GenerateCombinations(int N, int K)
        {
            if (K == 0) //Exit condition of recursion and print current row before exit
            {
                GenerateVariations(0);
                return;
            }

            for (int i = 0; i < N; i++)
            {
                combinationsArr[combinationsArr.Length - K] = i;
                bool isHigherOrEqual = false;

                for (int j = 0; j < combinationsArr.Length - K; j++)
                {
                    if (combinationsArr[combinationsArr.Length - K] <= combinationsArr[j])
                    {
                        isHigherOrEqual = true;
                    }
                }

                if (isHigherOrEqual)
                {
                    continue;
                }

                GenerateCombinations(N, K - 1);
            }
        }

        static void GenerateVariations(int index)
        {
            if (index >= girlsCount)
            {
                PrintVariations();
            }
            else
            {
                for (int i = 0; i < lettersCount; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        variationsArr[index] = i;
                        GenerateVariations(index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        static void PrintVariations()
        {
            string row = string.Empty;
            for (int i = 0; i < variationsArr.Length; i++)
            {
                row += combinationsArr[i] + letters[variationsArr[i]].ToString() + "-";
            }

            uniqueWays.Add(row.Substring(0, row.Length - 1));
        }
    }
}
