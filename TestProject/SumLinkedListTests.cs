using PracticeProblems;
using PracticeProblems.HelperDS;
using Xunit;

namespace TestProject
{
    public class SumLinkedListTests
    {

        [Fact]
        public void Sum_Success()
        {
            Node n1 = new Node(6);
            n1.Next = new Node(1);
            n1.Next.Next = new Node(7);

            Node n2 = new Node(2);
            n2.Next = new Node(9);
            n2.Next.Next = new Node(5);

            var result = SumLinkedList.Sum(n1, n2);

            Assert.Equal(9, result.Value);
            Assert.Equal(1, result.Next.Value);
            Assert.Equal(2, result.Next.Next.Value);
        }
    }
}
