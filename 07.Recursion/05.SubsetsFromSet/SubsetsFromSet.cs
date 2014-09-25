namespace SubsetsFromSet
{
    using System;

    class SubsetsFromSet
    {
        const int n = 3;
        const int k = 2;
        static int[] arr = new int[k];
        static string[] words = new string[] { "hi", "a", "b" };

        static void Main()
        {
            // Task 5. Write a recursive program for generating and printing all ordered k-element subsets from n-element set 
            // (variations Vkn).
            // Example: n=3, k=2, set = {hi, a, b} => (hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)
            GenerateSubsets(0);

            // Task 6. Write a program for generating and printing all subsets of k strings from given set of strings.
            // Example: s = {test, rock, fun}, k=2 -> (test rock),  (test fun),  (rock fun)
            Console.WriteLine("Next task 6.");
            words = new string[] { "test", "rock", "fun" };
            GenerateWordSubsets(0, 0);
        }

        static void GenerateSubsets(int index)
        {
            if (index >= arr.Length)
            {
                Print();
                return;
            }

            for (int i = 0; i < n; i++)
            {
                arr[index] = i + 1;
                GenerateSubsets(index + 1);
            }
        }

        private static void GenerateWordSubsets(int index, int start)
        {
            if (index >= arr.Length)
            {
                Print();
                return;
            }

            for (int i = start; i < n; i++)
            {
                arr[index] = i + 1;
                GenerateWordSubsets(index + 1, i + 1);
            }
        }

        private static void Print()
        {
            Console.Write(string.Join(", ", arr) + " -> ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(words[arr[i] - 1] + ", ");
            }

            Console.WriteLine();
        }
    }
}
