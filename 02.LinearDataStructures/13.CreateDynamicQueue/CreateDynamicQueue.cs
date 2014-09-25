namespace CreateDynamicQueue
{
    using System;

    public class CreateDynamicQueue
    {
        public static void Main()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(10);
            queue.Enqueue(111);
            queue.Enqueue(37);
            queue.Enqueue(24);
            Console.WriteLine(queue);
            Console.WriteLine("Count = " + queue.Count);

            Console.WriteLine("Delete first element = " + queue.Dequeue());
            Console.WriteLine(queue);

            Console.WriteLine("Delete first element = " + queue.Dequeue());
            Console.WriteLine(queue);

            Console.WriteLine("Look at first element = " + queue.Peek());
            Console.WriteLine(queue);

            Console.WriteLine("Clear the queue");
            queue.Clear();
            Console.WriteLine(queue);
        }
    }
}
