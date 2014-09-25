namespace TrieImplementation
{
    using System;
    using System.Collections.Generic;

    public class Node
    {
        public Node(char letter)
        {
            this.ChildNodes = new List<Node>();
            this.Letter = letter;
            this.Count = 1;
        }

        public char Letter { get; private set; }

        public int Count { get; private set; }

        public IList<Node> ChildNodes { get; private set; }

        public void AddChild(Node childNode)
        {
            this.Count++;
            this.ChildNodes.Add(childNode);
        }
    }
}
