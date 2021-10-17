using PracticeProblems.DP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject.DP
{
    public class StringPermutationsTests
    {
        StringPermuations testclass;
        public StringPermutationsTests()
        {
            testclass = new StringPermuations();
        }

        [Fact]
        public void PrintPermutation_success()
        {
            testclass.PrintPermutations("sijo");
        }
    }
}
