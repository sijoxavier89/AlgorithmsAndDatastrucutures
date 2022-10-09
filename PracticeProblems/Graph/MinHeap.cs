using System.Collections.Generic;

namespace PracticeProblems.Graph
{
    // MinHeap

    public class MinHeap
    {

        public int Size { get
            {
                return currentSize;
            } }
        private int currentSize;
        int?[] pq; // maintain heap array with values as vertex
        Dictionary<int?, int> qp; // map pq[i] to i
        Dictionary<int?, int> keys; // keys for pq[i]

        public MinHeap(int size)
        {
            pq = new int?[size + 1];
            qp = new Dictionary<int?, int>(size + 1);
            keys = new Dictionary<int?, int>(size + 1);

        }

        public void Insert(int key, int? value)
        {
                //TODO: validate
                keys.Add(value, key);
                pq[++currentSize] = value;
                qp[value] = currentSize;
                Swim(currentSize);

           

        }

        public int? GetMin()
        {
            return pq[1];
        }
        public bool Contains(int value)
        {
            return qp.ContainsKey(value) && qp[value] != -1;
        }

        public bool IsEmpty()
        {
            return currentSize == 0;
        }

        // delete and returns the Minimum value of pq
        public int? DeleteMin()
        {

            int? min = pq[1];
            int? value = pq[currentSize];
            pq[1] = value;
            pq[currentSize--] = null;

            Sink(1);
            return min;
        }

        public int KeyOf(int value)
        {
            return keys[value];
        }

        // change the key curresponds to value
        public void ChangeKey(int key, int value)
        {
            //TODO: validate
            keys[value] = key;
            Swim(qp[value]);
            Sink(qp[value]);
        }

        public void Delete(int value)
        {
            int index = qp[value];
            pq[index] = pq[currentSize];
            pq[currentSize--] = null;
            qp[value] = -1;
            Sink(index);
            Swim(currentSize);

        }

        private void Swim(int k)
        {
            while (k > 1 && Greater(k/2, k))
            {              
                    Exch(k/2, k);

                    k = k/2;
               
            }
        }


        private void Sink(int k)
        {
            while (2*k <= currentSize)
            {
                int j = 2*k;

                if (j < currentSize && Greater(j, j + 1)) j++;

                if (!Greater(k, j)) break;
              
                Exch(k, j);
                
                k = j;
            }

        }

        private bool Greater(int i, int j)
        {
            int keyi = keys[pq[i]];
            int keyj = keys[pq[j]];

            if (keyi > keyj) return true;

            return false;
        }

        private void Exch(int i, int j)
        {
            int? pqi = pq[i];
            int? pqj = pq[j];

            (pq[j], pq[i]) = (pq[i], pq[j]);
            qp[pqi] = j;
            qp[pqj] = i;
        }
    }

}
