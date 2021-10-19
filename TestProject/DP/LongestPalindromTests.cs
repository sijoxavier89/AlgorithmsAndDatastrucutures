using PracticeProblems.DP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject.DP
{
    public class LongestPalindromTests
    {
        LongestPalindrom test;
        public LongestPalindromTests()
        {
            test = new LongestPalindrom();
        }

        [Theory]
        [InlineData("abmalayalamcd")]
        public void PalindromTests(string word)
        {
            // 
            var result = test.LongestPalindrome(word);

            Assert.Equal("malayalam", result);
        }
    }
}
