using System;

namespace Algorithms
{
    public class SuffixArray
    {
        private readonly int N;
        readonly string[] suffixes;
        public SuffixArray(string text) // builld suffix array for text
        {
            N = text.Length;
            suffixes = new string[N];
            for (int i = 0; i < N; i++)
            {
                suffixes[i] = text.Substring(i);
            }

            // sort
            Array.Sort(suffixes);
        }

        public int Length() // length of the text
        {
            return N;
        }

        /// <summary>
        /// ith in the suffix array 
        /// i between 0 and N-1
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public string Select(int i)
        {
            return suffixes[i];
        }
        /// <summary>
        /// length of select(i) (i between 0 and N-1)
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int Lcp(int i)
        {
            return Lcp(suffixes[i], suffixes[i-1]);
        }

        private int Lcp(string s1, string s2)
        {
            int len = (s1.Length > s2.Length) ? s2.Length : s1.Length;

            int j = 0;

            while (j < len && string.Equals(s1[j], s2[j]))
            {
                j++;
            }

            return j;
        }

        /// <summary>
        /// number of suffixes less than key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int Rank(string key)
        {
            // Binary Search for finding the key

            int start = 0;
            int end = N - 1;

            while(start <= end)
            {
                int mid = start + (end - start) / 2;

                int cmp = key.CompareTo(suffixes[mid]);
               
                if(cmp < 0)
                {
                    end = mid - 1;
                }
                else if(cmp > 0)
                {
                    start = mid + 1;
                }
                else
                {
                    return mid;
                }
            }
            return start;
        }

    }
}
