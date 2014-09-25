using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.OnlineMarket
{
    class Program
    {
        private static Dictionary<string, Dictionary<string, double>> typeNamePrice = new Dictionary<string, Dictionary<string, double>>();
        private static Dictionary<string, double> namePrice = new Dictionary<string, double>();
        static void Main(string[] args)
        {
            bool notOver = true;
            while (notOver)
            {

                string[] input = Console.ReadLine().Split(' ');
                string command = input[0];

                if (command == "add")
                {
                    Add(input);
                }

                if (command == "end")
                {
                    break;
                }

                if (command == "filter")
                {
                    Filter(input);
                }
            }
        }

        private static void Add(string[] input)
        {
            string name = input[1];
            double price = double.Parse(input[2]);
            string type = input[3];

            if (namePrice.ContainsKey(name))
            {
                Console.WriteLine("Error: Product {0} already exists", name);
                return;
            }

            namePrice[name] = price;

            if (!typeNamePrice.ContainsKey(type))
            {
                typeNamePrice[type] = new Dictionary<string, double>();
            }

            typeNamePrice[type].Add(name, price);
            Console.WriteLine("Ok: Product {0} added successfully", name);
            return;
        }


        private static void Filter(string[] input)
        {
            if (input[2] == "type")
            {
                Type(input);
            }

            else if (input[3] == "to")
            {
                To(input);
            }

            else if (input[3] == "from")
            {
                FromAndMore(input);
            }
        }

        private static void Type(string[] input)
        {
            // gets types
            string type = input[3];

            if (!typeNamePrice.ContainsKey(type))
            {
                Console.WriteLine("Error: Type {0} does not exists", type);
                return;
            }

            var initial = typeNamePrice[type];
            SortedDictionary<double, SortedSet<string>> filtered = new SortedDictionary<double, SortedSet<string>>();

            foreach (var item in initial)
            {
                if (!filtered.ContainsKey(item.Value))
                {
                    filtered[item.Value] = new SortedSet<string>();
                }

                filtered[item.Value].Add(item.Key);
            }

            StringBuilder result = CreteResult(filtered);

            PrintResult(result);
        }

        private static void To(string[] input)
        {
            // gets to max price
            double price = double.Parse(input[4]);
            SortedDictionary<double, SortedSet<string>> filtered = new SortedDictionary<double, SortedSet<string>>();
            foreach (var item in namePrice)
            {
                if (item.Value <= price)
                {
                    if (!filtered.ContainsKey(item.Value))
                    {
                        filtered[item.Value] = new SortedSet<string>();
                    }

                    filtered[item.Value].Add(item.Key);
                }
            }

            StringBuilder result = CreteResult(filtered);

            PrintResult(result);
        }


        private static void FromAndMore(string[] input)
        {
            // gets from min price
            if (input.Length < 7)
            {
                From(input);
            }
            else
            {
                FromTo(input);
            }
        }

        private static void FromTo(string[] input)
        {
            double priceMin = double.Parse(input[4]);
            double priceMax = double.Parse(input[6]);
            SortedDictionary<double, SortedSet<string>> filtered = new SortedDictionary<double, SortedSet<string>>();
            foreach (var item in namePrice)
            {
                if (item.Value >= priceMin && item.Value <= priceMax)
                {
                    if (!filtered.ContainsKey(item.Value))
                    {
                        filtered[item.Value] = new SortedSet<string>();
                    }

                    filtered[item.Value].Add(item.Key);

                }
            }

            StringBuilder result = CreteResult(filtered);

            PrintResult(result);

        }

        private static void PrintResult(StringBuilder result)
        {
            if (result.Length < 5)
            {
                Console.WriteLine(result.ToString());
                return;
            }
            result.Remove(result.Length - 2, 2);
            Console.WriteLine(result.ToString());
        }

        private static StringBuilder CreteResult(SortedDictionary<double, SortedSet<string>> filtered)
        {
            StringBuilder result = new StringBuilder("Ok: ");
            int index = 0;
            foreach (var byPrice in filtered)
            {
                foreach (var item in byPrice.Value)
                {
                    index++;
                    result.Append(string.Format("{0}({1}), ", item, byPrice.Key));
                    if (index == 10)
                    {
                        return result;
                    }
                }
            }
            return result;
        }

        private static void From(string[] input)
        {
            double price = double.Parse(input[4]);
            SortedDictionary<double, SortedSet<string>> filtered = new SortedDictionary<double, SortedSet<string>>();
            foreach (var item in namePrice)
            {
                if (item.Value >= price)
                {
                    if (!filtered.ContainsKey(item.Value))
                    {
                        filtered[item.Value] = new SortedSet<string>();
                    }

                    filtered[item.Value].Add(item.Key);
                }
            }

            StringBuilder result = CreteResult(filtered);

            PrintResult(result);

        }

    }
}
