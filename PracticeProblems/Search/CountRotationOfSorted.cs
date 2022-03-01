namespace TestProject.Search
{
    public class CountRotationOfSorted
    {
        public static int Count(int[] arr)
        {
            return BinarySearch(arr);
        }

        private static  int BinarySearch(int[] arr)
        {
            int len = arr.Length;
            int lo = 0;
            int hi = len - 1;
           
          
            while(lo <= hi)
            {
                if (arr[lo] < arr[hi]) // when lo is the pivot element, the array is sorted
                {
                    return lo;
                }

                int mid = (lo + hi) / 2;
                int prev = (mid - 1 + len) % len;
                int next = (mid + 1) % len;

                if(arr[mid] < arr[prev] && arr[mid] < arr[next])
                {
                    return mid;
                }
                else if(arr[mid] > arr[hi])
                {
                    lo = mid + 1;
                }
                else if(arr[mid] < arr[hi])
                {
                    hi = mid - 1;
                }
            }
            return -1;
        }
    }
}
