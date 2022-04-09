using System.Collections.Generic;

namespace DynamicProgramming.RecursionMemo
{
    public class SumOfNum
    {
        public static List<List<int>>  HowSumP(int target, int[] digits)
        {
            return HowSum(target, digits);
        }

        // TODO: remove duplicates from the result 
        private static List<List<int>> HowSum(int target, int[] digits, Dictionary<int, List<List<int>>> map = null)
        {
            if (map != null && map.ContainsKey(target))
                return map[target];

            if(target < 0)
            {
                return null;
            }
            if(target == 0)
            {
                List<List<int>> list = new List<List<int>>();
                list.Add(new List<int>());
                return list;
            }

            List<List<int>> subList = null;
            List<List<int>> final = new List<List<int>>();

            foreach(int num in digits)
            {
                
                 subList = HowSum(target - num, digits, map);
                if (subList != null && subList.Count > 0)
                {
                    // add entry for each branch
                    foreach (var entry in subList)
                    {
                        entry.Add(num);
                    }

                   
                    final.Add(subList[0]);
                }
            }

            if (map == null) map = new Dictionary<int, List<List<int>>>();
            if(!map.ContainsKey(target))
            map.Add(target, final);
            return final;
        }

        public static List<int> BestSum(int target, int[] digits)
        {
            return BestSum(target, digits, new Dictionary<int, List<int>>());
        }
        private static List<int> BestSum(int target, int[] digits, Dictionary<int, List<int>> map = null)
        {
            if (map != null && map.ContainsKey(target))
                return map[target];

            if (target < 0)
            {
                return null;
            }
            if (target == 0)
            {
                List<int> list = new List<int>();           
                return list;
            }

            List<int> shortest = null;
           

            foreach (int num in digits)
            {

                List<int> subList = BestSum(target - num, digits, map);
                if (subList != null)
                {
                    // add entry for each branch
                    subList.Add(num);



                    if (shortest == null || subList.Count < shortest.Count)
                    {
                        shortest = subList;
                    }
                }
            }

            if (map == null) map = new Dictionary<int, List<int>>();
            if (!map.ContainsKey(target))
                map.Add(target, shortest);

            return shortest;
        }
    }
}
