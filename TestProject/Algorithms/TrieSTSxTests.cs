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
            Initialize();
        }

        private void Initialize()
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
                "shore"
            };

            // Act
            int value = 1;
            foreach (string s in keys)
            {
                trieSTsx.Put(s, value);
                value++;
            }

        }

        [Fact]
        public void Get_Returns_value()
        {
           
            var size = trieSTsx.Size();

            var valueResult = trieSTsx.Get("the");

            // Assert
            Assert.Equal(7, size);
            Assert.Equal(6, valueResult);
        }

        [Fact]
        public void Collect_ReturnAllKeys()
        {
            var keys = trieSTsx.Collect().ToList();

            int count = keys.Count;

            Assert.Equal(7, count);
        }
    }
}
