using Xunit;

namespace CtCi.Hard.Problems.Tests
{
    public class LetterAndNumbers175Tests
    {
        [Fact]
        public void ComputeLongestArrayTests()
        {
            // Arrange
            string[] input = new string[]
            {
                "A", "A", "A", "A", "1", "1", "A", "1", "1", "A", "A", "1", "A", "A", "1", "A", "A", "A", "A", "A"
            };

            // Act

            var result = LetterAndNumbers175.FindLongestArray(input);

            // Assert
            Assert.Equal(12, result.Length);
        }
    }
}
