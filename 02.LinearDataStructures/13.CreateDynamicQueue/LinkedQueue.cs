namespace CreateDynamicQueue
{
    using System;
    using System.Text;

    public class LinkedQueue<T>
    {
        private QueueItem<T> head;
        private QueueItem<T> tail;
        private int count = 0;

        public LinkedQueue()
        {
        }

        public LinkedQueue(T element)
        {
            QueueItem<T> item = new QueueItem<T>(element);
            this.head = item;
            this.tail = item;
        }

        public int Count 
        {
            get
            {
                return this.count;
            }
        }

        public void Enqueue(T elementToAdd)
        {
            QueueItem<T> itemToAdd = new QueueItem<T>(elementToAdd);

            if (this.count == 0)
            {
                this.head = itemToAdd;
            }
            else if (this.count == 1)
            {
                this.head.NextElement = itemToAdd;
                this.tail = itemToAdd;
            }
            else
            {
                this.tail.NextElement = itemToAdd;
                this.tail = itemToAdd;
            }

            this.count++;
        }

        public T Dequeue()
        {
            T valueOfDeletedElement = this.Peek();

            // delete link to first element, and now second element becomes first
            this.head = this.head.NextElement;
            this.count--;
            
            return valueOfDeletedElement;
        }

        public T Peek()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("Stack empty");
            }

            return this.head.Value;
        }

        public void Clear()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            QueueItem<T> currentItem = this.head;

            while (currentItem != null)
            {
                result.Append(currentItem.Value + ", ");
                currentItem = currentItem.NextElement;
            }

            // if queue is empty we have to make this check
            if (result.Length > 2)
            {
                result.Length -= 2;
            }

            return result.ToString();
        }
    }
}
