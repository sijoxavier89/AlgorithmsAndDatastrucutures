using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class GraphSx
    {
        Dictionary<int, List<int>> graph;
        public GraphSx(int V)
        {
            graph = new Dictionary<int, List<int>>(V);
        }

        public GraphSx()
        {
            graph = new Dictionary<int, List<int>>();
        }

        public void AddEdge(int v, int w)
        {

           

            if (!graph.ContainsKey(v))
            {
                graph.Add(v, new List<int>() { w });
            }
            else
            {
                graph[v].Add(w);
            }

            // Add the other vertex with same edge
            if (!graph.ContainsKey(w))
            {
                graph.Add(w, new List<int>() { v });
            }
            else
            {
                graph[w].Add(v);
            }

        }

        public void AddVertex(int v)
        {
            if (!graph.ContainsKey(v))
            {
                graph[v] = new List<int>();
            }
        }

        public IEnumerable<int> Adj(int v)
        {
            
            List<int> adj;
            if (graph.TryGetValue(v, out adj))
            {
                return adj;
            }

            return new List<int>(); ;
        }

        public IEnumerable<int> Vertices()
        {
            return graph.Keys;
        }

    }

}
