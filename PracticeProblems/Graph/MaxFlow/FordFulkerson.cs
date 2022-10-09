using System;
using System.Collections.Generic;

namespace PracticeProblems.Graph.MaxFlow
{
    /// <summary>
    /// implement FordFulkerson algorithm  to find the
    /// max flow of the given network
    /// </summary>
    public class FordFulkerson
    {
        FlowEdge[] _edgeTo;
        bool[] _marked;
        double _flow;
        public FordFulkerson(FlowNetwork G, int s, int t)
        {
            while(HasAugmentingPath(G,s,t))
            {
                double bottle = double.PositiveInfinity;
                for(int v  = t; v != s; v = _edgeTo[v].Other(v))
                {
                    bottle = Math.Min(bottle, _edgeTo[v].ResidualCapacityTo(v));
                }
                
                // augment the path
                for (int v = t; v != s; v = _edgeTo[v].Other(v))
                {
                   _edgeTo[v].AddResidualFlowTo(v, bottle);
                }

                _flow += bottle;
            }

        }

        /// <summary>
        /// check , if there exists a path from s to t in the 
        /// given network G
        /// </summary>
        /// <param name="G"></param>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns> true if exists a augmenting path</returns>
        private bool HasAugmentingPath(FlowNetwork G, int s, int t)
        {

            _edgeTo = new FlowEdge[G.V()];
            _marked = new bool[G.V()];

            Queue<int> queue = new Queue<int>();
            _marked[s] = true;
            queue.Enqueue(s);

            while(queue.Count > 0)
            {
                int v = queue.Dequeue();

                foreach(FlowEdge e in G.Adj(v))
                {
                    int w = e.Other(v);
                    if(!_marked[w] && e.ResidualCapacityTo(w) > 0)
                    {
                        _marked[w] = true;
                        queue.Enqueue(w);
                        _edgeTo[w] = e;
                    }
                }
            }


            return _marked[t];
        }

        /// <summary>
        /// returns maxflow of the network
        /// </summary>
        /// <returns></returns>
        public double Flow()
        {
            return _flow;
        }

        /// <summary>
        /// Check the given vertex is reachable from s
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public bool InCut(int vertex)
        {
            return _marked[vertex];
        }
    }
}
