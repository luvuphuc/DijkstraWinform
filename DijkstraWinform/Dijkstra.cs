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

            // Construct the shortest path and calculate the cost
            shortestPath = new List<int>();
            int currentNode = endNode;
            while (currentNode != -1)
            {
                shortestPath.Add(currentNode);
                currentNode = pred[currentNode];
            }
            shortestPath.Reverse(); // Reverse the path to get it from start to end

            pathCost = distance[endNode];
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
