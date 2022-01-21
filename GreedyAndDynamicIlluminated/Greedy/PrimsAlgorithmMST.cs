namespace GreedyAndDynamicIlluminated.Greedy
{
    public class PrimsAlgorithmMST
    {
        UndirectedGraph graph;
        PriorityQueue<Edge, int> PriorityQueue;
        Dictionary<int, bool> marked;
        UndirectedGraph? MST;
        private int Cost;
        public PrimsAlgorithmMST(UndirectedGraph graph)
        {
            this.graph = graph;
            this.PriorityQueue = new PriorityQueue<Edge, int>();
            MST = new UndirectedGraph();
            marked = new Dictionary<int, bool>();
            CreateMST();
           
        }
        public UndirectedGraph GetMST()
        {
            return MST;
        }

        private void CreateMST()
        {
            var source = graph.Vertices().FirstOrDefault();
            marked[source] = true;

            AddToQueue(source);

            while (PriorityQueue.Count > 0)
            {
                var current  = PriorityQueue.Dequeue();
                // since it is undirected we need to check both end for
                // making sure it is already visited or not
                if(!marked.TryGetValue(current.W, out _) | !marked.TryGetValue(current.V, out _))
                {
                    MST.AddEdge(current.V, current.W, current.Cost);

                    if (!marked.TryGetValue(current.W, out _))
                        AddToQueue(current.W);
                    else
                        AddToQueue(current.V);

                    marked[current.W] = true;
                    marked[current.V] = true;
                    Cost += current.Cost;

                    
                   
                }

                
            }
        }

        private void AddToQueue(int source)
        {
            foreach (var edge in graph.Adj(source))
            {

                if (!marked.TryGetValue(edge.W, out _) | !marked.TryGetValue(edge.V, out _))
                {
                    PriorityQueue.Enqueue(edge, edge.Cost);
                }
            }
        }
        public int CostOfMST()
        {
            return Cost; 
        }
    }
}
