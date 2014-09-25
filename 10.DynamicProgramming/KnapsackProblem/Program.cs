namespace KnapsackProblem
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main()
        {
            var products = new List<Product>()
            {
                Product.InitializeProduct("beer", 3, 2),
                Product.InitializeProduct("vodka", 8, 12),
                Product.InitializeProduct("cheese", 4, 5),
                Product.InitializeProduct("nuts", 1, 4),
                Product.InitializeProduct("ham", 2, 3),
                Product.InitializeProduct("whiskey", 8, 13)
            };

            int totalSumOfWeights = 0;

            foreach (var product in products)
            {
                totalSumOfWeights += product.Weight;
            }

            totalSumOfWeights++;
            bool[] weights = new bool[totalSumOfWeights];
            int[] prices = new int[totalSumOfWeights];
            List<string>[] productsForWeight = new List<string>[totalSumOfWeights];

            int largestNonEmptyIndex = 0;
            weights[0] = true;
            productsForWeight[0] = new List<string>();

            foreach (var product in products)
            {
                for (int i = largestNonEmptyIndex; i >= 0; i--)
                {
                    if (weights[i])
                    {
                        int newIndex = i + product.Weight;
                        largestNonEmptyIndex = newIndex > largestNonEmptyIndex ? newIndex : largestNonEmptyIndex;
                        weights[newIndex] = true;

                        int oldPrice = prices[newIndex];
                        int newPrice = prices[i] + product.Price;
                        if (oldPrice < newPrice)
                        {
                            var oldProducts = productsForWeight[i];
                            prices[newIndex] = newPrice;
                            productsForWeight[newIndex] = new List<string>(oldProducts);
                            productsForWeight[newIndex].Add(product.Name);
                        }
                    }
                }
            }

            int kilograms = 10;
            int maxSum = 0;
            int index = 0;
            for (int i = kilograms; i >= 0; i--)
            {
                if (prices[i] > maxSum)
                {
                    maxSum = prices[i];
                    index = i;
                }
            }

            Console.WriteLine("Maximal sum of products with weight {0}kg is {1}$ and the products are: {2}({3}kg weight)",
                kilograms, prices[index], string.Join(", ", productsForWeight[index]), index);
        }
    }
}