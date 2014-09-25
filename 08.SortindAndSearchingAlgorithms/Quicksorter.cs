namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        private IList<T> collection;

        public void Sort(IList<T> collection)
        {
            this.collection = collection;

            this.QuickSort(0, collection.Count - 1);
        }

        private void QuickSort(int start, int end)
        {
            if (start < end)
            {
                int pivotIndex = this.Partition(start, end);
                this.QuickSort(start, pivotIndex - 1);
                this.QuickSort(pivotIndex + 1, end);
            }

        }

        private int Partition(int start, int end)
        {
            T pivot = collection[end];
            int pivotIndex = start;

            for (int i = start; i < end; i++)
            {
                if (collection[i].CompareTo(pivot) <= 0)
                {
                    this.Swap(i, pivotIndex);
                    pivotIndex++;
                }
            }

            Swap(pivotIndex, end);
            return pivotIndex;
        }

        private void Swap(int i, int j)
        {
            T oldValue = collection[i];
            collection[i] = collection[j];
            collection[j] = oldValue;
        }
    }
}
