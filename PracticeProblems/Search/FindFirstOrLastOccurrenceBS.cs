namespace PracticeProblems.Search
{
    public class FindFirstOrLastOccurrenceBS
    {
        public static int FindOcurrence(int[] arr, int num, bool first)
        {
            if (arr.Length < 1) return -1;
            return BinarySearch(arr, num, first);
        }

        private static  int BinarySearch(int[] arr, int num, bool first)
        {
            int lo = 0;
            int hi = arr.Length - 1;
            int result = -1;
            while(lo <= hi)
            {
                int mid = (hi + lo) / 2;
                if(arr[mid] == num)
                {
                    result = mid;
                    if (first)
                        hi = mid - 1;
                    else
                        lo = mid + 1;
                }
                else // normal binary search
                {
                    if (num < arr[mid])
                        hi = mid - 1;
                    else
                        lo = mid + 1;
                }
            }

            return result;
        }
    }
}
