using Xunit;

namespace TestProject.Search
{
    public class CountRotationOfSortedTests
    {
       
        [Fact]
        public void TestCount()
        {
            var arr = new int[]
            {
                6, 7, 8, 1, 2, 3, 4, 5
            };

            // Act
            int result = CountRotationOfSorted.Count(arr);

            // Assert
            Assert.Equal(3, result);
        }


        [Fact]
        public void TestCount2()
        {
            var arr = new int[]
            {
               11,12,15, 18,2, 5, 6, 8
            };

            // Act
            int result = CountRotationOfSorted.Count(arr);

            // Assert
            Assert.Equal(4, result);
        }
        [Fact]
        public void TestCountNotRotated()
        {
            var arr = new int[]
            {
                1, 2, 3, 4, 5, 6, 7, 8
            };

            // Act
            int result = CountRotationOfSorted.Count(arr);

            // Assert
            Assert.Equal(0, result);
        }
    }
}
