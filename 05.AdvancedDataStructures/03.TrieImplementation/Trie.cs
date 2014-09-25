namespace TrieImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Trie
    {
        private IList<Node> rootElements;
        private int count;

        public Trie()
        {
            this.rootElements = new List<Node>();
            this.count = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Add(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                throw new ArgumentNullException("Incorrect word.");
            }

            word = word.ToLower();
            Node currentNode = this.rootElements.FirstOrDefault(el => el.Letter == word[0]);
            int currentIndex = 0;
            if (currentNode == null)
            {
                currentNode = new Node(word[currentIndex]);
                this.rootElements.Add(currentNode);
                currentIndex++;
                this.count++;
            }

            while (currentIndex < word.Length)
            {
                // to check for duplicating
                Node childNode = new Node(word[currentIndex]);
                currentNode.AddChild(childNode);

                currentNode = childNode;
                currentIndex++;
            }
        }

        public bool Search(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                throw new ArgumentNullException("Incorrect word.");
            }

            word = word.ToLower();
            int currentIndex = 0;
            Node currentNode = this.rootElements.FirstOrDefault(el => el.Letter == word[currentIndex]);
            while (currentIndex < word.Length && currentNode != null)
            {
                Console.WriteLine(currentNode.Letter);
                if (word.Length - 1 == currentIndex)
                {
                    return true;
                }

                currentIndex++;
                currentNode = currentNode.ChildNodes.FirstOrDefault(el => el.Letter == word[currentIndex]);
            }

            return false;
        }
    }
}
