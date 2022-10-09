using PracticeProblems.Graph;
using System.Collections.Generic;
using Xunit;

namespace PracticeProblems.Tests.Graph
{
    public class EdgeWeightedDigraphTests
    {
        [Fact]
        public void PrintGrapgh()
        {
            string path = @"C:\Users\sijox\source\repos\AlgorithmsAndDatastrucutures\TestProject\Graph\TestData\problem9.8test.txt";
            EdgeWeightedDigraph g = new EdgeWeightedDigraph(path);
            string s = g.ToString();
            Assert.True(s.Length > 0);
        }

        [Fact]
        public void ValidateVertices()
        {
            string path = @"C:\Users\sijox\source\repos\AlgorithmsAndDatastrucutures\TestProject\Graph\TestData\problem9.8test.txt";
            EdgeWeightedDigraph g = new EdgeWeightedDigraph(path);
            int vertices = ((HashSet<int>)g.Vertices()).Count;
            Assert.Equal(8,vertices);

            int indegree = g.Indegree(1);
            Assert.Equal(2, indegree);

            int outdegree = g.Outdegree(1);
            Assert.Equal(2, outdegree);

        }
    }
}
