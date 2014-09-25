namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[minIndex].CompareTo(collection[j]) > 0)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    Swap(collection, minIndex, i);
                }
            }
        }

        private void Swap(IList<T> collection, int index1, int index2)
        {
            T oldValue = collection[index1];
            collection[index1] = collection[index2];
            collection[index2] = oldValue;
        }
    }
}
