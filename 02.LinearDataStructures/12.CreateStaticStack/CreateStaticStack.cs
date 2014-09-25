// Implement the ADT stack as auto-resizable array. Resize the capacity on demand 
// (when no space is available to add / insert a new element).
namespace CreateStaticStack
{
    using System;

    public class CreateStaticStack
    {
        public static void Main()
        {
            // Most important methods are implemented and work perfectly =) 
            // StatickStack.Pop() method reuses the StaticStack.Peek() method and there is no duplicating code.
            StaticStack<int> myStack = new StaticStack<int>();
            myStack.Push(3);
            myStack.Push(4);
            myStack.Push(-10);
            myStack.Push(12);
            Console.WriteLine(myStack);

            Console.WriteLine("Delete top element: " + myStack.Pop());
            Console.WriteLine(myStack);
            Console.WriteLine("See the value of top element: " + myStack.Peek());
            Console.WriteLine(myStack);
            Console.WriteLine("Count = " + myStack.Count);
            myStack.Push(56);
            Console.WriteLine(myStack);
            Console.WriteLine("Clear the stack");
            myStack.Clear();
            Console.WriteLine("Empty $" + myStack + "$ stack");
            myStack.Push(2222);
            Console.WriteLine(myStack);
        }
    }
}
