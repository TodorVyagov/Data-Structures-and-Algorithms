namespace ProcessLargeCollection
{
    using System;

    public class Product : IComparable
    {
        public decimal Price { get; set; }

        public string Name { get; set; }

        public int CompareTo(object obj)
        {
            Product other = (Product)obj;
            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return this.Name + " -> " + this.Price;
        }
    }
}
