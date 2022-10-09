using System.Collections.Generic;

namespace PracticeProblems.Graph
{
    /// <summary>
    /// Implements Dijkstra Algorithms with Heap 
    /// </summary>
    public class DijkstraSPHeap
    {
        private EdgeWeightedDigraph graph;
        //private Dictionary<int, int> edgeTo;
        private Dictionary<int, int> distTo;
        MinHeap heap;
        public DijkstraSPHeap(EdgeWeightedDigraph g, int source)
        {
            graph = g;

            var V = (HashSet<int>)graph.Vertices();

            distTo = new Dictionary<int, int>(V.Count);
            //edgeTo = new Dictionary<int, int>(V.Count);

            foreach (int v in V)
            {
                if(!distTo.ContainsKey(v))
                distTo.Add(v, int.MaxValue);

            }

            distTo[source] = 0;
            heap = new MinHeap(V.Count);

            heap.Insert(0, source);

            ComputeSP();

        }

        private void ComputeSP()
        {
            

            while (!heap.IsEmpty())
            {
                int minVertex = (int)heap.DeleteMin();
                distTo[minVertex] = heap.KeyOf(minVertex);

                foreach (Edge e in graph.Adj(minVertex))
                {
                    int from = e.V;
                    int to = e.W;

                    if (distTo[to] > distTo[from] + e.Cost)
                    {
                        distTo[to] = distTo[from] + e.Cost;
                        if (heap.Contains(to))
                        {
                            heap.ChangeKey(distTo[to], to);
                        }
                        else heap.Insert(distTo[to], to);
                    }


                }
            }

        }


        /// <summary>
        /// Provide list of shotest path to vertices from the source
        /// </summary>
        /// <returns></returns>
        public Dictionary<int,int> SP()
        {
            return distTo;

        }

    }
}
