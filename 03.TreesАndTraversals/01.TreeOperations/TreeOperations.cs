/* You are given a tree of N nodes represented as a set of N-1 pairs of nodes (parent node, child node), each in the range (0..N-1). 
Write a program to read the tree and find:
a) the root node
b) all leaf nodes
c) all middle nodes
d) the longest path in the tree
e)* all paths in the tree with given sum S of their nodes
f)* all subtrees with given sum S of their nodes */
namespace TreeOperations
{
    using System;

    public class TreeOperations
    {
        public static void Main()
        {
            // The only condition in this tree is to add only connected nodes! It cannot join different subtrees.
            var tree = new Tree<int>();
            tree.AddPairOfNodes(2, 4);
            tree.AddPairOfNodes(3, 2);
            tree.AddPairOfNodes(3, 5);
            tree.AddPairOfNodes(5, 0);
            tree.AddPairOfNodes(5, 6);
            tree.AddPairOfNodes(5, 1);
            tree.AddPairOfNodes(6, 12);

            Console.WriteLine(tree);
            Console.WriteLine("Root of tree is: " + tree.Root);
            
            var leaves = tree.All(true);
            Console.WriteLine("Leaves of tree are: " + string.Join(", ", leaves));
            
            var middleNodes = tree.All(false);
            Console.WriteLine("Middle nodes are: " + string.Join(", ", middleNodes));
        }
    }
}
