namespace FriendsOfPesho
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            string[] nMH = Console.ReadLine().Split(new[] { ' ' });
            int nodesCount = int.Parse(nMH[0]);
            int connectionsCount = int.Parse(nMH[1]);
            int hospitalsCount = int.Parse(nMH[2]);

            var nodesConnections = new Dictionary<Node, List<Connection>>();
            var indexNodes = new Dictionary<int, Node>();

            for (int i = 1; i <= nodesCount; i++)
            {
                indexNodes.Add(i, new Node(i));
            }

            string[] hospitals = Console.ReadLine().Split(new[] { ' ' });
            for (int i = 0; i < hospitalsCount; i++)
            {
                int currentHospital = int.Parse(hospitals[i]);
                indexNodes[currentHospital].IsHospital = true;
            }

            for (int i = 0; i < connectionsCount; i++)
            {
                string[] connectionRow = Console.ReadLine().Split(new[] { ' ' });
                int startNodeValue = int.Parse(connectionRow[0]);
                int endNodeValue = int.Parse(connectionRow[1]);
                int distance = int.Parse(connectionRow[2]);
                Node startNode = indexNodes[startNodeValue];
                Node endNode = indexNodes[endNodeValue];

                if (!nodesConnections.ContainsKey(startNode))
                {
                    nodesConnections.Add(startNode, new List<Connection>());
                }

                if (!nodesConnections.ContainsKey(endNode))
                {
                    nodesConnections.Add(endNode, new List<Connection>());
                }

                nodesConnections[startNode].Add(new Connection(endNode, distance));
                nodesConnections[endNode].Add(new Connection(startNode, distance));
            }

            long smallestDistance = long.MaxValue;
            for (int i = 0; i < hospitalsCount; i++)
            {
                int currentHospital = int.Parse(hospitals[i]);

                DijkstraAlgorithm(nodesConnections, indexNodes[currentHospital]);
                long currentDistance = 0;

                foreach (var pair in indexNodes)
                {
                    Node node = pair.Value;
                    if (!node.IsHospital)
                    {
                        currentDistance += node.DijkstraDistance;
                    }
                }

                if (smallestDistance > currentDistance)
                {
                    smallestDistance = currentDistance;
                }
            }

            Console.WriteLine(smallestDistance);
        }

        public static void DijkstraAlgorithm(Dictionary<Node, List<Connection>> graph, Node startNode)
        {
            foreach (var item in graph)
            {
                item.Key.DijkstraDistance = long.MaxValue;
            }

            startNode.DijkstraDistance = 0l;
            var queue = new PriorityQueue<Node>();
            queue.Enqueue(startNode);

            while (queue.Count >= 0)
            {
                Node currentNode = queue.Dequeue();

                if (currentNode.DijkstraDistance == long.MaxValue)
                {
                    break;
                }

                foreach (var neighbor in graph[currentNode])
                {
                    long distance = currentNode.DijkstraDistance + neighbor.Distance;

                    if (neighbor.ToNode.DijkstraDistance > distance)
                    {
                        neighbor.ToNode.DijkstraDistance = distance;
                        queue.Enqueue(neighbor.ToNode);
                    }
                }
            }
        }
    }

    public class Node : IComparable
    {
        public Node(int id)
        {
            this.Id = id;
            this.IsHospital = false;
        }

        public int Id { get; private set; }

        public long DijkstraDistance { get; set; }

        public bool IsHospital { get; set; }

        public int CompareTo(object obj)
        {
            return this.DijkstraDistance.CompareTo((obj as Node).DijkstraDistance);
        }
    }

    public class Connection
    {
        public Connection(Node toNode, long distance)
        {
            this.ToNode = toNode;
            this.Distance = distance;
        }

        public Node ToNode { get; set; }

        public long Distance { get; set; }
    }

    public class PriorityQueue<T> where T : IComparable
    {
        private T[] heap;
        private int index;

        public int Count
        {
            get
            {
                return this.index - 1;
            }
        }

        public PriorityQueue()
        {
            this.heap = new T[16];
            this.index = 1;
        }

        public void Enqueue(T element)
        {
            if (this.index >= this.heap.Length - 1)
            {
                IncreaseArray();
            }

            this.heap[this.index] = element;

            int childIndex = this.index;
            int parentIndex = childIndex / 2;
            this.index++;

            while (parentIndex >= 1 && this.heap[childIndex].CompareTo(this.heap[parentIndex]) < 0)
            {
                T swapValue = this.heap[parentIndex];
                this.heap[parentIndex] = this.heap[childIndex];
                this.heap[childIndex] = swapValue;

                childIndex = parentIndex;
                parentIndex = childIndex / 2;
            }
        }

        public T Dequeue()
        {
            T result = this.heap[1];

            this.heap[1] = this.heap[this.Count];
            this.index--;

            int rootIndex = 1;

            int minChild;

            while (true)
            {
                int leftChildIndex = rootIndex * 2;
                int rightChildIndex = rootIndex * 2 + 1;

                if (leftChildIndex > this.index)
                {
                    break;
                }
                else if (rightChildIndex > this.index)
                {
                    minChild = leftChildIndex;
                }
                else
                {
                    if (this.heap[leftChildIndex].CompareTo(this.heap[rightChildIndex]) < 0)
                    {
                        minChild = leftChildIndex;
                    }
                    else
                    {
                        minChild = rightChildIndex;
                    }
                }

                if (this.heap[minChild].CompareTo(this.heap[rootIndex]) < 0)
                {
                    T swapValue = this.heap[rootIndex];
                    this.heap[rootIndex] = this.heap[minChild];
                    this.heap[minChild] = swapValue;

                    rootIndex = minChild;
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public T Peek()
        {
            return this.heap[1];
        }

        private void IncreaseArray()
        {
            T[] copiedHeap = new T[this.heap.Length * 2];

            for (int i = 0; i < this.heap.Length; i++)
            {
                copiedHeap[i] = this.heap[i];
            }

            this.heap = copiedHeap;
        }
    }

}
