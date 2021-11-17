using Algorithms;
using System;
using System.IO;
using Xunit;
namespace TestProject.Algorithms
{
    public class SuffixArrayTests
    {
        [Fact]
        public void GetLongestRepeatingSubstring()
        {
            string path = @"C:\Users\sijox\source\repos\AlgorithmsAndDatastrucutures\TestProject\TestData\tinyTale.txt";
            var text = File.ReadAllText(path).Trim();

            int N = text.Length;

            SuffixArray sa = new SuffixArray(text);

            string lrs = "";

            for(int i=1; i < N; i++)
            {
                int lenth = sa.Lcp(i);

                if(lenth > lrs.Length)
                {
                    lrs = sa.Select(i).Substring(0, lenth);
                }
            }

            Console.WriteLine(lrs);

            // Assert

            Assert.Equal("st of times it was the", lrs);

        }
    }
}
