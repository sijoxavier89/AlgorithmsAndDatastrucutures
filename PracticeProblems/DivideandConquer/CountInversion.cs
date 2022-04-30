namespace PracticeProblems.DivideandConquer
{
    /// <summary>
    /// given an array of intigers , return the number of inversion possible 
    /// ie number of times it can be re arranged to get a sort order 
    /// </summary>
    public class CountInversion
    {
         int count;
         int[] aux;
        public  int Count(int[]  a)
        {
            int len = a.Length;
            aux = new int[len];
            CountInv(a, 0, len - 1);
            return count;
        }

        private  void CountInv(int[] a, int lo, int hi)
        {
            if (hi <= lo) return;
            int mid = (hi + lo) / 2;

            CountInv(a, lo, mid);
            CountInv(a, mid + 1, hi);
            // merge and count
            CountInvMerge(a, lo, mid, hi);

        }

        private void CountInvMerge(int[] a, int lo, int mid, int hi)
        {
            for(int i=lo; i<=hi; i++)
            {
                aux[i] = a[i];
            }

            int first = lo;
            int second = mid + 1;
            int start = lo;

            while(start <= hi)
            {
                if (first > mid) a[start++] = aux[second++];
                else if (second > hi) a[start++] = aux[first++];
                else if(aux[first] <= aux[second])
                {
                    a[start++] = aux[first++];
                }
                else
                {
                    count += (mid - first + 1);
                    a[start++] = aux[second++];
                }
            }
        }
    }
}
