using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems
{
    /// <summary>
    /// 1 0 1 0
    /// 1 0 1 0
    /// 0 1 0 1
    /// 1 0 1 1
    /// 
    /// grid[3][1] is an island
    /// 
    /// count is 1
    /// </summary>
    public class IslandCount
    {
        bool[,] marked;
        int count; // number of connected components
        int nonIsland;
        public int Count(bool[,] grid)
        {
            marked = new bool[grid.GetLength(0), grid.GetLength(1)];
            for(int m = 1; m < grid.GetLength(0) - 1; m++)
            {
                for(int n=1; n < grid.GetLength(1) - 1; n++)
                {
                    if (!marked[m, n])
                    {
                        Dfs(grid, m, n);
                        if(grid[m,n])
                        count ++;
                    }
                }
            }

            return count - nonIsland;
        }

        private void Dfs(bool[,] grid, int m, int n)
        {
            if (!grid[m,n])
                return;
           
            marked[m,n] = true;

            // if the search reaches the boundary 
            // the box is not part of the island
            if(m == 0 || n == 0 || m == grid.GetLength(0) - 1 || n == grid.GetLength(1) - 1 )
            {
                nonIsland ++;
                return;
            }


            if (grid[m - 1, n])
            {
                if(!marked[m-1,n])
                Dfs(grid, m - 1, n);
            }

            if (grid[m, n - 1])
            {
                if (!marked[m, n-1])
                    Dfs(grid, m, n - 1);
            }

            if (grid[m + 1, n])
            {
                if (!marked[m+1, n])
                    Dfs(grid, m + 1, n);
            }

            if (grid[m, n + 1])
            {
                if (!marked[m, n+1])
                    Dfs(grid, m, n + 1);
            }
            

        }
    }
}
