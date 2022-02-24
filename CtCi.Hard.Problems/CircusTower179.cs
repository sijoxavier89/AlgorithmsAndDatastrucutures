using System;
using System.Collections.Generic;

namespace CtCi.Hard.Problems
{
    /// <summary>
    /// Given the list of Height, Weight of people find the maximum number of people 
    /// who can build a circus tower. Tower is created with one person who have lesser 
    /// weight and height stand above another
    /// </summary>
    public class CircusTower
    {
        public static List<Hwt>  MaximumPeople(List<Hwt> people)
        {
            people.Sort();
           
            return BestSequenceatIndex(people, new List<Hwt>(), 0);

        }

        /// <summary>
        /// consider a binary tree , each time it decides left if 
        /// the next person in the list added to tower, the right branch is 
        /// always there whether we next person can be added or not 
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private static List<Hwt> BestSequenceatIndex(List<Hwt> items, List<Hwt> sequence, int index)
        {
            if(index >= items.Count)
            {
                return sequence;
            }

            List<Hwt> bestWith = null;
            Hwt value = items[index];
            if(CanAppend(sequence, value))
            {
                List<Hwt> sequenceWith = GetClone(sequence);
                sequenceWith.Add(value);
                bestWith = BestSequenceatIndex(items, sequenceWith, index + 1);
            }

            List<Hwt> bestWithout = BestSequenceatIndex(items, sequence, index + 1);

            return Max(bestWith, bestWithout);
        }

        // create a deep copy of the list
        private static List<Hwt> GetClone(List<Hwt> original)
        {
            List<Hwt> deepCopy = new List<Hwt>();

            if (original.Count == 0) return deepCopy;

            foreach (var item in original)
            {
                deepCopy.Add(item);
            }

            return deepCopy;
        }
        /// <summary>
        /// Select the list with the maximum count
        /// </summary>
        /// <param name="seq1"></param>
        /// <param name="seq2"></param>
        /// <returns></returns>
        private static  List<Hwt> Max(List<Hwt> seq1, List<Hwt> seq2)
        {
            if (seq1 == null)
                return seq2;
            if (seq2 == null)
                return seq1;

            if (seq2.Count > seq1.Count) return seq2;

            return seq1;
        }

        /// <summary>
        /// chack if the value can be appeneded to 
        /// the last item in the list
        /// </summary>
        /// <param name="solution"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static  bool CanAppend(List<Hwt> solution, Hwt value)
        {
            if (solution == null) return false;
            if (solution.Count == 0) return true;

            Hwt last = solution[solution.Count - 1];

            return last.IsBefore(value);
        }
    }



    
    public class Hwt : IComparable<Hwt>
    {
        public int Height { get; }
        public int Weight { get; }
        public Hwt(int height, int weight)
        {
            Height = height;
            Weight = weight;
        }

        /// <summary>
        ///  Compare based on the height , if eaqual
        ///  compare the weight
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Hwt other)
        {
            if(this.Height < other.Height)
            {
                return -1;
            }
            else if(this.Height > other.Height)
            {
                return 1;
            }
            else
            {
                return this.Weight - other.Weight;
            }
        }

        public bool IsBefore(Hwt other)
        {
            return (other.Height > Height) && (other.Weight > Weight);
        }
    }
}
