using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems.DP
{
    public class StringPermuations
    {
        /// <summary>
        /// Give a string contain non unique chars print all permutation of the string
        /// Output should not contains duplicates
        /// Approach
        /// P(a->2, b->3,c->4) = a+P(a->1,b=>3, c->4)+  b+ P(a->2, b-> 2, c->4) + c+P(a->2, b->3, c->3)
        /// repeat the step untill all char count is 0
        /// </summary>
        /// <param name="s"></param>
        public void PrintPermutations(string s)
        {
            List<string> result = new List<string>();
            string prefix = "";
            var map = CreateMap(s);
            int remaining = s.Length;
            Permutation(map, prefix, remaining, result);

            PrintList(result);
        }

        private void Permutation(Dictionary<char, int> map, string prefix, int remaining, List<string> result)
        {
            if(remaining == 0)
            {
                result.Add(prefix);
                return;
            }

            foreach(char c in map.Keys)
            {
                int count = map[c];

                if(count > 0)
                {
                    map[c] = count - 1;
                    Permutation(map, prefix + c, remaining-1, result);
                    map[c] = count;
                }
            }
        }

        /// <summary>
        /// create map with each character and the count of char in the string
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private  Dictionary<char,int> CreateMap(string word)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();

            foreach(char c in word)
            {
                int i = 0;
                map.TryGetValue(c, out i);
                if(i == 0)
                {
                    map.Add(c, 1);
                }
                else
                {
                    map.Add(c, i+1);
                }
            }

            return map;
        }

        private void PrintList(List<string> list)
        {
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }

}
