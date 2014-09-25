// Write a program that counts in a given array of double values the number of occurrences of each value.
// Use Dictionary<TKey,TValue>.
namespace CountOccurancesInArray
{
    using System;
    using System.Collections.Generic;

    public class CountOccurancesInArray
    {
        public static void Main()
        {
            Console.WriteLine("THis program will count all occurances of double numbers in given array");
            double[] numbers = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            var dictionary = new Dictionary<double, int>();
            foreach (var number in numbers)
            {
                if (dictionary.ContainsKey(number))
                {
                    dictionary[number] += 1;
                }
                else
                {
                    dictionary[number] = 1;
                }
            }

            Console.WriteLine("Array is:\n" + string.Join(", ", numbers));
            foreach (var pair in dictionary)
            {
                Console.WriteLine("Number {0, 4} is repeated {1, 2} times.", pair.Key, pair.Value);
            }
        }
    }
}
