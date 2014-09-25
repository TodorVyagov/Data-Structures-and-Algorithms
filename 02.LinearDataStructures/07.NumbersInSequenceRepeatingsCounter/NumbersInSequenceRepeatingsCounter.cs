/*Write a program that finds in given array of integers (all belonging to the range [0..1000])
how many times each of them occurs.
Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
2  2 times
3  4 times
4  3 times
*/
namespace NumbersInSequenceRepeatingsCounter
{
    using System;
    using System.Collections.Generic;

    public class NumbersInSequenceRepeatingsCounter
    {
        public static void Main()
        {
            Console.WriteLine("This program will find in given array of integers how many times each of them occurs.");
            int[] numbers = new int[] { 3, 4, 7, 4, 2, 3, 3, 4, 3, 2, 5, 6, 7, -10, -10 };
            var numbersWithCount = new SortedDictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];
                if (numbersWithCount.ContainsKey(currentNumber))
                {
                    numbersWithCount[currentNumber]++;
                }
                else
                {
                    numbersWithCount.Add(currentNumber, 1);
                }
            }

            Console.WriteLine("Array is:\n" + string.Join(", ", numbers));
            foreach (var item in numbersWithCount)
            {
                Console.WriteLine("Number {0} is repeated {1} times.", item.Key, item.Value);
            }
        }
    }
}
