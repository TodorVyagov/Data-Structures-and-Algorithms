/*We are given the following sequence:
S1 = N;
S2 = S1 + 1;
S3 = 2*S1 + 1;
S4 = S1 + 2;
S5 = S2 + 1;
S6 = 2*S2 + 1;
S7 = S2 + 2;
...
Using the Queue<T> class write a program to print its first 50 members for given N.
Example: N=2  2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...*/
namespace PrintFiftyNumbersOfSequence
{
    using System;
    using System.Collections.Generic;

    public class PrintFiftyNumbersOfSequence
    {
        public static void Main()
        {
            int startNumber = 2;
            Queue<int> sequence = new Queue<int>();
            sequence.Enqueue(startNumber);
            int counter = 0;

            while (counter++ < 50)
            {
                int numberToAdd = sequence.Dequeue();
                Console.Write(numberToAdd + " ");
                sequence.Enqueue(numberToAdd + 1);
                sequence.Enqueue((numberToAdd * 2) + 1);
                sequence.Enqueue(numberToAdd + 2);
            }
        }
    }
}
