using Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject
{
   
    public class MInPQSxTests
    {
        MinPQSx<int> pq;

        [Fact]
        public void TestMinPQSx()
        {
            int size = 5;
            pq = new MinPQSx<int>(size);
            var input = new int[]
            {
                5,4,1,3,2
            };

            foreach(var i in input)
            {
                pq.Insert(i);
            }

            // Test Min
            Assert.Equal(1, pq.DeleteMin());
            Assert.Equal(2, pq.DeleteMin());

            Assert.Equal(3, pq.Size());
        }

    }
}
