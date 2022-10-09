using System.Collections.Generic;

namespace PracticeProblems.Graph
{
    public class TopoSort
    {
        private Dictionary<int, bool> _marked = new Dictionary<int, bool>();
        public IEnumerable<int> Get(Digraph digraph)
        {
            Stack<int> stack = new Stack<int>();
            Initialize(digraph);
            if (HasCycle(digraph)) return null;

            foreach (int v in digraph.Vertices())
            {
                if(_marked.ContainsKey(v) && !_marked[v])
                {
                   Dfs(v, digraph, stack);
                }
            }

            return stack;
        }

        private void Initialize(Digraph digraph)
        {
            foreach (int v in digraph.Vertices())
            {
                if (!_marked.ContainsKey(v))
                    _marked.TryAdd(v, false);
             
            }
        }
        private void Dfs(int v, Digraph digraph, Stack<int> postorder)
        {
            _marked[v] = true;

            foreach(int w in digraph.Adj(v))
            {
                if(_marked.ContainsKey(w) && !_marked[w])
                Dfs(w, digraph, postorder);
                
            }
            // push to postorder
            postorder.Push(v);

        }

        /// <summary>
        /// check for a directed cycle in the graph
        /// </summary>
        /// <param name="digraph"></param>
        /// <returns></returns>
        private bool HasCycle(Digraph digraph)
        {
            var dc = new DirectedCycle(digraph);
            return dc.HasCycle();
        }
    }
}
