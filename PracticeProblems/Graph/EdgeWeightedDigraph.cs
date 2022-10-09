using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PracticeProblems.Graph
{
    public class EdgeWeightedDigraph
    {
      
        private int edges;
        private Dictionary<int, List<Edge>> adj;
        private Dictionary<int, int> indegree;
        public EdgeWeightedDigraph(string filepath)
        {
            StreamReader reader = new StreamReader(new FileStream(filepath, FileMode.Open));
            string line = reader.ReadLine();

            adj = new Dictionary<int, List<Edge>>();
            indegree = new Dictionary<int, int>();

            while (line != null)
            {
                var entries = line.Split('\t');

                int v = int.Parse(entries[0]);

                for (int i = 1; i < entries.Length; i++)
                {
                    var entry = entries[i].Split(',');
                    int w = int.Parse(entry[0]);
                    int cost = int.Parse(entry[1]);
                    AddEdge(v, w, cost);
                }

                // goto next line
                line = reader.ReadLine();
            }

            reader.Close();

        }
        public int V()
        {
            return ((HashSet<int>) Vertices()).Count;
        }

        public int E()
        {
            return edges;
        }

        public IEnumerable<int> Vertices()
        {
            HashSet<int> list = new HashSet<int>();

            foreach (int v in adj.Keys)
            {
                list.Add(v);
                foreach (Edge e in adj[v])
                {
                    int w = e.Other(v);
                    if (!list.Contains(w))
                    {
                        list.Add(w);
                    }
                }
            }

            return list;
        }

        public void AddEdge(int v, int w, int cost)
        {
            var edge = new Edge(v, w, cost);
            if(adj.ContainsKey(v))
            {
                adj[v].Add(edge);
            }
            else
            {
                adj.Add(v, new List<Edge>() { edge });
            }
            edges++;
            
            if (indegree.ContainsKey(w))
                indegree[w]++;
            else
                indegree.Add(w, 1);
        }

        public IEnumerable<Edge> Adj(int v)
        {
            return adj[v];
        }
        public int Indegree(int v)
        {
           return indegree[v];
        }

        public int Outdegree(int v)
        {
           return adj[v].Count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format($"{V()}- vertices and {edges} Edges" + System.Environment.NewLine));

            foreach (int v in adj.Keys)
            {
                sb.Append(v.ToString() + " -> ");
                foreach (Edge e in adj[v])
                {
                    int w  = e.Other(v);
                    sb.Append(w.ToString());
                }

                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
     }
}
