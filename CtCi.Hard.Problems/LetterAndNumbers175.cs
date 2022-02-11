using System.Collections.Generic;

namespace CtCi.Hard.Problems
{
    public class LetterAndNumbers175
    {
        public static  string[] FindLongestArray(string[] input)
        {
            if (input.Length < 2) return null;

            var delta = FindDelta(input);
            var match = FindLongestMatch(delta);

            return Extract(match[0] + 1, match[1], input);
        }

        /// <summary>
        /// create a delta array with difference in number if letters and Numbers
        /// encountered so  far
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static int[] FindDelta(string[] input)
        {
            int len = input.Length;
            int delta = 0;
            int[] deltaList = new int[len];

            for(int i = 0; i < len; i++)
            {
              
              if(int.TryParse(input[i], out int result))
                {
                    delta--;
                }
                else
                {
                    delta++;
                }

                deltaList[i] = delta;
            }

            return deltaList;
        }

        /// <summary>
        /// find pair of index with maximum distance
        /// </summary>
        /// <param name="delta"></param>
        /// <returns></returns>
        private static int[] FindLongestMatch(int[] delta)
        {
            int[] match = new int[2];
            Dictionary<int, int> map = new Dictionary<int, int>();

            map.Add(0, -1);
            int distance;
            int longest;
            for(int i = 0; i < delta.Length; i++)
            {
                if(!map.ContainsKey(delta[i]))
                {
                    map.Add(delta[i], i);
                }
                else
                {
                    distance = i - map[delta[i]];
                    longest = match[1] - match[0]; // earlier pair with max distance

                    if(distance > longest)
                    {
                        match[0] = map[delta[i]];
                        match[1] = i;
                    }
                }
            }

            return match;
        }

        private static string[] Extract(int start, int end, string[] input)
        {
            string[] longest = new string[end - start + 1];
            int index = 0;
            for( int i = start; i <= end; i++)
            {
                longest[index++] = input[i]; 
            }

            return longest;
        }
    }
}
