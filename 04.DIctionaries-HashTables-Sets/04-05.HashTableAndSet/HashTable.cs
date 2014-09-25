// Implement the data structure "hash table" in a class HashTable<K,T>. Keep the data in array of lists of
// key-value pairs (LinkedList<KeyValuePair<K,T>>[]) with initial capacity of 16. When the hash table load
// runs over 75%, perform resizing to 2 times larger capacity. Implement the following methods and properties:
// Add(key, value), Find(key)value, Remove( key), Count, Clear(), this[], Keys. Try to make the hash table 
// to support iterating over its elements with foreach.
namespace HashTableAndSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class HashTable<K, T> : IEnumerable<KeyValuePair<K, T>>
    {
        private const int INITIAL_CAPACITY = 16;
        private const double INITIAL_LOAD_FACTOR = 0.75;

        private LinkedList<KeyValuePair<K, T>>[] data;
        private int count;
        private double loadFactor;
        private int threshold;

        public HashTable()
            : this(INITIAL_CAPACITY, INITIAL_LOAD_FACTOR)
        {
        }

        public HashTable(int capacity, double loadFactor)
        {
            this.data = new LinkedList<KeyValuePair<K, T>>[capacity];
            this.loadFactor = loadFactor;
            this.threshold = (int)(capacity * this.loadFactor);
        }

        public int Count
        {
            get { return this.count; }
        }

        public T this[K key]
        {
            get { return this.Get(key); }
            set { this.Set(key, value); }
        }

        public void Add(K key, T value)
        {
            this.Set(key, value);
        }

        public T Find(K key)
        {
            return this.Get(key);
        }

        public void Clear()
        {
            this.data = new LinkedList<KeyValuePair<K, T>>[INITIAL_CAPACITY];
            this.count = 0;
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            foreach (var chain in this.data)
            {
                if (chain != null)
                {
                    foreach (var pair in chain)
                    {
                        yield return pair;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<K, T>>)this).GetEnumerator();
        }

        public T Get(K key)
        {
            LinkedList<KeyValuePair<K, T>> chain = this.FindChain(key, false);
            if (chain != null)
            {
                foreach (KeyValuePair<K, T> entry in chain)
                {
                    if (entry.Key.Equals(key))
                    {
                        return entry.Value;
                    }
                }
            }

            return default(T);
        }

        public T Set(K key, T value)
        {
            if (this.count >= this.threshold)
            {
                this.Expand();
            }

            LinkedList<KeyValuePair<K, T>> chain = this.FindChain(key, true);
            foreach (var chainItem in chain)
            {
                if (chainItem.Key.Equals(key))
                {
                    // Key found -> replace its value with the new value 
                    KeyValuePair<K, T> newEntry = new KeyValuePair<K, T>(key, value);
                    chainItem.ChangeKey(newEntry.Key);
                    chainItem.ChangeValue(newEntry.Value);

                    return chainItem.Value;
                }
            }

            chain.AddLast(new KeyValuePair<K, T>(key, value));
            this.count++;
            return default(T);
        }

        public bool Remove(K key)
        {
            LinkedList<HashTableAndSet.KeyValuePair<K, T>> chain = this.FindChain(key, false);
            if (chain != null)
            {
                foreach (var chainItem in chain)
                {
                    if (chainItem.Key.Equals(key))
                    {
                        // Key found -> remove it 
                        chain.Remove(chainItem);
                        this.count--;
                        return true;
                    }
                }
            }

            return false;
        }

        private LinkedList<KeyValuePair<K, T>> FindChain(K key, bool createIfMissing)
        {
            int index = key.GetHashCode();
            index = index & 0x7FFFFFFF; /* clear the negative bit*/
            index = index % this.data.Length;

            if (this.data[index] == null && createIfMissing)
            {
                this.data[index] = new LinkedList<KeyValuePair<K, T>>();
            }

            return this.data[index];
        }
        
        private void Expand()
        {
            int newCapacity = 2 * this.data.Length;
            LinkedList<KeyValuePair<K, T>>[] oldTable = this.data;
            this.data = new LinkedList<KeyValuePair<K, T>>[newCapacity];
            this.threshold = (int)(newCapacity * this.loadFactor);

            foreach (LinkedList<KeyValuePair<K, T>> oldChain in oldTable)
            {
                if (oldChain != null)
                {
                    foreach (KeyValuePair<K, T> keyValuePair in oldChain)
                    {
                        LinkedList<KeyValuePair<K, T>> chain = this.FindChain(keyValuePair.Key, true);
                        chain.AddLast(keyValuePair);
                    }
                }
            }
        }
    }
}
