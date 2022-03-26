namespace GreedyAndDynamicIlluminated.Greedy
{
    public class Edge : IComparable<Edge>
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
