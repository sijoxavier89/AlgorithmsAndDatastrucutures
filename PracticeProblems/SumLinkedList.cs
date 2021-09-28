using PracticeProblems.HelperDS;

namespace PracticeProblems
{
    public class SumLinkedList
    {
        public static Node Sum(Node head1, Node head2)
        {
            var reverseNode1 = Reverse(head1);
            var reverseNode2 = Reverse(head2);

            var sum = CalculateSum(reverseNode1, reverseNode2);

            return sum;
        }

        private static Node Reverse(Node head)
        {
            Node tail = null;
            Node current = null;
            while(head != null)
            {
                if (tail == null)
                {
                    tail = new Node(head.Value);
                }
                else
                {
                    current = new Node(head.Value);
                    current.Next = tail;
                    tail = current;
                }
                head = head.Next;
           
            }

            head = current;
            return head;
        }

        private static Node CalculateSum(Node n1, Node n2)
        {
            Node result = null;

            int sum, reminder = 0;

            while(n1 != null && n2 != null)
            {
                var num2 = n2 == null ? 0 : n2.Value;
                var num1 = n1 == null ? 0 : n1.Value;
                sum = (num2 + num1+ reminder) % 10;
                reminder = (num2 + num1 + reminder) / 10;

                if (result == null)
                {
                    result = new Node(sum);
                }
                else
                {
                    var newNode = new Node(sum);
                    newNode.Next = result;
                    result = newNode;
                }

                n1 = n1.Next;
                n2 = n2.Next;
            }
            // assign last reminder to a new node
            if(reminder != 0)
            {
                var newNode = new Node(reminder);
                newNode.Next = result;
                result = newNode;
            }
            return result;

        }
    }
}
