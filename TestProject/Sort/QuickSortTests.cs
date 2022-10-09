using PracticeProblems.Sort;
using Xunit;

namespace PracticeProblems.Tests.Sort
{
    public class QuickSortTests
    {
        [Fact]
        public void Tests()
        {
            int[] arr = new int[] { 1, 6, 3, 5, 4, 2 };

            QuickSort<int>.Sort(arr);
            Assert.Equal(1, arr[0]);
            Assert.Equal(2, arr[1]);
            Assert.Equal(3, arr[2]);
            Assert.Equal(4, arr[3]);
            Assert.Equal(5, arr[4]);
            Assert.Equal(6, arr[5]);
        }
    }
}
