using Xunit;

namespace HonorClass.Tests
{
    public class ShortestUniquePrefixTests
    {
        [Fact]
        public void PrefixTest()
        {
            string query = "cat";
            string[] words = new string[] { "cut", "be", "dog" };
            string result = new ShortestUniqPrefix().Find(query, words);

            Assert.Equal("ca", result);
        }

       [Fact]
        public void PrefixTest_2()
        {
            string query = "cat";
            string[] words = new string[] { "cut", "be", "dog", "car" };
            string result = new ShortestUniqPrefix().Find(query, words);

            Assert.Equal("cat", result);
        }
    }
}
