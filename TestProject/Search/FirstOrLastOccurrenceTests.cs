using PracticeProblems.Search;
using Xunit;

namespace TestProject.Search
{
    public class FirstOrLastOccurrenceTests
    {
        [Fact]
        public void FirstOrLastTests()
        {
            // Arrange 
            int[] arr = new int[]
            {
                1, 2, 3, 3,  5,5,5,5,5,6,7,8
            };

            int result = FindFirstOrLastOccurrenceBS.FindOcurrence(arr, 5, true);
            Assert.Equal(4, result);

        }

        [Fact]
        public void LastTests()
        {
            // Arrange 
            int[] arr = new int[]
            {
                1, 2, 3, 3,  5,5,5,5,5,6,7,8
            };

            int result = FindFirstOrLastOccurrenceBS.FindOcurrence(arr, 5, false);
            Assert.Equal(8, result);

        }

        [Fact]
        public void NotExistsTests()
        {
            // Arrange 
            int[] arr = new int[]
            {
                1, 2, 3, 3,  5,5,5,5,5,6,7,8
            };

            int result = FindFirstOrLastOccurrenceBS.FindOcurrence(arr, 9, false);
            Assert.Equal(-1, result);

        }
    }
}
