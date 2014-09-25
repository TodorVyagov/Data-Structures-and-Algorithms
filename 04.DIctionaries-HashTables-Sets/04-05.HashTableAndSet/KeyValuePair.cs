namespace HashTableAndSet
{
    public struct KeyValuePair<K, T>
    {
        public KeyValuePair(K key, T value)
            : this()
        {
            this.Key = key;
            this.Value = value;
        }

        public K Key { get; set; }

        public T Value { get; set; }

        public void ChangeKey(K key)
        {
            this.Key = key;
        }

        public void ChangeValue(T value)
        {
            this.Value = value;
        }
    }
}
