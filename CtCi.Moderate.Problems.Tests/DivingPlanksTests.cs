using System.Linq;
using Xunit;

namespace CtCi.Moderate.Problems.Tests
{
    public class DivingPlanksTests
    {
        [Fact]
        public void TestDistanceCount()
        {
            var divingPlank = new DivingPlanks();

            int shorter = 6;
            int longer = 7;
            int total = 8;

            // Act
            var result = divingPlank.Distances(shorter, longer, total);

            // Assert
            Assert.True(result.Count<int>() > 0);
        }
    }
}
