using System;

namespace Algorithms
{
    public class MinPQSx<T> where T:IComparable<T>
    {
        T[] pq;
        int N;
        public MinPQSx(int maxSize)
        {
            pq = new T[maxSize + 1];
            N = 0;
        }

        public void Insert(T key)
        {
           
            pq[++N] = key;
            Swim(N);

        }

        public T DeleteMin()
        {
            var min = pq[1];
            Exch(1, N--);

            Sink(1);
            pq[N + 1] = default;
            return min;
        }

        public bool IsEmpty()
        {
            return N == 0;
        }

        public int Size()
        {
            return N;
        }
        private void Swim(int k)
        {
            while (k > 1 && Less(k, k / 2))
            {
                Exch(k/2, k);
                 k = k / 2;
            }
        }


        private void Sink(int k)
        {

            while (2 * k < N)
            {

                int j = 2 * k;

                if (j < N && !Less(j, j + 1)) j++;

                if (Less(k, j)) break;

                Exch(k, j);

                k = j;
            }
        }


        /// <summary>
        /// returns true if element at index i lesser than that of 
        /// index j
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private bool Less(int i, int j)
        {
            int comp = pq[i].CompareTo(pq[j]);

            return comp < 0;
        }

        /// <summary>
        /// Exchange element of given two indexes
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void Exch(int i, int j)
        {
            var temp = pq[i];
            pq[i] = pq[j];
            pq[j] = temp;
        }
    }
}
