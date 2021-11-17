using PracticeProblems.Leetcode;
using System;

namespace PracticeProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            SurroundedRegions sg = new SurroundedRegions();

            var input = new char[,]
            {
                { 'X', 'O', 'X', 'O', 'X', 'O' },
                { 'O', 'X', 'O', 'X', 'O', 'X' },
                { 'X', 'O', 'X', 'O', 'X', 'O' },
                { 'O', 'X', 'O', 'X', 'O', 'X' }
            };

            var input1 = new char[,]
           {
                { 'X', 'X', 'X', 'X'},
                { 'X', 'O', 'O', 'X'},
                { 'X', 'X', 'O', 'X'},
                { 'X', 'O', 'X', 'X'}
           };
            sg.Solve(input);

            for(int i =0; i < input.GetLength(0); i++)
            {
                for(int j =0; j < input.GetLength(1); j++)
                {
                    Console.Write(input[i, j]);
                    Console.Write(" ");

                }
                Console.WriteLine();
            }
        }
    }
}
