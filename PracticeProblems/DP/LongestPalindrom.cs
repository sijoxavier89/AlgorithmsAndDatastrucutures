using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems.DP
{
    /// <summary>
    /// yet to complete
    /// </summary>
    public class LongestPalindrom
    {
        public string LongestPalindrome(string s)
        {

            // edge case
            if (s.Length == 1)
                return s;


            int maxLen = 0;
            int word = 0;
            string palindrom = string.Empty;

            for (int k = 0; k < s.Length; k++)
            {
                for (int i = k; i < s.Length; i++)
                {
                   // check palindrom
                    if(isPlai(s,k,i) && maxLen < i-k+1)
                    {
                        maxLen = i - k + 1;
                        word = k;
                    }

                    
                }
            }


            return s.Substring(word, word+maxLen-1);

        }

        private bool isPlai(string word, int start, int end)
        {

            while(start < end) {
                if (word[start++] != word[end--])
                {
                    return false;
                }
            }
            return true;
        }

    }
}
