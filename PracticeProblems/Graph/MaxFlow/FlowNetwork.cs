using System.Collections.Generic;

namespace PracticeProblems.Graph.MaxFlow
{
    /// <summary>
    /// Represents a flow network where the vertices
    /// are represented by the integers 
    /// </summary>
    public class FlowNetwork
    {
        private  Dictionary<int, List<FlowEdge>> _adjList;
        private HashSet<FlowEdge> _allEdges;
        private int vCount;
        public FlowNetwork(int vertices)
        {
            vCount = vertices;
            _adjList = new Dictionary<int, List<FlowEdge>>(vertices);
            _allEdges = new HashSet<FlowEdge>();
        }

        /// <summary>
        /// number of vertices
        /// </summary>
        /// <returns></returns>
        public int V()
        {
            return _adjList.Count;
        }

        /// <summary>
        /// number of edges
        /// </summary>
        /// <returns></returns>
        public int E()
        {
            return _allEdges.Count;
        }

        /// <summary>
        /// Add edge to both vertices
        /// </summary>
        /// <param name="e"></param>
        public void AddEdge(FlowEdge e)
        {
            int v = e.From;
            int w = e.To;

            AddToList(v, e);
            AddToList(w, e);

            _allEdges.Add(e);
        }

        private void AddToList(int key, FlowEdge value)
        {
            if(_adjList.ContainsKey(key))
            {
                _adjList[key].Add(value);
            }
            else
            {
                _adjList.Add(key, new List<FlowEdge> { value });
            }
        }

        /// <summary>
        /// returns all edges in the vertex 
        /// </summary>
        /// <param name="v"></param>
        /// <returns>List of edges</returns>
        public IEnumerable<FlowEdge> Adj(int v)
        {
            ValidateVertex(v);
           return _adjList[v];
        }

        /// <summary>
        /// returns all edges in the flow network
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FlowEdge> Edges()
        {
            return _allEdges;
        }

        private void ValidateVertex(int v)
        {
            if (v < 0 || v >= vCount) throw new System.ArgumentOutOfRangeException();
        }

    }
}
