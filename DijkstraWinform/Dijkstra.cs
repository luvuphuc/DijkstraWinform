using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraWinform
{
    public class Dijkstra
    {
        public int[,] adjMatrix;
        public int[] visited;
        public int vertex;
        private const int INFINITY = 9999;
        public const int MAX = 10;
        public Dijkstra(int v)
        {
            vertex = v;
            adjMatrix = new int[v, v];
            visited = new int[v];
        }
        public void createEdge(int m,int w, int y)
        {
            adjMatrix[m,w] = y; 
        }
        
        public static void DijkstraAlgorithm(int[,] G, int n, int startNode, int endNode)
        {
            int[,] cost = new int[MAX, MAX];
            int[] distance = new int[MAX];
            int[] pred = new int[MAX];
            bool[] visited = new bool[MAX];
            int count, minDistance, nextNode = 0;

            // Create the cost matrix
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (G[i, j] == 0)
                        cost[i, j] = INFINITY;
                    else
                        cost[i, j] = G[i, j];
                }
            }

            // Initialize pred[], distance[], and visited[]
            for (int i = 0; i < n; i++)
            {
                distance[i] = cost[startNode, i];
                pred[i] = startNode;
                visited[i] = false;
            }

            distance[startNode] = 0;
            visited[startNode] = true;
            count = 1;

            while (count < n && !visited[endNode])
            {
                minDistance = INFINITY;

                // nextNode gives the node at minimum distance
                for (int i = 0; i < n; i++)
                {
                    if (distance[i] < minDistance && !visited[i])
                    {
                        minDistance = distance[i];
                        nextNode = i;
                    }
                }

                // Check if a better path exists through nextNode
                visited[nextNode] = true;

                for (int i = 0; i < n; i++)
                {
                    if (!visited[i])
                    {
                        if (minDistance + cost[nextNode, i] < distance[i])
                        {
                            distance[i] = minDistance + cost[nextNode, i];
                            pred[i] = nextNode;
                        }
                    }
                }

                count++;
            }

            // Print the path and distance from startNode to endNode
            if (visited[endNode])
            {
                Console.WriteLine($"\nDistance from node {startNode} to node {endNode} = {distance[endNode]}");
                Console.Write($"Path = {startNode}");

                // Store the path in an array for reversal
                int[] path = new int[MAX];
                int index = 0;
                int j = endNode;
                do
                {
                    path[index++] = j;
                    j = pred[j];
                } while (j != startNode);

                // Print the reversed path
                for (int k = index - 1; k >= 0; k--)
                {
                    Console.Write($"->{path[k]}");
                }
            }
            else
            {
                Console.WriteLine($"\nNo valid path from node {startNode} to node {endNode}");
            }
        }
    }
}
