namespace RowOfColorfulBalls
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    internal class Program
    {
        private static List<BigInteger> factorials = new List<BigInteger>();

        private static void Main()
        {
            string input = Console.ReadLine();
            //input = "BYYBB";
            //input = "RYYRYBY";
            var dict = new Dictionary<char, int>();
            foreach (var color in input)
            {
                if (!dict.ContainsKey(color))
                {
                    dict[color] = 0;
                }

                dict[color]++;
            }

            int n = input.Length;
            BigInteger divisor = 1;

            foreach (var pair in dict)
            {
                divisor *= CalculateFactorial(pair.Value);
            }

            BigInteger result = CalculateFactorial(n) / divisor;
            Console.WriteLine(result);
            // 100 points in BGCoder
        }

        private static BigInteger CalculateFactorial(int number)
        {
            if (factorials.Count >= number)
            {
                return factorials[number];
            }

            if (number == 0 || number == 1)
            {
                return 1;
            }

            BigInteger result = CalculateFactorial(number - 1) * number;
            return result;
        }
    }
}
