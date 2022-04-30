using System.Collections.Generic;

namespace PracticeProblems.Graph
{
    public class Median
    {

        public static int Find(List<int> arr)
        {
            int lo = 0;
            int hi = arr.Count - 1;

            int med = arr.Count / 2;

            while(hi > lo)
            {
                int p = Partition(lo, hi, arr);

                if (p < med) lo = p + 1;
                else if (p > med) hi = p - 1;
                else return arr[med];
            }

            return arr[med];
        }

        private static int Partition(int lo, int hi, List<int> arr)
        {
            int i = lo+1;
            int j = hi ;
            int pivot = lo;
            while(true)
            {
                while (arr[i] < arr[pivot])
                {
                    i++;
                    if (i == hi) break;
                }

                while (arr[j] >= arr[pivot])
                {
                    j--;
                    if (j == lo) break;
                }

                if (j <= i) break;

                Exch(i, j, arr);


            }

            Exch(pivot, j, arr);
            return j;
        }


        private static void Exch(int i, int j, List<int> arr)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }


    }
}
