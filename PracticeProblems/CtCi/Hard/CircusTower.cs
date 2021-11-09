using System;
using System.Collections;
using System.Collections.Generic;

namespace PracticeProblems.CtCi.Hard
{
   /// <summary>
   /// Given a list of people with given Height and Weight
   /// Compute the seequenc with Maximum height of the circus tower
   /// A  circus tower is formed by one pwrson staonding on the 
   /// top of the other, with a condition  that   height and weight of the person
   /// should be  lesseer than the person below
   /// </summary>
    public class CircusTower
    {
        public ArrayList MaxHeightSeequence(Person[] persons)
        {
            // sort the array by Height
            Array.Sort(persons);

            var longestSeequence = new ArrayList();
            var possibleSeequences = new List<ArrayList>();

            for( int i = 0; i < persons.Length; i++)
            {
                var longestAt = BestSequence(possibleSeequences, persons[i], i);
                possibleSeequences.Add(longestAt);

                longestSeequence = Max(longestSeequence, longestAt);
            }

            return longestSeequence;
        }

        private ArrayList BestSequence(List<ArrayList> solutions, Person person, int i)
        {
            var best = new ArrayList();

            if(solutions.Count == 0)
            {
                return new ArrayList()
                {
                    person
                };
            }

           for(int j = 0; j < i; j++)
            {
                var current = solutions[j];
               if(CanAppend(current, person))
                {
                 
                    best = Max(best, current);
                }

                
            }

            best.Add(person);
            return (ArrayList)best.Clone();
        }

        private ArrayList Max(ArrayList best, ArrayList current)
        {
            if (best.Count > current.Count)
                return best;
            else return current;
        }

        private bool CanAppend(ArrayList persons, Person person)
        {
            return ((Person)persons[persons.Count - 1]).Weight < person.Weight;
        }
    }

    public class Person: IComparable<Person>
    {
        public int Height { get; set; }
        public int Weight { get; set; }

        public Person(int height, int weight)
        {
            this.Height = height;
            this.Weight = weight;
                
        }
        public int CompareTo(Person other)
        {
            return this.Height - other.Height;
        }
    }
}
