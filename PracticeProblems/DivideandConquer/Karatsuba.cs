using System;

namespace PracticeProblems.DivideandConquer
{
    /**
     * Multiply x * y 
   Assumption: x,y have digits n which is power of 2
   // ab * cd =>  ac.10^n + (ad+bc)10^n/2 + bd
   Mulitply(int x, int y)
     if n = 1 , return x.y;

   a, b := first half of x, second half of x
   c, d := first half of y, second half of y
   pq :=  (a+b) * (c+d)
   a.c := Multiply(a, c)
   b.d := Multiply(b, d)
  adbc = pq-(a.c+b.d)
  
   return  ac*10^n+adbc*10^n/2+bd
  
     **/
    public class Karatsuba
    {
        public static long Multiply(long x, long y)
        {
            int n = Math.Max(CountDigits(x), CountDigits(y));

            long result = RecIntMult(x, y, n);
            return result;
        }

        private static long RecIntMult(long x, long y, int n)
        {
            if (n == 1) return x * y;

            // if ((x % 10 == x) && (y % 10 == y)) return x * y;
            // if ((x == 0) || y == 0) return 0;
            // divide x into half
            long[] xHalf = Half(x);
            long a = xHalf[0];
            long b = xHalf[1];

            // divide y into half
            long[] yHalf = Half(y);
            long c = yHalf[0];
            long d = yHalf[1];

            int d1 = Math.Max(CountDigits(a), CountDigits(c));
            long ac = RecIntMult(a, c, d1);
            int d2 = Math.Max(CountDigits(b), CountDigits(d));
            long bd = RecIntMult(b, d, d2);

            long pq = (a + b) * (c + d);
            long adbc = pq - ac - bd;

            long result = (long)Math.Pow(10, n) * ac + (long)Math.Pow(10, n / 2) * adbc + bd;
            return result;
        }

        private static long[] Half(long x)
        {
            int len = CountDigits(x);
            int mid = len / 2;
            int rh = len - mid;

            long[] result = new long[2];
            long pow10 = (long)Math.Pow(10, rh);
            result[0] = x / (pow10);
            result[1] = x % (pow10);

            return result;
        }

        private static int CountDigits(long x)
        {
            int count = 0;

            while (x  != 0)
            {
                count++;
                x = x / 10;
            }

            return count;
        }
    }
}
