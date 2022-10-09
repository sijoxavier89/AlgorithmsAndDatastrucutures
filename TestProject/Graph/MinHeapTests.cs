using PracticeProblems.Graph;
using Xunit;

namespace PracticeProblems.Tests.Graph
{
    public class MinHeapTests
    {

        [Fact]
        public void TestMin()
        {
            MinHeap minHeap = new MinHeap(5);

            minHeap.Insert(5, 5);
            minHeap.Insert(4, 4);
            minHeap.Insert(3, 3);
            minHeap.Insert(2, 2);
            minHeap.Insert(1, 1);

            int size = minHeap.Size;
            Assert.Equal(5, size);
            int? min = minHeap.DeleteMin();
            Assert.Equal(1, min);
            Assert.Equal(4, minHeap.Size);
            int? min1 = minHeap.DeleteMin();
            Assert.Equal(2, min1);
            Assert.Equal(3, minHeap.Size);

            // Update Key
            minHeap.ChangeKey(6, 3);
            int? min2 = minHeap.GetMin();
            Assert.Equal(4, min2);
            Assert.Equal(3, minHeap.Size);
        }

    }
}
