using System;
using System.Collections.Generic;

namespace CtCi.Hard.Problems
{
    /// <summary>
    /// find the kth multiple which have multiple as prime factors 3,5,7 only 
    /// 3,5,7 need not to be factor but it should not contain any other factors
    /// eg: 1, 3, 5, 7 , 9, 15, 21, 25, 27, 35
    /// </summary>
    public class KthMultiple
    {
        public static int Get(int index)
        {
            LinkedList<int> qthree = new LinkedList<int>();
            LinkedList<int> qfive  = new LinkedList<int>();
            LinkedList<int> qseven = new LinkedList<int>();

            qthree.AddFirst(1);
            int kthvalue = 0;
            for (int i = 0; i < index; i++)
            {
                int v3 = qthree.Count != 0? qthree.First.Value: int.MaxValue;
                int v5 = qfive.Count != 0 ? qfive.First.Value : int.MaxValue;
                int v7 = qseven.Count != 0 ? qseven.First.Value : int.MaxValue;

                int min = Math.Min(v3, Math.Min(v5, v7));

                // if min is from list of 3s multiple  add multiple of min to all list as 
                // they are new values to the list
                if (min == v3)
                {
                    AddToQ(min * 3, qthree);
                    AddToQ(min * 5, qfive);
                    RemoveMin(qthree);

                }
                else if (min == v5) // if min is from 5, the multiple of min * 3 is already in list three 
                {
                    AddToQ(min * 5, qfive);
                    RemoveMin(qfive);

                }
                AddToQ(min * 7, qseven); // we always have to add multiple of  min and 7

                if(min == v7) RemoveMin(qseven);

                kthvalue = min;

            }

            return kthvalue;
        }

        private static void RemoveMin(LinkedList<int> queue)
        {

            queue.RemoveFirst();

        }

        private static void AddToQ(int value, LinkedList<int> queue)
        {
            queue.AddLast(value);
        }
    }
}
