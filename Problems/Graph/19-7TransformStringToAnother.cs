using System;
using System.Collections.Generic;

namespace Problems.Graph
{
    /// <summary>
    /// to find the Production sequence 
    /// given source s and target t and a dictionary D
    /// s = cat, t = dog D = {dag, dot, dog, cot}
    /// 
    /// <cot, dot> is a Product sequence of cat  -> dog
    /// </summary>
   public  class TransformStringToAnother
    {
   
        Dictionary<string, int> distTo;
        HashSet<string> wordSet;
        public int SeqLength(string s, string t, List<string> words)
        {
           
            distTo = new Dictionary<string, int>();
            wordSet = new HashSet<string>();
            foreach (string word in words)
            {
               
                distTo.Add(word, 0);
                wordSet.Add(word);
            }

           
            if (!distTo.ContainsKey(s)) distTo.Add(s, 0);
            return CheckSequence(s, t, words);
        }

        /// <summary>
        /// do BFS for sequence
        /// </summary>
        /// <returns></returns>
        private int CheckSequence(string source , string dest, List<string> words)
        {
          
            Queue<string> q = new Queue<string>();

            q.Enqueue(source);
            if (wordSet.Contains(source)) wordSet.Remove(source);
            int len = 0;

            while(q.Count > 0)
            {
                string s = q.Dequeue();
                
                if (s == dest) return distTo[dest] + 1;
               foreach(string word in wordSet)
               {
                    if(IsNextWord(s, word))
                    {
                        q.Enqueue(word);
                        distTo[word] =  distTo[s] + 1;
                        wordSet.Remove(word);
                    }
               }

                len ++;
            }

            return -1;
        }

        /// <summary>
        /// check the given words different only in sigle char
        /// TODO: modify logic to check the word is differ by only one char in terms of character and order
        /// </summary>
        /// <param name="source"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        private bool IsNextWord(string source, string word)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
           
            foreach(char c in source)
            {
                if (!map.ContainsKey(c))
                    map.Add(c, 1);
                else
                    map[c] = map[c] + 1;
            }

            int diff = 0;
            foreach (char c in word)
            {
                if (!map.ContainsKey(c) || map[c] <= 0)
                    diff ++;
                else
                {
                    map[c] = map[c] - 1;
                }
            }

            return diff == 1;
        }
    }
}
