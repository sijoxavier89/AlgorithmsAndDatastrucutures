using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems.Graph
{
//    Given an m x n 2D binary grid grid which represents a map of '1's(land) and '0's(water), return the number of islands.

//  An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.

//  Example 1:

//  Input: grid = [
  
//    ["1", "1", "1", "1", "0"],
//    ["1","1","0","1","0"],
//    ["1","1","0","0","0"],
//    ["0","0","0","0","0"]
// ]
//Output: 1
    public class IslandCountLC
    {
        bool[,] marked;
        int count; // number of connected components
        int row;
        int col;
        public int NumIslands(char[][] grid)
        {

            row = grid.Length;
            col = grid[0].Length;
            marked = new bool[row, col];
            for (int m = 0; m < row; m++)
            {
                for (int n = 0; n < col; n++)
                {
                    if (!marked[m, n])
                    {
                        if (grid[m][n] == '1')
                        {
                            Dfs(grid, m, n);
                            count++;
                        }
                    }
                }
            }

            return count;

        }

        private void Dfs(char[][] grid, int m, int n)
        {

            if (m < 0 || m > row - 1 || n < 0 || n > col - 1)
            {
                return;
            }

            if (grid[m][n] != '1')
                return;

            // if already visited 
            if (marked[m, n]) return;

            marked[m, n] = true;


            Dfs(grid, m - 1, n);

            Dfs(grid, m, n - 1);

            Dfs(grid, m + 1, n);

            Dfs(grid, m, n + 1);

        }
    }
}
