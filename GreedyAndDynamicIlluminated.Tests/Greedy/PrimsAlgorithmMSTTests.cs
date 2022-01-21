using GreedyAndDynamicIlluminated.Greedy;
using System;
using System.IO;
using Xunit;

namespace GreedyAndDynamicIlluminated.Tests.Greedy
{
    public class PrimsAlgorithmMSTTests
    {
        [Fact]
        public void TestMST()
        {
            // Arrange
            string[] lines = File.ReadAllLines(@"C:\Users\sijox\source\repos\AlgorithmsAndDatastrucutures\GreedyAndDynamicIlluminated.Tests\Greedy\TestData\15-9MST.txt");

            Assert.True(lines.Length > 0);


            // Act
           
            var graph = CreateGraph(lines);
            var primesalg = new PrimsAlgorithmMST(graph);
            primesalg.GetMST();
            var costOfMST = primesalg.CostOfMST();

            Assert.Equal(14, costOfMST);
        }

        private UndirectedGraph CreateGraph(string[] lines)
        {
            var header = lines[0].Split(" ");
            int V = Convert.ToInt32(header[0]);
            int E = Convert.ToInt32(header[0]);

            UndirectedGraph g = new UndirectedGraph(V, E);

            for(int i = 1; i < lines.Length; i++)
            {
                var line = lines[i].Split(" ");
                g.AddEdge(Convert.ToInt32(line[0]), Convert.ToInt32(line[1]), Convert.ToInt32(line[2]));
               
            }

            return g;
        }

    }
}
