namespace BinaryPasswords
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main()
        {
            // read binary password
            string input = Console.ReadLine();

            int starsCount = input.Count(i => i == '*');

            Console.WriteLine((long)1 << starsCount);
            // 100 points in BGCoder
            // and a minimized version
            // Console.WriteLine((long)1 << Console.ReadLine().Count(i => i == '*'));
        }
    }
}
