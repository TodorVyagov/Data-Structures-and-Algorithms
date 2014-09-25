namespace CreateLinkedList
{
    using System;
    using System.Text;

    public class LinkedList<T> where T : IComparable<T>
    {
        public LinkedList()
        { 
        }

        public LinkedList(T value)
        {
            this.FirstItem = new ListItem<T>(value);
        }

        private ListItem<T> FirstItem { get; set; }

        public void Add(T valueToAdd)
        {
            ListItem<T> item = new ListItem<T>(valueToAdd);

            if (item == null)
            {
                throw new ArgumentNullException("Cannot add null value to LinkedList");
            }

            if (this.FirstItem == null)
            {
                this.FirstItem = item;
            }
            else if (this.FirstItem.NextItem == null)
            {
                this.FirstItem.NextItem = item;
            }
            else
            {
                ListItem<T> lastItem = this.FirstItem.NextItem;
                while (lastItem.NextItem != null)
                {
                    lastItem = lastItem.NextItem;
                }

                lastItem.NextItem = item;
            }
        }

        public void Remove(T valueToRemove)
        {
            if (object.Equals(this.FirstItem.Value, valueToRemove))
            {
                this.FirstItem = this.FirstItem.NextItem;
                return;
            }

            ListItem<T> lastItem = this.FirstItem;
            ListItem<T> currentItem = this.FirstItem.NextItem;

            while (currentItem != null)
            {
                if (object.Equals(currentItem.Value, valueToRemove))
                {
                    if (currentItem.NextItem != null)
                    {
                        lastItem.NextItem = currentItem.NextItem;
                    }
                    else
                    {
                        lastItem.NextItem = null;
                    }
                }

                lastItem = currentItem;
                currentItem = currentItem.NextItem;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            ListItem<T> currentItem = this.FirstItem;

            while (currentItem != null)
            {
                result.Append(currentItem + ", ");
                currentItem = currentItem.NextItem;
            }

            if (result.Length > 2)
            {
                result.Length -= 2;
            }
        
            return result.ToString();
        }
    }
}
