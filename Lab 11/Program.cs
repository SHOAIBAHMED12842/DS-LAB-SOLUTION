using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstras
{

    public class Dijkstras
    {
        public int INFINITY = 9999;
       
        int[,] CostMatrix;
        public int numberOfNodes;
        public int[] distance;
        //pred[] stores the predecessor of each node
        //count gives the number of nodes seen so far
        public int[] pred;
        public int[] visited;
        public int count;
        public int mindistance=0;
        public int nextnode=0;

        public Dijkstras(int vertex)
        {
            numberOfNodes = vertex;
            CostMatrix = new int[numberOfNodes, numberOfNodes];
            distance = new int[numberOfNodes];
            pred = new int[numberOfNodes];
            visited = new int[numberOfNodes];
        }
        public void AddEdge(int source, int destination, int cost)
        {
            CostMatrix[source, destination] = cost;
            CostMatrix[destination, source] = cost;
            
            for (int i = 0; i < numberOfNodes; i++)
                for (int j = 0; j < numberOfNodes; j++)
                    if (CostMatrix[i, j] == 0)
                        CostMatrix[i,j] = INFINITY;
                   
        }
        public void PrintMatrix()
        {
            for (int i = 0; i < numberOfNodes; i++)
            {
                for (int j = 0; j < numberOfNodes; j++)
                {
                    Console.Write("{0} ", CostMatrix[i, j]);
                }
                Console.WriteLine();
            }
        }
        public void dijkstra(int startnode)
        {
            int i, j;
            //initialize pred[],distance[] and visited[]
            for (i = 0; i < numberOfNodes; i++)
            {
                distance[i] = CostMatrix[startnode, i];
                pred[i] = startnode;               
            }

            distance[startnode] = 0;
            visited[startnode] = 1;
            count = 1;

            while (count < numberOfNodes - 1)
            {
                mindistance = INFINITY;

                //nextnode gives the node at minimum distance
                for (i = 0; i < numberOfNodes; i++)
                {
                    if (distance[i] < mindistance && visited[i] == 0)
                    {
                        mindistance = distance[i];
                        nextnode = i;
                    }
                }

                //check if a better path exists through nextnode
                visited[nextnode] = 1;
                for (i = 0; i < numberOfNodes; i++)
                {
                    if (visited[i] == 0)
                    {
                        if (mindistance + CostMatrix[nextnode, i] < distance[i])
                        {
                            distance[i] = mindistance + CostMatrix[nextnode, i];
                            pred[i] = nextnode;
                        }
                    }
                }
                count++;
            }

            ////print the path and distance of each node
            for (i = 0; i < numberOfNodes; i++)
            {
                if (i != startnode)
                {
                    Console.Write("\nDistance of node{0}={1}", i, distance[i]);
                    Console.Write("\nPath={0}", i);

                    j = i;
                    do
                    {
                        j = pred[j];
                        Console.Write("<-{0}", j);
                    } while (j != startnode);
                }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Dijkstras g = new Dijkstras(5);
                g.AddEdge(0, 1, 10);
                g.AddEdge(1, 2, 50);
                g.AddEdge(0, 3, 30);
                g.AddEdge(3, 2, 20);
                g.AddEdge(0, 4, 100);
                g.AddEdge(4, 2, 10);
                g.AddEdge(4, 3, 60);

                Console.WriteLine("Cost Matrix of the graph");
                g.PrintMatrix();


                Console.Write("\nEnter the starting node:");
                int source = Convert.ToInt32(Console.ReadLine());
                g.dijkstra(source);


            }
        }
    }
}

