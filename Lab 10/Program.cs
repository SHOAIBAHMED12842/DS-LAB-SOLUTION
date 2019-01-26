using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAdjList
{
class Graph
{
    //----------------------------------------
    // to store the graph using Adjacency List 

        private int numVertices;
        public LinkedList<int>[] adjLists = new LinkedList<int>[50];
        public Graph(int vertices)
        {
            numVertices = vertices;

            for (int i = 0; i < vertices; i++)
                adjLists[i] = new LinkedList<int>();
        }
        public void addEdge(int src, int dest)
        {
            adjLists[src].AddLast(dest);
            adjLists[dest].AddLast(src);
        }
        public int[] getNeighbours(int vertex)
        {
            List<int> neg = new List<int>();

            foreach (int n in adjLists[vertex])
            {
                    neg.Add(n);
            }
            return neg.ToArray();
        }
    public void PrintList()
        {          
            for(int i =0; i<numVertices; i++)
            {              
                 foreach (int n in getNeighbours(i))
                Console.WriteLine("{0} --> {1}",i,n);
            }
        }


    //----------------------------------------
    // to store the graph using Adjacency Matrix 

    //int[,] adjMatrix;
    //int numberOfNodes;

    //public Graph(int numOfNodes)
    //{
    //    this.numberOfNodes = numOfNodes;
    //    adjMatrix = new int[numberOfNodes, numberOfNodes];
    //}

   
    //public void AddEdge(int source, int destination)
    //{
    //    adjMatrix[source, destination] = 1;
    //    adjMatrix[destination, source] = 1;
    //}
    
    //public int[] GetNeighbours(int vertex)
    //{
    //    List<int> neg = new List<int>();
    //    for (int i = 0; i < numberOfNodes; i++)
    //    {
    //        if (adjMatrix[vertex, i] == 1)
    //            neg.Add(i);
    //    }
    //    return neg.ToArray();
    //}

    //public void PrintMatrix()
    //{
    //    for (int i = 0; i < numberOfNodes; i++)
    //    {
    //        for (int j = 0; j < numberOfNodes; j++)
    //        {
    //            Console.Write("{0} ", adjMatrix[i, j]);
    //        }
    //        Console.WriteLine();
    //    }
    //}
    public void DFS(int source)
        {
            Stack<int> stack = new Stack<int>();
            List<int> visited = new List<int>();


            stack.Push(source);
            visited.Add(source);


            while (stack.Count > 0)
            {
                int thisvertex = stack.Pop();
                Console.WriteLine("Visited:{0}", thisvertex);


                int[] neg = getNeighbours(thisvertex);


                foreach (int n in neg)
                {
                    if (!visited.Contains(n))
                    {
                        stack.Push(n);
                        visited.Add(n);
                    }
                }
            }     
        }
        public void BFS(int source)
        {
            Queue<int> stack = new Queue<int>();
            List<int> visited = new List<int>();

            stack.Enqueue(source);
            visited.Add(source);

            while (stack.Count > 0)
            {
                int thisvertex = stack.Dequeue();
                Console.WriteLine("Visited:{0}", thisvertex);

                int[] neg = getNeighbours(thisvertex);

                foreach (int n in neg)
                {
                    if (!visited.Contains(n))
                    {
                        stack.Enqueue(n);
                        visited.Add(n);
                    }
                }
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            TestGraph();
        }
        private static void TestGraph()
        {
            Graph g = new Graph(7);
            g.addEdge(0, 1);
            g.addEdge(1, 2);
            g.addEdge(1, 3);
            g.addEdge(3, 4);
            g.addEdge(3, 5);
            g.addEdge(5, 4);


            Console.WriteLine("Adjacency list of the graph");
            g.PrintList();


            Console.WriteLine("Neighbours of the given vertex");
            int[] neg = g.getNeighbours(1);

            foreach (int n in neg)
                Console.Write("{0} ", n);


            int source = 0;

            Console.WriteLine();

            Console.WriteLine("Performing DFS on {0}", source);
            g.DFS(source);


            Console.WriteLine("Performing BFS on {0}", source);
            g.BFS(source);
        }

        }
    }


