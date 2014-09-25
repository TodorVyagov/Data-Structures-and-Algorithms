namespace CombinationsWIthDuplicates
{
    using System;

    internal class Combinations
    {
        static int n = 6;
        static int k = 3;
        static int[] arr = new int[k];

        static void Main()
        {
            // Task 2. Write a recursive program for generating and printing all the combinations with duplicates of k elements
            // from n-element set. Example: n=3, k=2 -> (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)
            Console.WriteLine("Combinations with repetitions:");
            GenerateCombinationsWithRepetitions(0, 0);

            // Task 3. Modify the previous program to skip duplicates:
            // n=4, k=2 -> (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)
            Console.WriteLine("Combinations without repetitions:");
            GenerateCombinationsWithoutRepetitions(0, 0);
        }

        static void GenerateCombinationsWithoutRepetitions(int index, int start)
        {
            if (index >= arr.Length)
            {
                Print();
                return;
            }

            for (int i = start; i < n; i++)
            {
                arr[index] = i + 1;
                GenerateCombinationsWithoutRepetitions(index + 1, i + 1);
            }
        }

        static void GenerateCombinationsWithRepetitions(int index, int start)
        {
            if (index >= arr.Length)
            {
                Print();
                return;
            }

            for (int i = start; i < n; i++)
            {
                arr[index] = i + 1;
                GenerateCombinationsWithRepetitions(index + 1, i);
            }
        }

        private static void Print()
        {
            Console.WriteLine("[ " + string.Join(", ", arr) + " ]");
        }
    }
}
