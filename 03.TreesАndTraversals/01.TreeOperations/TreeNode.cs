namespace TreeOperations
{
    using System;
    using System.Collections.Generic;

    public class TreeNode<T> where T : IComparable<T>
    {
        public TreeNode(T value)
        {
            this.Value = value;
            this.ChildNodes = new List<TreeNode<T>>();
            this.HasParent = false;
        }

        public T Value { get; set; }

        public bool HasParent { get; set; }

        public IList<TreeNode<T>> ChildNodes { get; set; }

        public void AddChild(TreeNode<T> childToAdd)
        {
            if (childToAdd == null)
            {
                throw new ArgumentNullException("Child cannot be null");
            }

            this.ChildNodes.Add(childToAdd);
        }

        public TreeNode<T> GetChild(int index)
        {
            // check is valid index, and if such child exists at this index
            return this.ChildNodes[index];
        }

        public int CompareTo(object obj)
        {
            TreeNode<T> other = (TreeNode<T>)obj;
            return this.Value.CompareTo(other.Value);
        }
    }
}
