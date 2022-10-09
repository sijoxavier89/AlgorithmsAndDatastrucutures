using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PracticeProblems.Graph
{
    /// <summary>
    /// Represents a Directed graph represented by 
    /// Adjacency list
    /// </summary>
    public class Digraph
    {
        private int vertices;
        private int edges;
        private Dictionary<int, List<int>> adj;
        private Dictionary<int, int> indegree;
        /// <summary>
        /// create a Digraph from txt file
        /// </summary>
        /// <param name="filepath"></param>
        public Digraph(string filepath)
        {
            StreamReader  reader = new StreamReader(new FileStream(filepath, FileMode.Open));
            string line = reader.ReadLine();

            adj = new Dictionary<int, List<int>>();
            indegree = new Dictionary<int, int>();

            while (line != null)
            {
               int v = int.Parse(line.Split(' ')[0]);
               int w = int.Parse(line.Split(' ')[1]);

                AddEdge(v, w);

                // goto next line
                line = reader.ReadLine();
            }

            reader.Close();
        }

        public Digraph(int V)
        {
            adj = new Dictionary<int, List<int>>(V);
            indegree = new Dictionary<int, int>();
           
        }
        /// <summary>
        /// return number of vertices in the digraph
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int V()
        {
           return vertices;
        }

        /// <summary>
        /// retrun the number of Edges of Digraph
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int E()
        {
           return edges;
        }

        /// <summary>
        /// Return all vertices
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> Vertices()
        {
            HashSet<int> list = new HashSet<int>();

            foreach(int v in adj.Keys)
            {
                list.Add(v);
                foreach (int w in adj[v])
                {
                    if (!list.Contains(w))
                    {
                        list.Add(w);
                    }
                }
            }

            return list;
        }
        
        public void AddEdge(int v, int w)
        {

            if (adj.TryGetValue(v, out List<int> list))
            {
                adj[v].Add(w);
               
            }
            else
            {
                vertices++;               
                adj[v] = new List<int>() { w };
            }
            edges++;
            
            if(indegree.TryGetValue(w, out int degree))
            {
                indegree[w] = degree + 1;
            }
            else
            {
                indegree.Add(w, 1);
            }
        }

        /// <summary>
        /// Returns the vertices connected to the vertex
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<int> Adj(int v)
        {
            if (adj.TryGetValue(v, out List<int> list))
                return list;
            return new List<int>();
        }

        /// <summary>
        /// returns the number of edges directed to the vertex
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int Indegree(int v)
        {
           return indegree[v];
        }

        /// <summary>
        /// returns the number of edges from the vertex
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int Outdegree(int v)
        {
           return adj[v].Count;
        }

        /// <summary>
        /// returns a digraph with all edges are reversed
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Digraph Reverse()
        {
            if (adj.Count == 0) throw new Exception("graph is empty");

            Digraph reverse = new Digraph(vertices);

            foreach(int v in adj.Keys)
            {
              foreach(int w  in adj[v])
                {
                    reverse.AddEdge(w, v);
                }
            }

            return reverse;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format($"{vertices}- vertices and {edges} Edges" + System.Environment.NewLine));

            foreach(int v in adj.Keys)
            {
                sb.Append(v.ToString()+" -> ");
                foreach(int w in adj[v])
                {
                    sb.Append(w.ToString());
                }

                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
