namespace PriorityQueueImplementation
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Imeplementation of priority queue is based on a Binary heap. 
    /// Elements qiut the queue in descending order of their values.
    /// </summary>
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private IList<T> elements;

        public PriorityQueue()
        {
            this.elements = new List<T>();
        }

        public void Enqueue(T element)
        {
            // add theelement in the array
            this.elements.Add(element);
            if (this.elements.Count == 1)
            {
                // the tree was empty before insert
                return;
            }

            // put it in the right position
            int childIndex = this.elements.Count - 1;
            int parentIndex = this.FindParentIndex(childIndex);
            while (parentIndex >= 0)
            {
                T parent = this.elements[parentIndex];
                T child = this.elements[childIndex];
                if (parent.CompareTo(child) < 0)
                {
                    this.Swap(childIndex, parentIndex);
                }
                else
                {
                    break;
                }

                childIndex = parentIndex;
                parentIndex = this.FindParentIndex(parentIndex);
            }
        }

        public T Dequeue()
        {
            // save value of root in a variable and replace it with last element in array
            if (this.elements.Count == 0)
            {
                throw new ArgumentNullException("Cannot get element. The binary heap is empty.");
            }

            T rootElement = this.elements[0];
            int lastElementIndex = this.elements.Count - 1;
            this.elements[0] = this.elements[lastElementIndex];
            this.elements.RemoveAt(lastElementIndex);

            // check if greater child is bigger than new root and if true Swap them
            int parentIndex = 0;
            int greaterChildIndex = this.FindGreaterChildIndex(parentIndex);
            while (greaterChildIndex >= 0)
            {
                T parent = this.elements[parentIndex];
                T child = this.elements[greaterChildIndex];

                if (parent.CompareTo(child) < 0)
                {
                    this.Swap(parentIndex, greaterChildIndex);
                }
                else
                {
                    break;
                }
            }

            return rootElement;
        }

        public void PrintOnConsoleWithDFS(int startIndex, string indentation)
        {
            // node, left, right
            if (startIndex >= this.elements.Count)
            {
                return;
            }

            this.PrintOnConsoleWithDFS((startIndex * 2) + 1, indentation + "|--");
            Console.WriteLine(indentation + this.elements[startIndex]);
            this.PrintOnConsoleWithDFS((startIndex * 2) + 2, indentation + "|--");
        }

        public override string ToString()
        {
            return string.Join(", ", this.elements);
        }

        private void Swap(int childIndex, int parentIndex)
        {
            T oldValue = this.elements[childIndex];
            this.elements[childIndex] = this.elements[parentIndex];
            this.elements[parentIndex] = oldValue;
        }

        private int FindParentIndex(int childIndex)
        {
            if (childIndex < 1)
            {
                return -1;
            }

            int parentIndex = (childIndex - 1) / 2;
            return parentIndex;
        }

        private int FindGreaterChildIndex(int parentIndex)
        {
            int childOneIndex = (parentIndex * 2) + 1;
            int childTwoIndex = (parentIndex * 2) + 2;
            int lastElementIndex = this.elements.Count - 1;

            if (childOneIndex >= lastElementIndex)
            {
                return -1;
            }
            else if (childTwoIndex >= lastElementIndex)
            {
                return childOneIndex;
            }
            else
            {
                if (this.elements[childOneIndex].CompareTo(this.elements[childTwoIndex]) > 0)
                {
                    return childOneIndex;
                }
                else
                {
                    return childTwoIndex;
                }
            }
        }
    }
}
