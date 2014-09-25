namespace Permutations
{
    using System;

    internal class Permutations
    {
        static int[] arr = new int[] { 1, 2, 3, 4 };

        private static void Main()
        {
            // Write a recursive program for generating and printing all permutations of the numbers 1, 2, ...n for given integer
            // number n. Example:	n=3 -> {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2},{3, 2, 1}

            GeneratePermutations(0);
        }

        static void GeneratePermutations(int index)
        {
            if (index >= arr.Length)
            {
                Print();
                return;
            }

            GeneratePermutations(index + 1);
            for (int i = index + 1; i < arr.Length; i++)
            {
                Swap(ref arr[index], ref arr[i]);
                GeneratePermutations(index + 1);
                Swap(ref arr[index], ref arr[i]);
            }
        }

        private static void Swap(ref int p1, ref int p2)
        {
            int oldValue = p1;
            p1 = p2;
            p2 = oldValue;
        }

        private static void Print()
        {
            Console.WriteLine("[ " + string.Join(", ", arr) + " ]");
        }
    }
}
