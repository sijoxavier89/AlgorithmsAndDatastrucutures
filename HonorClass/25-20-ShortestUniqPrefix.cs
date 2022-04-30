namespace HonorClass
{
    /// <summary>
    /// given a query and array of words, find the shortest unique prefix of a query 
    /// that is not in the list of the string
    /// 
    /// query - "cat"  words - ["cut","dog","be"];  Ans: "ca"
    /// query - "cat" words - ["cut", "dog", "car", "be"];  Ans: "cat"
    /// </summary>
    public class ShortestUniqPrefix
    {
        Node root;
      
        public string Find(string query, string[] words) 
        {
            // insert to TST Trie
            foreach(string word in words)
            {
                Put(word);
            }

            string prefix = LongestPrefix(query);

            if(prefix.Length < query.Length)
            {
                return query.Substring(0, prefix.Length + 1);
            }
            return "";
        }

        private void Put(string word)
        {
            root = Put(root, word, 0);
        }

        private Node Put(Node x, string word, int d)
        {
            char c = word[d];
            if(x == null)
            {
                x = new Node();
                x.c = c;
            }

            if(c < x.c)
            {
                x.left = Put(x.left, word, d);
            }
            else if(c > x.c)
            {
                x.right = Put(x.right, word, d);
            }
            else if(d < word.Length - 1)
            {
                x.mid = Put(x.mid, word, d + 1);
            }

            return x;
        }

        // Find the longest prefix of the query 
        // in the words
        private string LongestPrefix(string query)
        {
            int len = query.Length;
            Node current = root;

            int prefixLen = 0;
            while(current != null)
            {
                if(query[prefixLen] < current.c)
                {
                    current = current.left;
                }
                else if( query[prefixLen] > current.c)
                {
                    current = current.right;
                }
                else
                {
                    prefixLen++;
                    current = current.mid;
                }
            }

            return query.Substring(0, prefixLen);
        }
    }

    class Node
    {
        public char c { get; set; }
        public Node left { get; set; }
        public Node mid { get; set; }
        public Node right { get; set; }
    }
}
