using System.Collections.Generic;

namespace CtCi.Moderate.Problems
{
    /// <summary>
    /// Find all pairs of intigers which sums to a specified value
    /// </summary>
    public class PairWithSum1624
    {
        public static List<int[]> GetPairsWithSum(int[] nums, int target)
        {
            Dictionary<int, int> lookup = new Dictionary<int, int>();
            List<int[]> result = new List<int[]>();

            for(int i=0; i < nums.Length; i++)
            {
                if(lookup.ContainsKey(target - nums[i]) && (lookup[target - nums[i]] > 0))
                {
                    result.Add(new int[]
                    {
                        nums[i],
                        target - nums[i]
                    });

                    lookup[target - nums[i]] -= 1;
                }
                else if(!lookup.ContainsKey(nums[i]))
                {
                    lookup.Add(nums[i], 1);
                }
                else
                {
                    lookup[nums[i]] += 1;
                }
            }

            return result;
        }
    }
}
