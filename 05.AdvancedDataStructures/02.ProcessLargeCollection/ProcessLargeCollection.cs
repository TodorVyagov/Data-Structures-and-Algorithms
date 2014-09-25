namespace ProcessLargeCollection
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class ProcessLargeCollection
    {
        public static void Main()
        {
            OrderedBag<Product> bag = new OrderedBag<Product>();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 500000; i++)
            {

                bag.Add(new Product
                {
                    Name = "Pesh" + i,
                    Price = i * 2
                });
            }

            sw.Stop();
            Console.WriteLine("OrderedBag: Time needed to create 500'000 products: {0}", sw.Elapsed);

            sw.Restart();
            for (int i = 0; i < 10000; i++)
            {
                var results = bag
                    .FindAll(p => p.Price > i && p.Price < i * i)
                    .Take(20);
            }

            sw.Stop();
            Console.WriteLine("OrderedBag: Time needed for 10'000 searches of 20 elements: {0}", sw.Elapsed);
            Console.WriteLine();
            TestWithHashSet();
        }

        public static void TestWithHashSet()
        {
            var set = new SortedSet<Product>();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 500000; i++)
            {

                set.Add(new Product
                {
                    Name = "Pesh" + i,
                    Price = i * 2
                });
            }

            sw.Stop();
            Console.WriteLine("HashSet: Time needed to create 500'000 products: {0}", sw.Elapsed);

            sw.Restart();
            for (int i = 0; i < 10000; i++)
            {
                var results = set
                    .Where(p => p.Price > i && p.Price < i * i)
                    .Take(20);
            }

            sw.Stop();
            Console.WriteLine("HashSet: Time needed for 10'000 searches of 20 elements: {0}", sw.Elapsed);
        }
    }
}
