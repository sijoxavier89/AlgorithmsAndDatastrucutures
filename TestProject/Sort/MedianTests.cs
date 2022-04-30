using PracticeProblems.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject.Sort
{
    public class MedianTests
    {

        [Fact]
        public void MedianTest1()
        {
            List<int> inp = new List<int>() { 1, 7, 5, 4, 2, 3, 6 };

            int result = Median.Find(inp);

            Assert.Equal(4, result);
        }

        [Fact]
        public void MedianTest2()
        {
            List<int> inp = new List<int>() { 1, 7, 5, 4, 4, 4, 4};

            int result = Median.Find(inp);

            Assert.Equal(4, result);
        }

        [Fact]
        public void MedianTest3()
        {
            List<int> inp = new List<int>() { 1, 1, 1, 1, 1, 1, 1 };

            int result = Median.Find(inp);

            Assert.Equal(1, result);
        }
    }
}
