using Algorithms;
using System;
using System.Collections.Generic;

namespace PracticeProblems.DynamicProgram
{
    /**************************
     * Huffman encoding create a tree of alphabets 
     * with minimum average code length
     * 
     * it uses greedy algorithm approach to add each node to 
     * the tree which increase the average leaf depth by minimum 
     * possible value
     * 
     * 
     * ************************/
    public class HuffmanEncoding
    {
        MinPQSx<Node> pq;
        Dictionary<string, int> codes;
        public Node GetOptimalTree(Dictionary<string, int> codes)
        {
            this.codes = codes;
            int count = codes.Count;
            pq = new MinPQSx<Node>(count);
            InitializePq();
            return Encode();
        }

        /// <summary>
        /// initialize pq with each alpbhabet as a single node with no
        /// child nodes
        /// </summary>
        private void InitializePq()
        {
            foreach (var kv in codes)
            {
                pq.Insert(new Node(kv.Key, kv.Value));
            }
        }

        private Node Encode()
        {
         
            while(pq.Size() > 1)
            {
                var t1 = pq.DeleteMin();
                var t2 = pq.DeleteMin();// second minimum

                var t3 = new Node(t1.Key + "-" + t2.Key, t1.P + t2.P, t1, t2);

                pq.Insert(t3); // add to the pq

            }

            return pq.DeleteMin();
        }
    }
    public class Node: IComparable<Node>
    {
        public Node(string key,int p, Node left = null, Node right = null)
        {
            P = p;
            Left = left;
            Right = right;
            Key = key;
        }

        public int P { get; }
        public Node Left { get; }
        public Node Right { get; }
        public string Key { get; set; }

      
        public int CompareTo(Node other)
        {
            return this.P - other.P;
        }
    }
}
