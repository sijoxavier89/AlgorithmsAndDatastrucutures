namespace PracticeProblems.Graph.MaxFlow
{
    public class FlowEdge
    {
        public int From { get; set; }
        public int To { get; set; }
        public double Capacity { get; set; }
        public double Flow { get; set; }

        public FlowEdge(int v, int w, double capacity)
        {
            From = v;
            To = w;
            Capacity = capacity;
        }

        public int Other(int vertex)
        {
            if (vertex == From) return To;
            else return From;
        }
        /// <summary>
        /// returns remaining capacity that can be filled
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public double ResidualCapacityTo(int vertex)
        {
            if (vertex == From) return Flow; // backward edge
            else return Capacity - Flow; // Forward edge
        }

        /// <summary>
        /// add flow to the edge
        /// </summary>
        /// <param name="vertex"></param>
        public void AddResidualFlowTo(int vertex, double residFlow)
        {
            if (vertex == From)
            {
                Flow -= residFlow;
            }
            else
            {
                Flow += residFlow;
            }
        }

    }
}
