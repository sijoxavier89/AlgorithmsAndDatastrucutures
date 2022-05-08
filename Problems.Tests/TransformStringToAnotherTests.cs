using Problems.Graph;
using System.Collections.Generic;
using Xunit;

namespace Problems.Tests
{
    public class TransformStringToAnotherTests
    {

        [Fact]
        public void TestSeqSuccess()
        {
            List<string> words = new List<string>()
            {
                "hot","dot","dog","lot","log","cog"
            };

            string s = "hit";
            string t = "cog";

            int result = new TransformStringToAnother().SeqLength(s, t, words);

            Assert.Equal(5, result);
        }

        [Fact]
        public void TestSeqSuccess2()
        {
            List<string> words = new List<string>()
            {
                "hot", "dog", "dot"
            };

            string s = "hot";
            string t = "dog";

            int result = new TransformStringToAnother().SeqLength(s, t, words);

            Assert.Equal(3, result);
        }

        [Fact]
        public void TestSeqSuccess_leet_code()
        {
            List<string> words = new List<string>()
            {
                "lest","leet","lose","code","lode","robe","lost"
            };

            string s = "leet";
            string t = "code";

            int result = new TransformStringToAnother().SeqLength(s, t, words);

            Assert.Equal(6, result);
        }
    }
}
