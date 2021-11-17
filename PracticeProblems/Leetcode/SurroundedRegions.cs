using System.Collections.Generic;

namespace PracticeProblems.Leetcode
{
    /// <summary>
    /// https://leetcode.com/problems/surrounded-regions/
    /// Input: board = [["X","X","X","X"],["X","O","O","X"],["X","X","O","X"],["X","O","X","X"]]
    //   Output: [["X","X","X","X"],["X","X","X","X"],["X","X","X","X"],["X","O","X","X"]]
    //   Explanation: Surrounded regions should not be on the border, which means that any 'O' on the border of the board are not flipped to 'X'.
    //   Any 'O' that is not on the border and it is not connected to an 'O' on the border will be flipped to 'X'.
    //   Two cells are connected if they are adjacent cells connected horizontally or vertically.
    /// </summary>
    class SurroundedRegions
    {
        bool[,] marked;
        int row, col;
        public void Solve(char[,] board)
        {
            row = board.GetLength(0);
            col = board.GetLength(1);

            if (board.GetLength(0) < 3 || board.GetLength(1) < 3)
                return;
            marked = new bool[row, col];
            for (int i = 1; i < row - 1; i++)
            {
                for (int j = 1; j < col - 1; j++)
                {

                    if (board[i,j] == 'O')
                    {

                        if (!CheckBoundary(board, i, j))
                        {
                            board[i,j] = 'X';
                        }
                        else
                        {
                            marked = new bool[row, col];
                        }
                    }
                }
            }

        }

        private bool CheckBoundary(char[,] board, int i, int j)
        {
            if ((j > col - 1) || j < 0 || (i < 0) || (i > row - 1)) return false;
            if (board[i,j] == 'X') return false;
            if (marked[i, j]) return false;
            marked[i, j] = true;
            if ((j == col - 1) || j == 0 || (i == 0) || (i == row - 1))
            {
                if (board[i,j] == 'O') return true; // connected to boudary O
            }



            return (CheckBoundary(board, i, j + 1) || CheckBoundary(board, i, j - 1) || CheckBoundary(board, i - 1, j) || CheckBoundary(board, i + 1, j));



        }


    }
}
