// Write a program that reads from the console a sequence of positive integer numbers. 
// The sequence ends when empty line is entered. Calculate and print the sum and average
// of the elements of the sequence. Keep the sequence in List<int>.

namespace SumAndAverageOfSequence
{
    using System;
    using System.Collections.Generic;

    public class SumAndAverageOfSequence
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

            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }

            double average = sum / numbers.Count;

            Console.WriteLine("Your numbers are:");
            Console.WriteLine(string.Join(", ", numbers));
            Console.WriteLine("Sum = " + sum);
            Console.WriteLine("Average = " + average);
        }
    }
}
