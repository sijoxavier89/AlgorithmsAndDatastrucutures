using PracticeProblems.DivideandConquer;
using System.Numerics;
using Xunit;

namespace TestProject.DivideandConquer
{
    public  class KaratsubaTests
    {
        [Fact]
        public void MultiplySmallTets()
        {
            long x = 45;
            long y = 35;

            long result = Karatsuba.Multiply(x, y);

            Assert.Equal(1575, result);
        }


        [Fact]
        public void MultiplyLongEqualEvenDigitsTets()
        {
            long x = 9999;
            long y = 9999;

            long result = Karatsuba.Multiply(x, y);

            Assert.Equal(99980001, result);
        }


        [Fact]
        public void MultiplyLongEqualEvenDigitsTets2()
        {
            long x = 99999999;
            long y = 99999999;

            long result = Karatsuba.Multiply(x, y);

            Assert.Equal(9999999800000001, result);
        }


        [Fact]
        public void MultiplyLongNotEqualEvenDigitsTets()
        {
            long x = 99999999;
            long y = 00009999;

            long result = Karatsuba.Multiply(x, y);

            Assert.Equal(999899990001, result);
        }
        [Fact]
        public void MultiplyLongEqualOddTets()
        {
            long x = 99999;
            long y = 99999;

            long result = Karatsuba.Multiply(x, y);

            Assert.Equal(9999800001, result);
        }

        [Fact]
        public void MultiplyLongNotEqualOddTets()
        {
            long x = 99999;
            long y = 9999;

            long result = Karatsuba.Multiply(x, y);

            Assert.Equal(999890001, result);
        }


        //[Fact]
        //public void MultiplyChallengeTets()
        //{
        //    BigInteger x = BigInteger.Parse("3141592653589793238462643383279502884197169399375105820974944592");
        //    BigInteger y = BigInteger.Parse("2718281828459045235360287471352662497757247093699959574966967627");

        //  //  long result = Karatsuba.Multiply(x, y);

        // //   Assert.Equal(expected, result);
        //}
    }
}
