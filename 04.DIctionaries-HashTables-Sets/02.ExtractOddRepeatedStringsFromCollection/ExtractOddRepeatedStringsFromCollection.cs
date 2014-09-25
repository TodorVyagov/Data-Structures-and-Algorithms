// Write a program that extracts from a given sequence of strings all elements that present in it odd number of times. 
namespace ExtractOddRepeatedStringsFromCollection
{
    using System;
    using System.Collections.Generic;

    public class ExtractOddRepeatedStringsFromCollection
    {
        public static void Main()
        {
            Console.WriteLine(
                "This program will extract from a given sequence of strings all elements that present in it odd number of times");
            string[] words = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "C++", "SQL", "Databases", "C++" };
            var dictionary = new Dictionary<string, int>();

            // this way we will iterate through the array only once
            Console.WriteLine("Words are:");
            foreach (var word in words)
            {
                Console.Write(word + " ");
                if (dictionary.ContainsKey(word))
                {
                    dictionary[word] += 1;
                }
                else
                {
                    dictionary.Add(word, 1);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Searched words are:");
            foreach (var pair in dictionary)
            {
                if (pair.Value % 2 == 1)
                {
                    Console.Write(pair.Key + " ");
                }
            }

            Console.WriteLine();
        }
    }
}
