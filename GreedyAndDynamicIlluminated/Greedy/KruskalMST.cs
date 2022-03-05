namespace GreedyAndDynamicIlluminated.Greedy
{
    public class KruskalMST
    {
        UnionFind uf;
        EdgeWeightedGraph mst;
        Double weight;
        public KruskalMST(EdgeWeightedGraph G)
        {
            int count = G.V();
            uf = new UnionFind(count+1);
            mst = new EdgeWeightedGraph(count+1);
            MST(G);
        }
        
        private void MST(EdgeWeightedGraph G)
        {
            Edge[] edges = G.Edges().ToArray();
            Array.Sort(edges); // sort by the edge cost

            foreach(var e in edges)
            {
                int v = e.V;
                int w = e.Other(v);
                if(uf.Find(v) != uf.Find(w))
                {
                    mst.AddEdge(e);
                    uf.Union(v, w);
                    weight += e.Cost;
                }
            }

        }
      
        /// <summary>
        /// Returns the edges of MST
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Edge> edges()
        {
            return mst.Edges();
            
        }

        /// <summary>
        /// Returns the total weight of the MST
        /// </summary>
        /// <returns></returns>
        public double Weight()
        {
            return weight;
        }
    }
}
