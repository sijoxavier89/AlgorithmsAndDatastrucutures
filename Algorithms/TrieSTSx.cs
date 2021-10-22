using System.Collections.Generic;

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
            public object value;
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
                x.value = (T)value;
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
            return (T)x.value;
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

        public IEnumerable<string> Collect()
        {
            Queue<string> queue = new Queue<string>();
            Collect(root, "", queue);
            return queue;
        }

        public IEnumerable<string> KeysWithPrefix(string prefix)
        {
            Queue<string> queue = new Queue<string>();

            Node x = Get(root, prefix, 0);

            Collect(x, prefix, queue);

            return queue;
        }

        private void Collect(Node x, string prefix, Queue<string> queue)
        {
            if(x == null)
            {
                return;
            }

            if(x.value != null)
            {
                queue.Enqueue(prefix);
            }

            for(char c = '0'; c < R; c++)
            {
                Collect(x.next[c], prefix + c, queue);
            }
        }
        
    }
}
