// Implement the data structure "set" in a class HashedSet<T> using your class HashTable<K,T> to hold the elements.
// Implement all standard set operations like Add(T), Find(T), Remove(T), Count, Clear(), union and intersect.
namespace HashTableAndSet
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HashedSet<T> where T : IComparable<T>
    {
        private HashTable<int, T> table;
        private int count;

        public HashedSet()
        {
            this.table = new HashTable<int, T>();
            this.count = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Add(T element)
        {
            if (this.Find(element) >= 0)
            {
                // the element already exists in the HashedSet
                return;
            }

            this.table.Add(this.count, element);
            this.count++;
        }
        
        public bool Contains(T element)
        {
            int index = this.Find(element);
            if (index < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Remove(T element)
        {
            int key = this.Find(element);
            if (key >= 0)
            {
                this.table.Remove(key);
                this.count--;
                return true;
            }

            return false;
        }

        public void Clear()
        {
            this.table = new HashTable<int, T>();
            this.count = 0;
        }

        public void UnionWith(HashedSet<T> otherSet)
        {
            foreach (var item in otherSet.table)
            {
                this.Add(item.Value);
            }
        }

        public void IntersectWith(HashedSet<T> otherSet)
        {
            foreach (var item in otherSet.table)
            {
                if (!this.Contains(item.Value))
                {
                    this.Remove(item.Value);
                }
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            foreach (var item in this.table)
            {
                result.Append(item.Value + ", ");
            }

            if (result.Length > 2)
            {
                result.Length -= 2;
            }

            return result.ToString();
        }

        private int Find(T element)
        {
            // what Find() has to do? To find Key of the element. You do not need it when using HashSet.
            // If you want to check if element exists the method name should be: Contains(T value).
            // In HashTable by given key you can find the value, but now this method has no sense.
            // So I made it private and now am using it to search for the Key by given element.
            foreach (var item in this.table)
            {
                if (item.Value.CompareTo(element) == 0)
                {
                    return item.Key;
                }
            }

            return -1;
        }
    }
}
