namespace GreedyAndDynamicIlluminated
{
    public class UndirectedGraph
    {
        Dictionary<int, List<Edge>> graph;
        public UndirectedGraph(int V, int E)
        {
            graph = new Dictionary<int, List<Edge>>(V);
        }

        public UndirectedGraph()
        {
            graph = new Dictionary<int, List<Edge>>();
        }

        public void AddEdge(int v, int w, int cost)
        {

            var edge = new Edge(v, w, cost);

            if(!graph.ContainsKey(v))
            {
                graph.Add(v, new List<Edge>() { edge });
            }
            else
            {
                graph[v].Add(edge);
            }

            // Add the other vertex with same edge
            if (!graph.ContainsKey(w))
            {
                graph.Add(w, new List<Edge>() { edge });
            }
            else
            {
                graph[w].Add(edge);
            }

        }

        public void AddVertex(int v)
        {
            if (!graph.ContainsKey(v))
            {
                graph[v] = new List<Edge>();
            }
        }

        public IEnumerable<Edge> Adj(int v)
        {
            List<Edge> adj;
            
            if(graph.TryGetValue(v, out adj))
            {
                return adj;
            }

            return  new List<Edge>(); ;
        }

        public IEnumerable<int> Vertices()
        {
            return graph.Keys;
        }

    }

    public class Edge: IComparable<Edge>
    {
        public Edge(int v, int w, int cost)
        {
            V = v;
            W = w;
            Cost = cost;
        }

        public int V { get; }
        public int W { get; }
        public int Cost { get; }

        public int Other(int v)
        {
            if (v == V) return W;
            else return V;
        }
        public int CompareTo(Edge other)
        {
            return this.Cost - other.Cost;
        }
    }
}
