namespace KnapsackProblem
{
    internal class Product
    {
        public string Name { get; set; }

        public int Weight { get; set; }

        public int Price { get; set; }

        public static Product InitializeProduct(string name, int weight, int price)
        {
            var product = new Product
            {
                Name = name,
                Weight = weight,
                Price = price
            };
            return product;
        }

        public override string ToString()
        {
            return this.Name + "; weight: " + this.Weight + "; price: " + this.Price;
        }
    }
}
