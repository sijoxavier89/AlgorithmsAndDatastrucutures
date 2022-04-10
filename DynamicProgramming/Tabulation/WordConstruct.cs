using System.Collections.Generic;
using System.Linq;

namespace DynamicProgramming.Tabulation
{
    public class WordConstruct
    {
        public static List<List<string>> AllConstruct(string target, string[] wordBank)
        {
            List<List<string>>[] result = new List<List<string>>[target.Length+1];
            result[0] = new List<List<string>>() { new List<string>()};

            for(int i = 0; i < wordBank.Length; i++)
            {
                foreach(string word in wordBank)
                {
                    if((word.Length <= target.Length- i) && word == target.Substring(i, word.Length))
                    {
                        AddToResult(i + word.Length, result, word, i);
                    }
                }
            }

            return result[target.Length];
        }


        private static void AddToResult(int i, List<List<string>>[] result, string word, int prev)
        {
            
            // add prev entry
            if (result[prev] != null) // if the current index is null , it means no matching words found till the current index
            {
               if(result[i] == null)
                result[i] = new List<List<string>>();
                List<List<string>> temp = new List<List<string>>() ;
                temp = Copy(result[prev], temp);

                // add prev entry
                foreach (var item in temp)
                {
                    var newList = item;
                    newList.Add(word);
                    result[i].Add(newList);
                }

                
            }
        }

        private static List<List<string>> Copy(List<List<string>> from ,  List<List<string>> to)
        {
            to = new List<List<string>>();
            foreach (var item in from)
            {
                var newItem = item;
                var newV = new List<string>();
                foreach(var value in newItem)
                {
                    newV.Add(value);
                }

                to.Add(newV);
            }

            return to;
        }
    }
}
