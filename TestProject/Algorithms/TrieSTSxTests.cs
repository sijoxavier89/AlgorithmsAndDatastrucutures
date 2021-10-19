using Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject.Algorithms
{
   public class TrieSTSxTests
    {
        TrieSTSx<int> trieSTsx;

        public TrieSTSxTests()
        {
            trieSTsx = new TrieSTSx<int>();
        }

        [Fact]
        public void Get_Returns_value()
        {
            // Arrange
            var keys = new string[]
            {
                "she",
                "sells",
                "sea",
                "shells",
                "by",
                "the",
                "sea"
            };

            // Act
            int value = 0;
            foreach(string s in keys)
            {
                trieSTsx.Put(s, value);
                value ++;
            }

            var size = trieSTsx.Size();

            var valueResult = trieSTsx.Get("the");

            // Assert
            Assert.Equal(7, size);
            Assert.Equal(5, valueResult);
        }
    }
}
