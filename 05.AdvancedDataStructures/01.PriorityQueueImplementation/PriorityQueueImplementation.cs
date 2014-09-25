namespace PriorityQueueImplementation
{
    using System;

    public class PriorityQueueImplementation
    {
        public static void Main()
        {
            var priorityQueue = new PriorityQueue<int>();
            priorityQueue.Enqueue(10);
            priorityQueue.Enqueue(20);
            priorityQueue.Enqueue(35);
            priorityQueue.Enqueue(40);
            priorityQueue.Enqueue(60);
            Console.WriteLine("Added some elements: ");
            priorityQueue.PrintOnConsoleWithDFS(0, string.Empty);
            //// Console.WriteLine(priorityQueue);

            priorityQueue.Dequeue();
            Console.WriteLine("\nDeleted one: ");
            priorityQueue.PrintOnConsoleWithDFS(0, string.Empty);
            //// Console.WriteLine(priorityQueue);

            priorityQueue.Dequeue();
            Console.WriteLine("\nDeleted one more: ");
            priorityQueue.PrintOnConsoleWithDFS(0, string.Empty);
            //// Console.WriteLine(priorityQueue);

            priorityQueue.Dequeue();
            priorityQueue.Dequeue();
            priorityQueue.Dequeue();
            Console.WriteLine("\nDeleted all: ");
            priorityQueue.PrintOnConsoleWithDFS(0, string.Empty);
            //// Console.WriteLine(priorityQueue);
        }
    }
}
