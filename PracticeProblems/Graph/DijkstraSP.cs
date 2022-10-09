using System.Collections.Generic;

namespace PracticeProblems.Graph
{
    /// <summary>
    /// Non optimized implementation of Dijkstra Algorithms
    /// </summary>
    public class DijkstraSP
    {

        HashSet<int> visited = new HashSet<int>();
        Dictionary<int, int> distTo = new Dictionary<int, int>();

        EdgeWeightedDigraph edgeWeighted;
        public DijkstraSP(EdgeWeightedDigraph graph, int source)
        {
            edgeWeighted = graph;
            int V = edgeWeighted.V();
            edgeWeighted = graph;
            Initialize(source);

            visited.Add(source);

            while (visited.Count <= V)
            {
                int distance = int.MaxValue;
                int winner = 0;

                foreach (int v in visited)
                {
                    foreach (Edge edge in edgeWeighted.Adj(v))
                    {
                        int w = edge.Other(v);
                        if (!visited.Contains(w))
                        {
                            int current = distTo[v] + edge.Cost;
                            if(current < distance)
                            {
                                distance = current;
                                winner = w;
                            }
                        }
                    }
                }

                // Add edge to visited
                visited.Add(winner);
                distTo[winner] = distance;
            }
        }

        private void Initialize(int source)
        {
            foreach (int v in edgeWeighted.Vertices())
            {
                distTo.Add(v, int.MaxValue);
            
            }

            distTo[source] = 0;

        }

        /// <summary>
        /// Provide list of shotest path to vertices from the source
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, int> SP()
        {
            return distTo;

        }
    }
}
