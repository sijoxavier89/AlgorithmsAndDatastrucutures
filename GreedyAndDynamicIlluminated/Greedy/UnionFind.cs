namespace GreedyAndDynamicIlluminated.Greedy
{
    public class UnionFind
    {
        int[] id;
        int[] size;
        public UnionFind(int V)
        {
            id = new int[V];
            size = new int[V];
            // initialize root to self
            for(int i = 0; i < id.Length; i++)
            {
                size[i] = 1;
                id[i] = i;
            }
        }

       
        /// <summary>
        /// Find the root/Parent of the vertex
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int Find(int p)
        {
            while (id[p] != p) p = id[p]; 
            return p;
        }

        private void Validate(int p)
        {
            int len = id.Length;
            if (p < 0 && p >= len) throw new ArgumentException("input is not in the range");
        }
        /// <summary>
        /// connect two vertices
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        public void Union(int p, int q)
        {
            int rootP = Find(p);
            int rootQ = Find(q);

            if (rootP == rootQ) return;

            if(size[rootP] < size[rootQ])
            {
                id[p] = rootQ;
                size[rootQ] += size[rootP];
            }
            else
            {
                id[q] = rootP;
                size[rootP] += size[rootQ];
            }
        }

    }
}
