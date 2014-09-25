namespace CreateStaticStack
{
    using System;

    public class StaticStack<T>
    {
        private const int INITIAL_STACK_SIZE = 4;

        private T[] elements;
        private int count = 0;

        public StaticStack()
        {
            this.elements = new T[INITIAL_STACK_SIZE];
        }

        public StaticStack(T[] elements)
        {
            this.elements = elements;
        }

        public int Count
        {
            get { return this.count; }
        }

        public void Push(T elementToAdd)
        {
            if (this.elements.Length == this.count)
            {
                this.ExpandStackSize();
            }

            this.elements[this.count] = elementToAdd;
            this.count++;
        }

        public T Pop()
        {
            // we do not need to delete the element, but only decrease the count
            T poppedElement = this.Peek();
            this.count--;
            return poppedElement;
        }

        public T Peek()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("Stack empty");
            }

            return this.elements[this.count - 1];
        }

        public void Clear()
        {
            this.elements = new T[INITIAL_STACK_SIZE]; // this can be skipped
            this.count = 0;
        }

        public override string ToString()
        {
            T[] actualSizeArray = new T[this.count];
            Array.Copy(this.elements, actualSizeArray, this.count);
            return string.Join(", ", actualSizeArray);
        }

        private void ExpandStackSize()
        {
            T[] oldElements = (T[])this.elements.Clone();
            int oldSize = this.elements.Length;
            this.elements = new T[oldSize * 2];

            for (int index = 0; index < oldSize; index++)
            {
                this.elements[index] = oldElements[index];
            }
        }
    }
}
