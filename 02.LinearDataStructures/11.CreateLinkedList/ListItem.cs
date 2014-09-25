namespace CreateLinkedList
{
    internal class ListItem<T>
    {
        public ListItem(T value)
        {
            this.Value = value;
            this.NextItem = null;
        }

        public T Value { get; set; }

        public ListItem<T> NextItem { get; set; }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
