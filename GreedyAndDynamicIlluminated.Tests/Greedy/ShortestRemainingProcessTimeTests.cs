using GreedyAndDynamicIlluminated.Greedy;
using System.Collections.Generic;
using Xunit;

namespace GreedyAndDynamicIlluminated.Tests.Greedy
{
    public class ShortestRemainingProcessTimeTests
    {
        [Fact]
        public void TestCompletionTime()
        {
            // Arrange 
            List<Job> jobs = new List<Job>()
            {
              new Job(4,0),
              new Job(2,1)
            };

            var test = new ShortestRemainingProcessTime();

            // Act
            int result = test.MinCompletionTime(jobs);

            // Assert
            Assert.Equal(9, result);
        }
    }
}
