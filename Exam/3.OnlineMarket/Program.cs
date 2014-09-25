namespace OnlineMarket
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {
        static void Main()
        {
            var result = new StringBuilder();
            var uniqueNames = new HashSet<string>();
            var typeProducts = new Dictionary<string, List<Product>>(); // holds type => product
            var priceProducts = new SortedDictionary<decimal, List<Product>>(); // holds price => product

            while (true)
            {
                string currentLine = Console.ReadLine().Trim();

                if (currentLine == "end")
                {
                    break;
                }

                string[] commands = currentLine.Split(new[] { ' ' });

                // on each add we will add name to uniqueNames
                if (commands[0] == "add")
                {
                    string productName = commands[1];
                    // check for unique name
                    if (uniqueNames.Contains(productName))
                    {
                        result.AppendLine(string.Format("Error: Product {0} already exists", productName));
                        continue;
                    }

                    uniqueNames.Add(productName);
                    var product = new Product
                    {
                        Name = productName,
                        Price = decimal.Parse(commands[2]),
                        Type = commands[3]
                    };

                    // adding in typeNames
                    if (!typeProducts.ContainsKey(product.Type))
                    {
                        typeProducts.Add(product.Type, new List<Product>());
                    }

                    typeProducts[product.Type].Add(product);

                    // adding in prices collection
                    if (!priceProducts.ContainsKey(product.Price))
                    {
                        priceProducts.Add(product.Price, new List<Product>());
                    }

                    priceProducts[product.Price].Add(product);

                    result.AppendLine(string.Format("Ok: Product {0} added successfully", product.Name));
                }
                else if (commands[0] == "filter")
                {
                    string filterBy = commands[2];

                    if (filterBy == "type")
                    {
                        string type = commands[3];
                        if (!typeProducts.ContainsKey(type))
                        {
                            result.AppendLine(string.Format("Error: Type {0} does not exists", type)); // check for correct sintax!
                            continue;
                        }

                        result.AppendLine(string.Format("Ok: {0}",
                            string.Join(", ", typeProducts[type].OrderBy(p => p.Price)
                                                                .ThenBy(p => p.Name)
                                                                .ThenBy(p => p.Type)
                                                                .Take(10))));
                    }
                    else if (filterBy == "price")
                    {
                        decimal minPrice = decimal.MinValue;
                        decimal maxPrice = decimal.MaxValue;
                        string priceFilter = commands[3];

                        if (priceFilter == "from")
                        {
                            //	filter by price from MIN_PRICE  
                            minPrice = decimal.Parse(commands[4]);

                            if (commands.Length == 7)
                            {
                                // filter by price from MIN_PRICE to MAX_PRICE 
                                maxPrice = decimal.Parse(commands[6]);
                            }
                        }
                        else if (priceFilter == "to")
                        {
                            // filter by price to MAX_PRICE 
                            maxPrice = decimal.Parse(commands[4]);
                        }

                        // select data
                        var filteredCollection = new List<Product>(1000);
                        foreach (var pair in priceProducts)
                        {
                            if (pair.Key >= minPrice && pair.Key <= maxPrice)
                            {
                                filteredCollection.AddRange(pair.Value);
                            }

                            if (filteredCollection.Count >= 10)
                            {
                                break;
                            }
                        }

                        result.AppendLine(string.Format("Ok: {0}", string.Join(", ",
                            filteredCollection.OrderBy(p => p.Price)
                                              .ThenBy(p => p.Name)
                                              .ThenBy(p => p.Type)
                                              .Take(10))));
                    }
                }
            }

            result.Length--;
            Console.WriteLine(result);
        }
    }

    struct Product
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Type { get; set; }

        public override string ToString()
        {
            return string.Format("{0}({1:0.##############})", this.Name, this.Price);
        }
    }
}
