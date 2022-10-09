using PracticeProblems.Graph;
using Xunit;

namespace PracticeProblems.Tests.Graph
{
    public class DirectedCycleTests
    {
        [Fact]
        public void TestDirectedCycle_GraphWithCycle()
        {
            string path = @"C:\Users\sijox\source\repos\AlgorithmsAndDatastrucutures\TestProject\Graph\TestData\directedcycle.txt";
            Digraph g = new Digraph(path);
            var dc = new DirectedCycle(g);

            Assert.True(dc.HasCycle());
        }
        [Fact]
        public void TestDirectedCycle_WithMultipleCycle()
        {
            string path = @"C:\Users\sijox\source\repos\AlgorithmsAndDatastrucutures\TestProject\Graph\TestData\cc.txt";
            Digraph g = new Digraph(path);
            var dc = new DirectedCycle(g);

            Assert.True(dc.HasCycle());
        }

        [Fact]
        public void TestDirectedCycle_NoCycle()
        {
            string path = @"C:\Users\sijox\source\repos\AlgorithmsAndDatastrucutures\TestProject\Graph\TestData\nocycle.txt";
            Digraph g = new Digraph(path);
            var dc = new DirectedCycle(g);

            Assert.False(dc.HasCycle());
        }
    }
}
