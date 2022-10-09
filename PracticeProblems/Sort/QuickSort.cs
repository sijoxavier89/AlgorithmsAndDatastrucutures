using System;

namespace PracticeProblems.Sort
{
    public  class QuickSort<TKey> where TKey : IComparable<TKey>
    {
        public static void Sort(TKey[] arr)
        {
            Sort(arr, 0, arr.Length-1);

        }

        private static void Sort(TKey[] arr, int lo, int hi)
        {
            if (lo >= hi) return;

            int p = Partition(arr, lo, hi);

            Sort(arr, lo, p - 1);
            Sort(arr, p+1, hi);
        }

        static int Partition(TKey[] arr,int lo, int hi)
        {
            int l = lo+1;
            int r = hi;

            int pivot = lo;
            for(int j = lo+1; j <= r; j++)
            {
                if(Less(arr, j, pivot))
                {
                    Swap(arr, j, l);
                    l++;
                }
            }

            Swap(arr,pivot, l-1);
            return l - 1;
        }

        private static void Swap(TKey[] arr, int i, int j)
        {
            (arr[i], arr[j]) = (arr[j], arr[i]);
        }

        static bool Less(TKey[] arr, int i, int j)
        {
            return arr[i].CompareTo(arr[j]) < 0;
        }
    }
}
