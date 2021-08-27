using PracticeProblems;
using System;
using Xunit;

namespace TestProject
{
    public class BinaryTreeProblemTests
    {
        BinaryTreeProblem binaryTreeProblem;
        public BinaryTreeProblemTests()
        {
            binaryTreeProblem = new BinaryTreeProblem();
        }
        [Fact]
        public void Test_CreateLinkedListByDepth()
        {
            var root = new TreeNode(0);
            root.Left = new TreeNode(1);
            root.Right = new TreeNode(2);

            var result = binaryTreeProblem.CreateLinkedListByDepth(root);

            Assert.True(result.Count > 0);
        }
    }
}
