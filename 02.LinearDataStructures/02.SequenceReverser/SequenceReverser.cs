namespace SequenceReverser
{
    using System;
    using System.Collections.Generic;

    public class SequenceReverser
    {
        public static void Main()
        {
            // I know that the repeating code can be extracted into several methods, 
            // but have not enough time to make High Quality Code
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            Stack<int> numbers = new Stack<int>();

            while (!string.IsNullOrWhiteSpace(input))
            {
                int numberFromUser;
                if (!int.TryParse(input, out numberFromUser))
                {
                    Console.WriteLine("Incorrect number format.");
                    input = Console.ReadLine();
                    continue;
                }

                numbers.Push(numberFromUser);
                Console.WriteLine("Enter new number. If you finished with numbers enter empty line:");
                input = Console.ReadLine();
            }

            Console.WriteLine("Your numbers are:\n" + string.Join(", ", numbers));
            Console.WriteLine("Your numbers in reverse order are:");

            while (numbers.Count > 0)
            {
                Console.Write(numbers.Pop() + ", ");
            }

            Console.WriteLine();
        }
    }
}
