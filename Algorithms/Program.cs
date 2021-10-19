using PracticeProblems.DP;
using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var test = new LongestPalindrom();
            var result = test.LongestPalindrome("abasab");

            Console.Write(result);
            
        }
    }
}
