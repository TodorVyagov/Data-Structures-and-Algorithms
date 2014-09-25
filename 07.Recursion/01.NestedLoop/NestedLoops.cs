namespace NestedLoops
{
    using System;

    internal class NestedLoops
    {
        const int n = 3;
        static int[] arr = new int[n];
        static int variationsCount = 0;

        static void Main()
        {
            GenerateVariations(0);
            Console.WriteLine("Combinations are " + variationsCount);
        }

        static void GenerateVariations(int index)
        {
            if (index >= arr.Length)
            {
                Print();
                return;
            }

            for (int i = 0; i < n; i++)
            {
                arr[index] = i + 1;
                GenerateVariations(index + 1);
            }
        }

        private static void Print()
        {
            Console.WriteLine("[ " + string.Join(", ", arr) + " ]");
            variationsCount++;
        }
    }
}
