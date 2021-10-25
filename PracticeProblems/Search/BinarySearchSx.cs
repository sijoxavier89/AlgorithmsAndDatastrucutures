using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems.Search
{
   public  class BinarySearchSx 
   {
        int[] arr;
        public BinarySearchSx(int[] arr)
        {
            this.arr = arr;
        }

        /// <summary>
        /// Given a monotonically increasing then decreasing 
        /// array, find the point at which valu start to decrease
        /// eg: 1 3  5 6 4 2 
        /// o/p = 6
        /// </summary>
        /// <returns></returns>
        public int FindPointOfchange()
        {
            var n = arr.Length;

            int x = -1;
            int z = n/2;
            for(int b = z; b >= 1; b /= 2)
            {
              while(x + b+1 < n && arr[x+b] < arr[x+b+1])
              {
                    x = x + b;
              }
            }

            int k = x + 1;

            return arr[k];
        }
    
   }
}
