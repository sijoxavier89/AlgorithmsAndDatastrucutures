using System;
using System.Collections.Generic;

namespace PracticeProblems.Graph
{
    /// <summary>
    /// Implements Kosaraju algorithm to find out
    /// strongly connected components.
    /// 1. Reverse the graph and do  a DFS to find out 
    /// the Sink SCC
    /// 2.Do a second DFS in in the reverse order of the 
    /// vertices found out in the first step
    /// 3. Mark the strongly connected components to the group 
    /// </summary>
    public class SCCKosaraju
    {
        private Digraph digraph;
        private Dictionary<int,bool> _marked = new Dictionary<int, bool>();
        private Dictionary<int,int> _scc = new Dictionary<int,int>();
        private int sccNum = 0;
        public SCCKosaraju(string filepath)
        {
           
        }

        public SCCKosaraju(Digraph graph)
        {
            digraph = graph;
            Digraph reverse =  digraph.Reverse();
            Stack<int> topoOrder  = new Stack<int>();

            // initialize
            InitializeMarked(digraph);

            foreach (int v in reverse.Vertices())
            {
                if (!_marked[v])
                    DFS(reverse, v, topoOrder);
            }

            // second DFS for scc
            ResetMarked();
            foreach (int v in topoOrder)
            {
                if (!_marked[v])
                {
                    sccNum++;
                    DfsScc(digraph, v);
                }
            }


        }

        private void InitializeMarked(Digraph digraph)
        {
           
            foreach (int v in digraph.Vertices())
            {
                if (!_marked.ContainsKey(v))
                    _marked.TryAdd(v, false);

            }
        }

        private void ResetMarked()
        {
            foreach(int v in _marked.Keys)
            {
                    _marked[v] = false;

            }
        }


        private void DFS(Digraph g, int v, Stack<int> order)
        {
            _marked[v] = true;
            foreach (int w in g.Adj(v))
            {
               if(!_marked[w])
                    DFS(g, w, order);
            }
            order.Push(v);
           
        }

        private void DfsScc(Digraph g, int v)
        {
            _marked[v] = true;
            AddToScc(v, sccNum);

            foreach(int w in g.Adj(v))
            {
                if(!_marked[w])
                {
                    DfsScc(g, w);
                    
                }
            }
        }

        private void AddToScc(int v, int sccNum)
        {
            if (!_scc.ContainsKey(v))
            {
                _scc.Add(v, sccNum);
            }
            else
            {
                _scc[sccNum] = v;
            }
        }


        public IEnumerable<KeyValuePair<int, int>> SCC()
        {

            return _scc;
        }
    }
}
