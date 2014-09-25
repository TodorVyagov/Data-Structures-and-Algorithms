namespace Frames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static SortedSet<string> permutations;

        static void Main()
        {
            permutations = new SortedSet<string>();
            int n = int.Parse(Console.ReadLine());
            Frame[] frames = new Frame[n];
            for (int i = 0; i < n; i++)
            {
                int[] inputLine = Console.ReadLine().Split(new[]{' '}).Select(int.Parse).ToArray();
                frames[i] = new Frame
                {
                    Width = inputLine[0],
                    Height = inputLine[1]
                };

            }

            GeneratePermutations(frames, 0);
            Console.WriteLine(permutations.Count);
            foreach (var perm in permutations)
            {
                Console.WriteLine(perm);
            }
        }

        static void GeneratePermutations(Frame[] arr, int k)
        {
            if (k >= arr.Length)
            {
                permutations.Add(string.Join(" | ", arr));
            }
            else
            {
                GeneratePermutations(arr, k + 1);
                Swap(ref arr[k]);
                GeneratePermutations(arr, k + 1);
                Swap(ref arr[k]);

                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);

                    GeneratePermutations(arr, k + 1);
                    Swap(ref arr[k]);
                    GeneratePermutations(arr, k + 1);
                    Swap(ref arr[k]);

                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }

        static void Swap(ref Frame first)
        {
            int oldFirst = first.Width;
            first.Width = first.Height;
            first.Height = oldFirst;
        }

        struct Frame
        {
            public int Width { get; set; }

            public int Height { get; set; }

            public override string ToString()
            {
                return string.Format("({0}, {1})", this.Width, this.Height);
            }
        }
    }
}
