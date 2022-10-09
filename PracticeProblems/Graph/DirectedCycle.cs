using System.Collections.Generic;
namespace PracticeProblems.Graph
{
    public class DirectedCycle
    {
        private Dictionary<int,bool> _marked = new Dictionary<int, bool>();
        private Dictionary<int, bool> _instack = new Dictionary<int, bool>();
        private Dictionary<int,int> _edgeTo = new Dictionary<int,int>();
        private Stack<int> _cycle;
        public DirectedCycle(Digraph digraph)
        {

            Initialize(digraph);

            foreach (int v in digraph.Vertices())
            {
                if (_marked.ContainsKey(v) && !_marked[v])
                {
                    Dfs(v, digraph);
                }
            }

        }
        private void Initialize(Digraph digraph)
        {
            foreach (int v in digraph.Vertices())
            {
                if (!_marked.ContainsKey(v))
                {
                    _marked.TryAdd(v, false);
                   
                }

                if(!_instack.ContainsKey(v))
                {
                    _instack.TryAdd(v, false);
                }
            }
        }
        private void Dfs(int v, Digraph digraph)
        {
            _marked[v] = true;
            _instack[v] = true;
            foreach (int w in digraph.Adj(v))
            {

                if (_cycle != null)
                {
                    return;
                }
                else if (!_marked[w])
                {
                    _edgeTo[w] = v;
                    Dfs(w, digraph);
                }
                else if(_instack[w])
                {
                    _cycle = new Stack<int>();
                    _cycle.Push(w);
                    for(int x = v; x != w; x = _edgeTo[x])
                    {
                        _cycle.Push(x);
                    }
                    _cycle.Push(v);
                }

            }
            
            _instack[v] = false;

        }

        public bool HasCycle()
        {
            return _cycle != null;
        }

        public IEnumerable<int> Cycle()
        {
            return _cycle;
        }
    }
}
