using PracticeProblems.Graph;
using Xunit;

namespace TestProject.Graph
{
    public class DigraphTests
    {
        [Fact]
        public void TestGraph()
        {
            string path = @"C:\Users\sijox\source\repos\AlgorithmsAndDatastrucutures\TestProject\Graph\TestData\problem8.10test1.txt";
            Digraph g = new Digraph(path);

            int vertices = 9;
            int edges = 11;

            string graph  = g.ToString();

            Assert.Equal(vertices, g.V());
            Assert.Equal(edges, g.E());

            Assert.Equal(2, g.Indegree(6));
            Assert.Equal(2, g.Outdegree(9));

            // test the reverse

            Digraph reverse = g.Reverse();

            Assert.Equal(vertices, reverse.V());
            Assert.Equal(edges, reverse.E());

          
            Assert.Equal(2, reverse.Outdegree(6));
            Assert.Equal(2, reverse.Indegree(9));


        }
    }
}
