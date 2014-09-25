namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.MergeSort(collection);
        }

        private void MergeSort(IList<T> main)
        {
            int mainCount = main.Count;
            if (mainCount < 2)
            {
                return;
            }

            IList<T> left = new List<T>();
            IList<T> right = new List<T>();
            for (int i = 0; i < mainCount; i++)
            {
                if (i < mainCount / 2)
                {
                    left.Add(main[i]);
                }
                else
                {
                    right.Add(main[i]);
                }
            }

            MergeSort(left);
            MergeSort(right);
            Merge(left, right, main);
        }

        private void Merge(IList<T> left, IList<T> right, IList<T> main)
        {
            int leftCount = left.Count;
            int rightCount = right.Count;
            int i = 0;
            int j = 0;
            int k = 0;
            while (i < leftCount && j < rightCount)
            {
                if (left[i].CompareTo(right[j]) < 0)
                {
                    main[k] = left[i];
                    i++;
                }
                else
                {
                    main[k] = right[j];
                    j++;
                }
                k++;
            }

            while (i < leftCount)
            {
                main[k] = left[i];
                i++;
                k++;
            }

            while (j > rightCount)
            {
                main[k] = right[j];
                j++;
                k++;
            }
        }
    }
}
