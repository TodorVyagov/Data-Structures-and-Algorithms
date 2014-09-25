namespace TrieImplementation
{
    using System;

    public class TrieImplementation
    {
        public static void Main()
        {
            // Works perfectly, but I have not enough time to test it with big text file.

            var trie = new Trie();
            trie.Add("pesho");
            //for (int i = 0; i < 1000000; i++)
            //{
            //    trie.Add("pesh" + (char)(i%26 + (int)'а') );
            //}
            Console.WriteLine(trie.Search("pesho"));
            Console.WriteLine(trie.Search("pesho"));

            trie.Add("zai4e");
            Console.WriteLine(trie.Search("zai4e"));
        }
    }
}
