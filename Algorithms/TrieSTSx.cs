using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// Trie data structure for string key based 
    /// operation
    /// </summary>
    public class TrieSTSx<T>
    {
        Node root;

        private const int R = 256;
        private int n;
        class Node
        {
            public T value;
            public Node[] next;

            public Node()
            {
                next = new Node[R];
            }
        }
        public void Put(string key, T value)
        {
           root = Put(root, key, value, 0);
        }

        private Node Put(Node x, string key, T value, int d)
        {
            if(x == null)
            {
                x = new Node();
            }

            // when key completly inserted return the 
            // node // setting to previous node.next = x
            if(d == key.Length)
            {
                x.value = value;
                n = n + 1;
                return x;
            }

            char c = key[d];
            x.next[c] = Put(x.next[c], key, value, d + 1);
           
            return x; // return the node
        }
        public T Get(string key)
        {
            var x = Get(root, key, 0);
            if (x == null) return default;
            return x.value;
        }

        private Node Get(Node x, string key, int d)
        {
            if (x == null)
                return null;
             
            if(d == key.Length)
            {
                return x;
            }

            char c = key[d];

            return Get(x.next[c], key, d + 1);
        }

        public int Size()
        {
            return n;
        }

        
    }
}
