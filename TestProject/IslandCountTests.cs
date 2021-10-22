using PracticeProblems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject
{
    public class IslandCountTests
    {
        IslandCount islandCount;

        public IslandCountTests()
        {
            islandCount = new IslandCount();
        }

        [Fact]
        public void Count_ReturnsIslandCount()
        {
            var island = new bool[4, 4]
            {
                {true, false, true, false },
                {true, false, true, false },
                {false, true, false, true },
                {true, false, true, true },
            };

            var count = islandCount.Count(island);

            Assert.Equal(1, count);
        }
    }
}
