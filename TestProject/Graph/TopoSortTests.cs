using PracticeProblems.Graph;
using System.Collections.Generic;
using Xunit;

namespace PracticeProblems.Tests.Graph
{
    public  class TopoSortTests
    {
        public TopoSortTests()
        {

        }

        [Fact]
        public void TestOrder()
        {
            string path = @"C:\Users\sijox\source\repos\AlgorithmsAndDatastrucutures\TestProject\Graph\TestData\toposort.txt";
            Digraph g = new Digraph(path);

            TopoSort ts = new TopoSort();
            Stack<int> order = (Stack<int>)ts.Get(g);

            Assert.NotNull(order);

        }

        [Fact]
        public void TestCycle()
        {
            string path = @"C:\Users\sijox\source\repos\AlgorithmsAndDatastrucutures\TestProject\Graph\TestData\directedcycle.txt";
            Digraph g = new Digraph(path);

            TopoSort ts = new TopoSort();
            Stack<int> order = (Stack<int>)ts.Get(g);

            Assert.Null(order);
        }
    }
}
