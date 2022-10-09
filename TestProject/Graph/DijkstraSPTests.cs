using PracticeProblems.Graph;
using System.Collections.Generic;
using Xunit;

namespace PracticeProblems.Tests.Graph
{
    public class DijkstraSPTests
    {

        [Fact]
        public void TestSP()
        {
            string filepath = @"C:\Users\sijox\source\repos\AlgorithmsAndDatastrucutures\TestProject\Graph\TestData\problem9.8test.txt";
            EdgeWeightedDigraph graph = new EdgeWeightedDigraph(filepath);
            int source = 1;

            DijkstraSP sp = new DijkstraSP(graph, source);

            Dictionary<int, int> distTo = sp.SP();

            Assert.Equal(0, distTo[1]); 
            Assert.Equal(1, distTo[2]); 
            Assert.Equal(2, distTo[3]); 
            Assert.Equal(3, distTo[4]); 
            Assert.Equal(4, distTo[5]); 
            Assert.Equal(4, distTo[6]); 
            Assert.Equal(3, distTo[7]); 
            Assert.Equal(2, distTo[8]); 


        }
    }
}
