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

        public IEnumerable<string> Collect()
        {
            Queue<string> queue = new Queue<string>();
            KeysWithPrefix(root, "", 0, queue);
            return queue;
        }

        public IEnumerable<string> KeysWithPrefix(string prefix)
        {
            Queue<string> queue = new Queue<string>();

            Node x = Get(root, prefix, 0);

            KeysWithPrefix(x, prefix, 0, queue);

            return queue;
        }

        private void KeysWithPrefix(Node x, string prefix, int d, Queue<string> queue)
        {
            if(x == null)
            {
                return;
            }

            if(x.value != null)
            {
                queue.Enqueue(prefix);
            }

            char c = prefix[d];

            for(int i =0; i < R; i++)
            {
                KeysWithPrefix(x.next[c], prefix + c, d + 1, queue);
            }
        }
        
    }
}
