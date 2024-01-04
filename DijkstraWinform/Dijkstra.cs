using System;
using System.Collections.Generic;

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

        public void createEdge(int m, int w, int y)
        {
            adjMatrix[m, w] = y;
        }

        public void DijkstraAlgorithm(int startNode, int endNode, out List<int> shortestPath, out int pathCost)
        {
            int[] distance = new int[vertex];
            int[] pred = new int[vertex];
            bool[] visited = new bool[vertex];
            int count, minDistance, nextNode = 0;

            // Initialize pred[], distance[], and visited[]
            for (int i = 0; i < vertex; i++)
            {
                distance[i] = INFINITY;
                pred[i] = -1;
                visited[i] = false;
            }

            distance[startNode] = 0;
            count = 0;

            while (count < vertex)
            {
                minDistance = INFINITY;
                // nextNode gives the node at minimum distance
                for (int i = 0; i < vertex; i++)
                {
                    if (!visited[i] && distance[i] < minDistance)
                    {
                        minDistance = distance[i];
                        nextNode = i;
                    }
                }

                // Check if a better path exists through nextNode
                visited[nextNode] = true;

                for (int i = 0; i < vertex; i++)
                {
                    if (!visited[i] && adjMatrix[nextNode, i] != 0)
                    {
                        if (distance[nextNode] + adjMatrix[nextNode, i] < distance[i])
                        {
                            distance[i] = distance[nextNode] + adjMatrix[nextNode, i];
                            pred[i] = nextNode;
                        }
                    }
                }

                count++;
            }

            //tinh chi phi cua duong di ngan nhat
            shortestPath = new List<int>();
            int currentNode = endNode;
            while (currentNode != -1)
            {
                shortestPath.Add(currentNode);
                currentNode = pred[currentNode];
            }
            shortestPath.Reverse(); // dao nguoc mang lai de lay tu dau -> cuoi

            pathCost = distance[endNode];
        }
        public void FloydAlgorithm(int startNode, int endNode, out List<int> shortestPath, out int pathCost)
        {
            int n = adjMatrix.GetLength(0);

            // Initialize the result arrays
            int[,] dist = new int[n, n];
            int[,] next = new int[n, n];
            
            // Initialize dist and next arrays with the initial graph information
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dist[i, j] = adjMatrix[i, j];
                    if (adjMatrix[i, j] == 0) next[i, j] = -1;
                    else next[i, j] = j;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (dist[i, j] == 0) dist[i, j] = INFINITY;
                }
            }
            //Floyd-Warshall algorithm
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (dist[i, k] == INFINITY || dist[k, j] == INFINITY) continue;
                        if (dist[i, k] + dist[k, j] < dist[i, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                            next[i, j] = next[i, k];
                        }
                    }
                }
            }

            // Reconstruct the shortest path
            shortestPath = ReconstructPath(startNode, endNode, next);
            pathCost = dist[startNode, endNode];
        }

        private List<int> ReconstructPath(int startNode, int endNode, int[,] next)
        {
            List<int> path = new List<int>();
            path.Add(startNode);
            // an empty array
            if (next[startNode, endNode] == -1)
                return null;
            while (startNode != endNode)
            {
                startNode = next[startNode, endNode];
                path.Add(startNode);
            }
            return path;
        }



        public Dictionary<int, List<Tuple<int, int>>> GetGraph()
        {
            Dictionary<int, List<Tuple<int, int>>> graph = new Dictionary<int, List<Tuple<int, int>>>();

            for (int i = 0; i < vertex; i++)
            {
                List<Tuple<int, int>> edges = new List<Tuple<int, int>>();
                for (int j = 0; j < vertex; j++)
                {
                    if (adjMatrix[i, j] != 0)
                    {
                        edges.Add(new Tuple<int, int>(j, adjMatrix[i, j]));
                    }
                }
                graph.Add(i, edges);
            }

            return graph;
        }

    }
}
