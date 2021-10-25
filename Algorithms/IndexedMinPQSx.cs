using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class IndexedMinPQSx<T> where T:IComparable<T>
    {
        int[] pq; // 1 index based array for pq
        T[] keys;
        int N = 0; // current count
        int index = 0;
        int maxSize;
        private int[] qp; // contains idex of pq for index of keys
        public IndexedMinPQSx(int maxSize)
        {
            pq = new int[maxSize+1];
            keys = new T[maxSize+1];
            qp = new int[maxSize + 1]; // pq[qp[i]] = qp[pq[i]] = i
           this.maxSize = maxSize;

            // initialize qp
            for(int i =0; i <= maxSize; i++)
            {
                qp[i] = -1;
            }
        }

        /// <summary>
        /// insert the key in the given index
        /// </summary>
        /// <param name="i"></param>
        /// <param name="key"></param>
        /// 
        public void Insert(int i, T key)
        {
            if(i > maxSize-1)
            {
                throw new IndexOutOfRangeException();
            }

            N++;

            pq[N] = i;
            qp[i] = N;
            keys[i] = (T)key;
            Swim(N);          

        }


        private void Swim(int k)
        {
            while(k > 1)
            {
                if(Less(k, k/2))
                {
                    Exch(k, k / 2);
                }

                k = k / 2;
            }
        }


        private void Sink(int k)
        {
         
          while(2*k < N)
           {

              int j = 2*k;

             if (Less(j, j + 1)) j++;

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

            // update qp
            qp[pq[i]] = i;
            qp[pq[j]] = j;
        }


        /// <summary>
        /// Change the key at the given index
        /// </summary>
        /// <param name="i"></param>
        /// <param name="key"></param>
        public void ChangeKey(int i, T key)
        {
            keys[i] = key;

            // set the key then Sink to re arrange the pq
            Swim(qp[i]);
            Sink(qp[i]);
        }

        public bool Contains(int i)
        {
            return qp[i] != -1;
        }

        public void Delete(int i)
        {
            keys[i] = default;
        }

        public T MinKey()
        {
            return keys[pq[1]];
        }

        /// <summary>
        /// index of the minimum key
        /// </summary>
        /// <returns></returns>
        public int MinIndex()
        {
            return pq[1];
        }
        /// <summary>
        /// Removes the minimum key and return its index
        /// </summary>
        /// <returns></returns>
        public int DeleteMin()
        {
            var min = pq[1];
            pq[1] = pq[N--];

            Swim(N);
            qp[pq[1]] = -1;
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

        public T KeyOf(int i)
        {
            return keys[i];
        }
    }
}
