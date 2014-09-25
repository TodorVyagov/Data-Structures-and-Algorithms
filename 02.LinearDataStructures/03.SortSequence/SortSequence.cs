// Write a program that reads a sequence of integers (List<int>) ending with an empty line 
// and sorts them in an increasing order.

namespace SortSequence
{
    using System;
    using System.Collections.Generic;

    public class SortSequence
    {
        public static void Main()
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            List<int> numbers = new List<int>();

            while (!string.IsNullOrWhiteSpace(input))
            {
                int numberFromUser;
                if (!int.TryParse(input, out numberFromUser))
                {
                    Console.WriteLine("Incorrect number format.");
                    input = Console.ReadLine();
                    continue;
                }

                numbers.Add(numberFromUser);
                Console.WriteLine("Enter new number. If you finished with numbers enter empty line:");
                input = Console.ReadLine();
            }

            Console.WriteLine("Your numbers are: " + string.Join(", ", numbers));

            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = i; j < numbers.Count; j++)
                {
                    if (numbers[i] > numbers[j])
                    {
                        int oldValue = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = oldValue;
                    }
                }
            }

            Console.WriteLine("Sorted numbers are: " + string.Join(", ", numbers));
        }
    }
}
