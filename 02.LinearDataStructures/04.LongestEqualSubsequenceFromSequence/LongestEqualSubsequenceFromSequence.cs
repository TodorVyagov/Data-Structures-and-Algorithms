// Write a method that finds the longest subsequence of equal numbers in given List<int> 
// and returns the result as new List<int>. Write a program to test whether the method works correctly.

namespace LongestEqualSubsequenceFromSequence
{
    using System;
    using System.Collections.Generic;

    public class LongestEqualSubsequenceFromSequence
    {
        public static void Main()
        {
            Console.WriteLine("This program will find the longest subsequence of equal numbers.");
            List<int> numbers = new List<int> { 1, 1, 1, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 5 };
            List<int> longestSequence = new List<int>();
            int startIndex = 0;
            int maxSequenceLength = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                int currentSequenceLength = 0;

                for (int j = i; j < numbers.Count; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        currentSequenceLength++;
                    }
                    else
                    {
                        if (currentSequenceLength > maxSequenceLength)
                        {
                            maxSequenceLength = currentSequenceLength;
                            startIndex = i;
                            i = j;
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < maxSequenceLength; i++)
            {
                longestSequence.Add(numbers[startIndex + i]);
            }

            Console.WriteLine("Sequence: " + string.Join(", ", numbers));
            Console.WriteLine("Longest sequence of equal elements is: " + string.Join(", ", longestSequence));
            Console.WriteLine("Start index = {0}, Length = {1}", startIndex, maxSequenceLength);
        }
    }
}
