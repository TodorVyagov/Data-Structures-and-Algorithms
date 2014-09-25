namespace TreeOperations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Tree<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        public T Root
        {
            get
            {
                return this.root.Value;
            }
        }

        // we give the tree pairs of nodes(parent -> child) and it automatically puts them in its tree structure
        public void AddPairOfNodes(T parent, T child)
        {
            TreeNode<T> parentNode = new TreeNode<T>(parent);
            TreeNode<T> childNode = new TreeNode<T>(child);
                        
            // the tree is empty
            if (this.root == null)
            {
                this.root = parentNode;
                this.root.AddChild(childNode);
                childNode.HasParent = true;
            }
            // tree has some nodes
            else
            {
                TreeNode<T> parentChild = this.AddChildToTree(childNode);
                this.AddParentToTree(parentNode, parentChild);
            }
        }

        public ICollection<T> All(bool areLeaves)
        {
            if (this.root == null)
            {
                return null;
            }

            var result = new HashSet<T>();
            Queue<TreeNode<T>> treeNodes = new Queue<TreeNode<T>>();
            treeNodes.Enqueue(this.root);

            while (treeNodes.Count > 0)
            {
                TreeNode<T> currentNode = treeNodes.Dequeue();
                if (areLeaves && currentNode.ChildNodes.Count == 0)
                {
                    result.Add(currentNode.Value);
                }
                else if (!areLeaves && currentNode.ChildNodes.Count != 0 && currentNode.HasParent)
                {
                    result.Add(currentNode.Value);
                }

                foreach (var child in currentNode.ChildNodes)
                {
                    treeNodes.Enqueue(child);
                }
            }

            return result;
        }

        public override string ToString()
        {
            return this.PrintDfs(this.root, string.Empty);
        }

        private void AddParentToTree(TreeNode<T> parentNode, TreeNode<T> parentChild)
        {
            TreeNode<T> existingParent = this.SearchBfs(this.root, parentNode);
            if (existingParent == null)
            {
                if (this.root.CompareTo(parentChild) == 0)
                {
                    parentNode.AddChild(this.root);
                    this.root.HasParent = true;
                    this.root = parentNode;
                }
                else
                {
                    throw new ArgumentException("You are trying to make another tree, not connected to current root");
                }
            }
            else
            {
                parentChild.HasParent = true;
                existingParent.AddChild(parentChild);
            }
        }

        private TreeNode<T> AddChildToTree(TreeNode<T> childNode)
        {
            TreeNode<T> existingChild = this.SearchBfs(this.root, childNode);
            if (existingChild == null)
            {
                // everuthing is OK(this child do not exist in the tree) so we can add it to given parent
                return childNode;
            }
            else
            {
                if (existingChild.HasParent)
                {
                    throw new ArgumentException("Node cannot have more than one parents");
                }

                return existingChild;
            }
        }

        private TreeNode<T> SearchBfs(TreeNode<T> startNode, TreeNode<T> searchNode)
        {
            // start from root node and add it to Queue, 
            // Dequeue next, Check if it is Equal to searching value and Add all its children to the queue
            if (startNode == null)
            {
                return null;
            }

            Queue<TreeNode<T>> treeNodes = new Queue<TreeNode<T>>();
            treeNodes.Enqueue(startNode);

            while (treeNodes.Count > 0)
            {
                TreeNode<T> currentNode = treeNodes.Dequeue();
                if (currentNode.CompareTo(searchNode) == 0)
                {
                    return currentNode;
                }

                foreach (var child in currentNode.ChildNodes)
                {
                    treeNodes.Enqueue(child);
                }
            }

            // node not found
            return null;
        }

        private string PrintDfs(TreeNode<T> root, string spaces)
        {
            if (this.root == null)
            {
                return string.Empty;
            }

            var result = new StringBuilder();

            result.AppendLine(spaces + root.Value);
            TreeNode<T> child = null;

            for (int i = 0; i < root.ChildNodes.Count; i++)
            {
                child = root.GetChild(i);
                result.AppendLine(this.PrintDfs(child, spaces + "   "));
            }

            return result.ToString();
        }
    }
}
