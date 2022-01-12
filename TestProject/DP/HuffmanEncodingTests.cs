using PracticeProblems.DynamicProgram;
using System.Collections.Generic;
using Xunit;

namespace TestProject.DP
{
    public class HuffmanEncodingTests
    {
        HuffmanEncoding huffmanEncoding;
        public HuffmanEncodingTests()
        {
            huffmanEncoding = new HuffmanEncoding();
        }

        [Fact]
        public void VerifyEncodedTree()
        {
            var input = new Dictionary<string, int>()
            {
                {"A", 3 },
                {"B", 2 },
                {"C", 6 },
                {"D", 8 },
                {"E", 2 },
                {"F", 6 },
            };

            // act
            var encodedTree = huffmanEncoding.GetOptimalTree(input);
            var codeList = ExtractEncodedTree(encodedTree);
            // Assert
            Assert.Equal("100", codeList["A"]);
        }

        /// <summary>
        /// Traverse the tree and find the 
        /// binary code corresponds to the albphabet
        /// create a dictionary Alphabet as key and Value 
        /// as binary code
        /// </summary>
        /// <param name="root"></param>
        /// <returns>encoded collection</returns>
        private Dictionary<string, string> ExtractEncodedTree(Node root)
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            Dfs(root, "", list);

            return list;
        }

        private void Dfs(Node root, string code, Dictionary<string, string> list)
        {
            if (root == null) return;
            if((root.Left == null) && (root.Right == null))
            {
                list.Add(root.Key, code);
            }

            if(root.Left != null)
            {
                string newcode = code + "0";
                Dfs(root.Left, newcode, list);
            }

            if (root.Right != null)
            {
                string newcode = code + "1";
                Dfs(root.Right, newcode, list);
            }

        }
    }
}
