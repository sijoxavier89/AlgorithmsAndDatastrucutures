namespace GreedyAndDynamicIlluminated.Greedy
{
    public class EdgeWeightedGraph
    {
        private int countV;
        private int countE;
        private List<Edge>[] adj;

        public EdgeWeightedGraph(int v)
        {
            adj = new List<Edge>[v+1]; // 1 based index for test graph
            for(int i= 0; i<= v; i++)
            {
                adj[i] = new List<Edge>();
            }
        }
        public EdgeWeightedGraph(string[] lines)
        {
            var header = lines[0].Split(" ");
            int v = Convert.ToInt32(header[0]);
            this.countV = v;
            int e = Convert.ToInt32(header[1]);
            adj = new List<Edge>[v+1];
            // initialize
            for (int i = 0; i <= v; i++)
            {
                adj[i] = new List<Edge>();
            }
            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i].Split(" ");
                var edge = new Edge(Convert.ToInt32(line[0]), Convert.ToInt32(line[1]), Convert.ToInt32(line[2]));
                AddEdge(edge);

            }
        }

        public int V()
        {
            return countV;
        }

        public int E()
        {
            return countE;
        }

        public void AddEdge(Edge e)
        {
            int v = e.V;
            int w = e.Other(v);
            ValidateVertex(v);
            ValidateVertex(w);

            adj[v].Add(e);
            adj[w].Add(e);
            countE++;
        }
         
        
        /// <summary>
        /// Returns all the edges in the graph
        /// </summary>
        /// <returns>all the edges in the graph as IEnumerable</returns>
        public IEnumerable<Edge> Edges()
        {
            List<Edge> edge = new List<Edge>();

            for(int v = 0; v < countV; v++)
            {
                foreach(Edge e in adj[v])
                {
                    int selfLoop = 0;
                    if(e.Other(v) > v) // to avoid self loop
                    {
                        edge.Add(e);
                    }
                    else if(e.Other(v) == v) // add only one copy of the self loop, self loop is consecutive
                    {
                        if(selfLoop % 2 == 0)
                        edge.Add(e);
                        selfLoop++;
                    }
                }
            }

            return edge;
        }
        private void ValidateVertex(int v)
        {
            if (v < 0 && v >= countV) throw new ArgumentException();
        }
    }

   
}
