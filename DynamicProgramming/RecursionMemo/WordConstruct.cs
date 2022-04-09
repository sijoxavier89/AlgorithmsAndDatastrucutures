using System.Collections.Generic;

namespace DynamicProgramming.RecursionMemo
{
    public class WordConstruct
    {
        public static List<string> BestConstruct(string target, string[] wordDict, Dictionary<string, List<string>> map = null)
        {
            if (map != null && map.ContainsKey(target))
            {
                return map[target];
            }
            if (string.IsNullOrEmpty(target))
            {
                return new List<string>();
            }

            List<string> best = null;

            foreach (string word in wordDict)
            {

                if (target.StartsWith(word))
                {
                    string newTarget = target.Substring(word.Length);

                    List<string> subList = BestConstruct(newTarget, wordDict, map);
                    if (subList != null)
                    {
                        subList.Add(word);

                        if (best == null || subList.Count < best.Count)
                        {
                            best = subList;
                        }
                    }
                }

            }

            if (map == null)
            {
                map = new Dictionary<string, List<string>>();
            }

            if (!map.ContainsKey(target))
                map.Add(target, best);
            return best;
        }

        private static IEnumerable<IList<string>> AllConstruct(string target, string[] wordDict, Dictionary<string, List<List<string>>> map = null)
        {
            if (map != null && map.ContainsKey(target))
            {
                return map[target];
            }
            if (string.IsNullOrEmpty(target))
            {
                var newList = new List<List<string>>();
                newList.Add(new List<string>());
                return newList;
            }

            List<List<string>> final = new List<List<string>>();
            List<List<string>> subList;
            foreach (string word in wordDict)
            {

                if (target.StartsWith(word))
                {
                    string newTarget = target.Substring(word.Length);

                    subList = (List<List<string>>)AllConstruct(newTarget, wordDict, map);
                    AddToSubList(subList, word);
                    if (subList.Count > 0)
                        final.Add(subList[0]);
                }

            }

            if (map == null)
            {
                map = new Dictionary<string, List<List<string>>>();
            }

            if (!map.ContainsKey(target))
                map.Add(target, final);
            return final;
        }

        private static void AddToSubList(List<List<string>> subList, string word)
        {
            foreach (var entry in subList)
            {
                entry.Add(word);
            }
        }



    }
}
