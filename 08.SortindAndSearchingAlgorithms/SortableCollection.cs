namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            int start = 0;
            int end = items.Count - 1;
            int middle;
            while (start < end)
            {
                middle = (start + end) / 2;

                if (items[middle].CompareTo(item) == 0)
                {
                    return true;
                }
                else if (items[middle].CompareTo(item) > 0)
                {
                    end = middle - 1;
                }
                else
                {
                    start = middle + 1;
                }
            }

            return false;
        }

        public void Shuffle()
        {
            var random = new Random();
            for (int i = 0; i < items.Count; i++)
            {
                Swap(i, random.Next(0, this.items.Count));
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }

        private void Swap(int index1, int index2)
        {
            T oldValue = this.items[index1];
            this.items[index1] = this.items[index2];
            this.items[index2] = oldValue;
        }
    }
}
