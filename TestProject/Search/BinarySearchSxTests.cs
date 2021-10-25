using PracticeProblems.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject.Search
{
    public class BinarySearchSxTests
    {
        BinarySearchSx bs;

        [Fact]
        public void FindPointOfchange_Test1()
        {
            var arr = new int[]
            {
                1,3,5,8,4,2
            };

            bs = new BinarySearchSx(arr);

            var result = bs.FindPointOfchange();

            Assert.Equal(8, result);
        }

        [Fact]
        public void FindPointOfchange_Test2()
        {
            var arr = new int[]
            {
                -2,1,3,5,7,4,2,0
            };

            bs = new BinarySearchSx(arr);

            var result = bs.FindPointOfchange();

            Assert.Equal(7, result);
        }
    }
}
