using System.Collections.Generic;

namespace CtCi.Moderate.Problems
{
   public class DivingPlanks
    {
        public IEnumerable<int> Distances(int shorter, int longer, int total)
        {
            HashSet<int> result = new HashSet<int>();
            HashSet<string> visited = new HashSet<string>();
            GetLen(total, 0, shorter, longer, result, visited);

            return result;
            
        }

        private void GetLen(int total, int sum, int shorter, int longer,  HashSet<int> result, HashSet<string> visited)
        {
            // base case
            if (total == 0) result.Add(sum);
            string key = total.ToString() + "-" + sum.ToString();
            if (visited.Contains(key)) return;

            GetLen(total - 1, sum + shorter, shorter, longer, result, visited);
            GetLen(total - 1, sum + longer, shorter, longer, result, visited);
            visited.Add(key);

        }
    }
}
