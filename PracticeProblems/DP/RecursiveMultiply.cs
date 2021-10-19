using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems.DP
{
    /// <summary>
    /// multiply two positive numbers without using 
    /// * operater 
    /// </summary>
    public class RecursiveMultiply
    {
        public int MultiplyTwoNum(int num1, int num2)
        {
           
            int greater = num1 > num2 ? num1 : num2;
            int smaller = num1 > num2 ? num2 : num1;

            if(smaller < 2)
            {
                return greater;
            }

            int result = greater;
            Multiply(greater, smaller, ref result, 0);

            if(smaller % 2 == 1)
            {
                return greater + result;
            }
            return result;
        }

        private void Multiply(int num1, int num2,ref int shifted, int reminder)
        {
          
            if (num2 - reminder > 1)
            {
                shifted = shifted << 1;
                int r = shifted / num1;
                Multiply(num1, num2,ref shifted, r);
            }

            
        }
    }
}
