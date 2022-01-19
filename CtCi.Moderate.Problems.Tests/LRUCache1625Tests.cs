using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CtCi.Moderate.Problems.Tests
{
    public class LRUCache1625Tests
    {
        [Fact]
        public void TestLRUCache()
        {
            // Arrange
            int maxSize = 3;

            // Act
            var cache = new LRUCache1625<int, string>(maxSize);
            // add 3 values
            cache.Insert(1, "Apple");
            cache.Insert(2, "Orange");
            cache.Insert(3, "Blueberry");

            // Access 1, 2
            Assert.Equal("Apple", cache.Get(1));
            Assert.Equal("Orange", cache.Get(2));

            // insert a new item
            cache.Insert(4, "Grapes");

            // this should remove item 3 from cache and add key 4

            Assert.Null(cache.Get(3));
            Assert.Equal("Grapes", cache.Get(4));

        }
    }
}
