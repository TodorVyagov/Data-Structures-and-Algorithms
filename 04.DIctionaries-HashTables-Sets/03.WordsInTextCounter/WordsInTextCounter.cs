// Write a program that counts how many times each word from given text file words.txt appears in it.
// The character casing differences should be ignored. The result words should be ordered by their
// number of occurrences in the text. 
namespace WordsInTextCounter
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class WordsInTextCounter
    {
        public static void Main()
        {
            Console.WriteLine("This program will count how many times each word from given text file words.txt appears in it and sort them by number of ocuurances.");
            var dictionary = new SortedDictionary<string, int>(new CaseInsensitiveComparer());
            Console.WriteLine("Text is:");

            using (var reader = new StreamReader(@"..\..\text.txt"))
            {
                // if we have very big text it is better to read it line by line
                string line = reader.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line.ToString());

                    string[] words = line.Split(
                        new[] { ' ', ',', '.', '!', '-', '?', '/', '-' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var word in words)
                    {
                        if (dictionary.ContainsKey(word))
                        {
                            dictionary[word]++;
                        }
                        else
                        {
                            dictionary[word] = 1;
                        }
                    }

                    Console.WriteLine();
                    line = reader.ReadLine();
                }
            }

            var countedWrds = dictionary
                .Select(s => new
                {
                    Key = s.Value,
                    Value = s.Key
                })
                .OrderBy(s => s.Key);

            foreach (var pair in countedWrds)
            {
                Console.WriteLine("Word: {0, 8} -> {1, 2} times.", pair.Value, pair.Key);
            }
        }
    }
}
