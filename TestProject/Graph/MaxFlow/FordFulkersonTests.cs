using PracticeProblems.Graph.MaxFlow;
using System;
using System.IO;
using Xunit;

namespace PracticeProblems.Tests.Graph.MaxFlow
{
    public class FordFulkersonTests
    {
        [Fact]
        public void TestFlow()
        {
            string path = @"C:\Users\sijox\source\repos\AlgorithmsAndDatastrucutures\TestProject\Graph\TestData\maxflow.txt";
            FlowNetwork G = CreateNw(path);

            FordFulkerson fordFulkerson = new FordFulkerson(G, 0, 7);
            Assert.NotNull(fordFulkerson);
            Assert.Equal(28, fordFulkerson.Flow());

        }

        private FlowNetwork CreateNw(string filepath)
        {
            
            StreamReader reader = new StreamReader(new FileStream(filepath, FileMode.Open));
         
            int V = Convert.ToInt32(reader.ReadLine().Trim());
            int E = Convert.ToInt32(reader.ReadLine().Trim());
            FlowNetwork G = new FlowNetwork(V);

            string line = reader.ReadLine();
            while (line != null)
            {
               var entries = line.Split(' ');
               int from = Convert.ToInt32(entries[0]);
               int to = Convert.ToInt32(entries[1]);
               int capacity = Convert.ToInt32(entries[2]);

                FlowEdge e = new FlowEdge(from, to, capacity);

                G.AddEdge(e);
                // goto next line
                line = reader.ReadLine();
            }

            reader.Close();

            Assert.Equal(E, G.E());
            return G;
        }
    }
}
