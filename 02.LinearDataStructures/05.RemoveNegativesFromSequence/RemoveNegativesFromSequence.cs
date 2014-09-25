// Write a program that removes from given sequence all negative numbers.
namespace RemoveNegativesFromSequence
{
    using System;
    using System.Collections.Generic;

    public class RemoveNegativesFromSequence
    {
        public static void Main()
        {
            Console.WriteLine("This program will remove all negative numbers from given sequence.");

            List<int> numbers = new List<int>() { 1, -1, 1, -2, -2, 2, -3, 3, -3, -3, 3, 3, 3, 3, 4, -4, -4, 4, -5 };
            Console.WriteLine("Sequence:\n" + string.Join(", ", numbers));

            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                if (numbers[i] < 0)
                {
                    numbers.RemoveAt(i);
                }
            }

            Console.WriteLine("After removed nagative numbers:\n" + string.Join(", ", numbers));
        }
    }
}
