namespace CreateLinkedList
{
    using System;

    public class CreateLinkedList
    {
        public static void Main()
        {
            // More methods can be implemented, but I made the basic functionality and I have no time.
            LinkedList<int> elements = new LinkedList<int>(2);
            elements.Add(10);
            elements.Add(12);
            elements.Add(120);
            elements.Add(1);
            Console.WriteLine(elements);

            // Delete tested at first, middle and last position.
            elements.Remove(2);
            Console.WriteLine(elements);
            elements.Remove(12);
            Console.WriteLine(elements);
            elements.Remove(1);
            Console.WriteLine(elements);
        }
    }
}
