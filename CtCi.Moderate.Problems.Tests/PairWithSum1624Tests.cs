using Xunit;

namespace CtCi.Moderate.Problems.Tests
{
    public class PairWithSum1624Tests
    {
        [Theory]
        [InlineData(new int[] {0, 1, 2, 5, 3, 6, -1}, 5)]
     
        public void TestPairsWithSum(int[] nums, int target)
        {
            // Arrange

            // Act
            var result = PairWithSum1624.GetPairsWithSum(nums, target);
            // Assert
            Assert.Equal(3, result.Count);
        }

        [Theory]
        [InlineData(new int[] { 0, 1, 2, 5, 3, 6, -1, 0, 5 }, 5)]
        public void TestPairsWithSumWithDupliates(int[] nums, int target)
        {
            // Arrange

            // Act
            var result = PairWithSum1624.GetPairsWithSum(nums, target);
            // Assert
            Assert.Equal(4, result.Count);
        }
    }
}
