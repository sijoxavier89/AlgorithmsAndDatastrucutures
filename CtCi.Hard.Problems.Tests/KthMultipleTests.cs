using Xunit;

namespace CtCi.Hard.Problems.Tests
{
    public class KthMultipleTests
    {

        [Fact]
        public void Tests()
        {
            // Arrange 
            int K = 7;

            // Act
            int multiple = KthMultiple.Get(K);

            // Assert
            Assert.Equal(21, multiple);
        }
    }
}
