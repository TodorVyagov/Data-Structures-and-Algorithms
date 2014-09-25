namespace HashTableAndSet
{
    using System;

    public class Testing
    {
        public static void Main()
        {
            TestHashTable();
            TestHashedSet();
        }

        private static void TestHashedSet()
        {
            Console.WriteLine("\nHashedSet testing:");

            HashedSet<int> set = new HashedSet<int>();
            set.Add(10);
            set.Add(4);
            set.Add(12);
            set.Add(6);
            set.Add(8);
            set.Add(12);
            Console.WriteLine(set);

            set.Remove(12);
            Console.WriteLine(set);

            Console.WriteLine("Contains 2? " + set.Contains(2));
            Console.WriteLine("Contains 4? " + set.Contains(4));

            Console.WriteLine("Elements count = " + set.Count);
        }

        private static void TestHashTable()
        {
            HashTable<int, string> table = new HashTable<int, string>();
            table.Add(12, "Krum");
            table.Add(11, "Koko");
            table.Add(1000, "Krum");

            // duplicate elements are not added
            table.Add(12, "Krum");

            foreach (var item in table)
            {
                Console.WriteLine(item.Key + " -> " + item.Value);
            }

            Console.WriteLine();
            table.Remove(12);

            foreach (var item in table)
            {
                Console.WriteLine(item.Key + " -> " + item.Value);
            }

            // test capacity increasing
            for (int i = 0; i < 20; i++)
            {
                table.Add(i + 20, i.ToString());
            }

            Console.WriteLine("\nOrder in hash tables is not guaranteed!");

            foreach (var item in table)
            {
                Console.WriteLine(item.Key + " -> " + item.Value);
            }
        }
    }
}
