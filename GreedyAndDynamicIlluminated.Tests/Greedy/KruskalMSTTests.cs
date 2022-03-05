using GreedyAndDynamicIlluminated.Greedy;
using System.IO;
using Xunit;

namespace GreedyAndDynamicIlluminated.Tests.Greedy
{
    public class KruskalMSTTests
    {
        [Fact]
        public void TestMST()
        {
            // Arrange
            string[] lines = File.ReadAllLines(@"C:\Users\sijox\source\repos\AlgorithmsAndDatastrucutures\GreedyAndDynamicIlluminated.Tests\Greedy\TestData\15-9MST.txt");

            Assert.True(lines.Length > 0);
            var graph = new EdgeWeightedGraph(lines);
            // Act
            KruskalMST mst = new KruskalMST(graph);
            var costOfMST = mst.Weight();

            Assert.Equal(14, costOfMST);
        }
    }
}
