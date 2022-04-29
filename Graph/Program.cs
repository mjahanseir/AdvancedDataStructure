using System;
using System.Collections;

namespace MyFirstGraph
{
    class Program
    {
        static void Main(string[] args)
        {

            Graph myGraph = new Graph();
            /*
                        myGraph.addVertex("A");
                        myGraph.addVertex("B");
                        myGraph.addVertex("C");
                        myGraph.addVertex("D");
                        myGraph.addVertex("E");
                        myGraph.addVertex("F");
                        myGraph.addVertex("G");
                        myGraph.addVertex("H");
                        myGraph.addVertex("I");
                        myGraph.addVertex("J");
                        myGraph.addVertex("K");
                        myGraph.addVertex("L");
                        myGraph.addVertex("M");

                        myGraph.addEdge(0, 1, 1);
                        myGraph.addEdge(1, 2, 1);
                        myGraph.addEdge(2, 3, 1);
                        myGraph.addEdge(0, 4, 1);
                        myGraph.addEdge(4, 5, 1);
                        myGraph.addEdge(5, 6, 1);
                        myGraph.addEdge(0, 7, 1);
                        myGraph.addEdge(7, 8, 1);
                        myGraph.addEdge(8, 9, 1);
                        myGraph.addEdge(0, 10, 1);
                        myGraph.addEdge(10, 11, 1);
                        myGraph.addEdge(11, 12, 1);

                        myGraph.DepthFirstSearch();

                        Console.WriteLine();
                        myGraph.BreadthFirstSearch();
            */
            myGraph.addVertex("0");
            myGraph.addVertex("1");
            myGraph.addVertex("2");
            myGraph.addVertex("3");
            myGraph.addVertex("4");
            myGraph.addVertex("5");
            myGraph.addVertex("6");
            myGraph.addVertex("7");
            myGraph.addVertex("8");
          

            myGraph.addEdge(0, 1, 4);
            myGraph.addEdge(0,7,8);
            myGraph.addEdge(1,2,8);
            myGraph.addEdge(1,7,11);
            myGraph.addEdge(2,3,7);
            myGraph.addEdge(2,5,4);
            myGraph.addEdge(2,8,2);
            myGraph.addEdge(3,4,9);
            myGraph.addEdge(3,5,14);
            myGraph.addEdge(4,5,10);
            myGraph.addEdge(5,6,2);
            myGraph.addEdge(6,7,1);
            myGraph.addEdge(6,8,6);
            myGraph.addEdge(7,8,7);

            myGraph.DijekstraSPF(0);
        }
    }
    public class Vertex
    {
        public string label;
        public bool wasVisited;

        public Vertex(string label)
        {
            this.label = label;
            wasVisited = false;
        }
    }

    public class Graph
    {
        public const int NUM_VERTICES = 20;
        private Vertex[] vertcies;
        private int[,] adjMatrix;
        private int numVerts;
        private int numEdges;
        private Stack gStack;
        private Queue gQueue;

        public Graph()
        {
            vertcies = new Vertex[NUM_VERTICES];
            adjMatrix = new int[NUM_VERTICES, NUM_VERTICES];
            numVerts = 0;

            for (int j = 0; j < NUM_VERTICES; j++)
                for (int k = 0; k < NUM_VERTICES; k++)
                    adjMatrix[j, k] = 0;
            gStack = new Stack();
            gQueue = new Queue();

        }

        public void addVertex(string label)
        {
            vertcies[numVerts] = new Vertex(label);
            numVerts++;
        }

        public void addEdge(int start, int end, int weight)
        {
            adjMatrix[start, end] = weight;
            adjMatrix[end, start] = weight;
        }

        public void showVertex(int v)
        {
            Console.Write(vertcies[v].label + "  ");
        }
        public int getAdjUnvisitedVertex(int v)
        {
            for (int j = 0; j < NUM_VERTICES; j++)
                if ((adjMatrix[v, j] == 1) && (vertcies[j].wasVisited == false))
                    return j;
            return -1;
        }
        public void DepthFirstSearch()
        {
            vertcies[0].wasVisited = true;
            showVertex(0);
            gStack.Push(0);
            ///falg output push

            int v;
            while (gStack.Count > 0)
            {
                v = getAdjUnvisitedVertex((int)gStack.Peek());
                if (v == -1)
                {
                    gStack.Pop();
                }
                else
                {
                    vertcies[v].wasVisited = true;
                    showVertex(v);
                    gStack.Push(v);
                }
            }
            for (int i = 0; i < NUM_VERTICES; i++)
                if (vertcies[i] != null)
                    vertcies[i].wasVisited = false;


        }
        public void BreadthFirstSearch()
        {
            vertcies[0].wasVisited = true;
            showVertex(0);
            gQueue.Enqueue(0);


            int v1, v2;
            while (gQueue.Count > 0)
            {
                v1 = (int)gQueue.Dequeue();
                v2 = getAdjUnvisitedVertex(v1);
                while (v2 != -1)
                {
                    vertcies[v2].wasVisited = true;
                    showVertex(v2);
                    gQueue.Enqueue(v2);
                    v2 = getAdjUnvisitedVertex(v1);
                }
            }
            for (int i = 0; i < NUM_VERTICES; i++)
                if (vertcies[i] != null)
                    vertcies[i].wasVisited = false;

        }





        /////////////////////////////////////////////////////////////////////////////////////////////////////
        public int MinDistance(int[] distance, bool[] shortestPathSet)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for(int v=0; v< numVerts; ++v)
            {
                if(shortestPathSet[v] == false && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }

        private void PrintDijekstra(int[] distance)
        {
            Console.WriteLine("Vertex         Distance from source");
            for (int i = 0; i < numVerts; ++i)
            {
                Console.WriteLine("{0}  \t    {1}", i, distance[i]);
            }
        }

        public void DijekstraSPF(int source)
        {
            int[] distance = new int[numVerts];
            int[] parent = new int[numVerts];
            bool[] shortestPathSet = new bool[numVerts];

            for (int i = 0; i < numVerts; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPathSet[i] = false;
                parent[i] = int.MaxValue;
            }

            distance[source] = 0;
            parent[source] = -1;

            for (int counter = 0; counter < numVerts-1; ++counter)
            {
                int u = MinDistance(distance, shortestPathSet);
                shortestPathSet[u] = true;

                for (int v = 0; v < numVerts; ++v)
                {
                    // if we have a vertex v that we need to consider and we have a shorter
                    // current path than wjhat's at distance[v] , update distance[]
                    if (!shortestPathSet[v] &&
                        Convert.ToBoolean(adjMatrix[u, v]) &&
                        distance[u] != int.MaxValue &&
                        distance[u] + adjMatrix[u, v] < distance[v])
                    {
                        distance[v] = distance[u] + adjMatrix[u, v];
                        parent[v] = u;
                    }
                }
            }

            PrintDijekstra(distance);

        }
    }
}
