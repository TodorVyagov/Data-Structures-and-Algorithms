// Write a program that removes from given sequence all numbers that occur odd number of times.
namespace RemoveOddTimesRepeatedNumbersFromSequence
{
    using System;
    using System.Collections.Generic;

    public class RemoveOddTimesRepeatedNumbersFromSequence
    {
        public static void Main()
        {
            Console.WriteLine("This program will remove all numbers that occur odd number of times.");
            List<int> numbers = new List<int> { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            List<int> numbersToDelete = new List<int>();
            List<int> counted = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                int repeatingCounter = 0;

                for (int j = i; j < numbers.Count; j++)
                {
                    if (numbers[i] == numbers[j] && !counted.Contains(numbers[i]))
                    {
                        repeatingCounter++;
                    }
                }

                // Console.WriteLine("Number {0} is repeated {1} times", numbers[i], repeatingCounter);
                counted.Add(numbers[i]);

                if (repeatingCounter % 2 != 0)
                {
                    numbersToDelete.Add(numbers[i]);
                }
            }

            Console.WriteLine("Sequence:\n" + string.Join(", ", numbers));

            for (int i = 0; i < numbersToDelete.Count; i++)
            {
                numbers.RemoveAll(num => num == numbersToDelete[i]);
            }

            Console.WriteLine("Numbers after deleting:\n" + string.Join(", ", numbers));
        }
    }
}
