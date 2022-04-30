using PracticeProblems.DivideandConquer;
using Xunit;

namespace TestProject.DivideandConquer
{
    public class CountInversionTests
    {
        public CountInversionTests()
        {

        }

        [Fact]
        public void  CountTest()
        {
            int[] input = new int[] { 1, 2, 5, 4, 3, 6 };

            var cInv = new CountInversion();
            var result = cInv.Count(input);

            int expected = 3;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CountTest1()
        {
            int[] input = new int[] { 54044
                 ,14108
                 ,79294
                ,29649
               ,25260
              ,60660
             ,2995
              ,53777
             ,49689
             ,9083 };

            var cInv = new CountInversion();
            var result = cInv.Count(input);

            int expected = 28;
            Assert.Equal(expected, result);
        }
    }
}
