using DynamicProgramming.RecursionMemo;
using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("All Construct");
             var output = WordConstruct.AllConstruct("skateboard", new string[] { "skate", "board", "sk", "ate", "br" });
            var output1 = WordConstruct.AllConstruct("purple", new string[] { "purp", "p", "pu", "ur", "le" , "purpl"});
            var outputTab = Tabulation.WordConstruct.AllConstruct("purple", new string[] { "purp", "p", "pu", "ur", "le", "purpl" });
            var howSum = SumOfNum.BestSum(7, new int[] { 5, 2, 7, 3, 4 });

        }
         
     
    }
}

