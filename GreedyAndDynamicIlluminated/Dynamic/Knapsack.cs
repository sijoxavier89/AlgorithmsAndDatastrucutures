using System.Collections.Generic;

namespace GreedyAndDynamicIlluminated.Dynamic
{
    public class Knapsack
    {
        private readonly IEnumerable<Item> input;
        private int[,] Computed;
        private int Capacity;
        public Knapsack(IEnumerable<Item> input, int capacity)
        {
            this.input = input;
            this.Capacity = capacity;
            Computed = new int[input.Count() + 1, capacity + 1];
        }
        public int MaxValue(int capacity)
        {
            // Initialize base case 
            // when i = 0;
            var items = input.ToArray();
            for (int c = 0; c < Capacity; c++)
            {
                Computed[0, c] = 0;
            }

            for(int i = 0; i < items.Length; i++) 
            {
                for(int c = 0; c <= Capacity; c++)
                {
                    // if si <= c then A[i][c] = max{A[i-1][c], A[i-1][c-si]+si}
                    if(items[i].Capacity <= c) 
                    {
                        // since items are 0 indexed , start the Computed array from i=1,
                        Computed[i+1, c] = Math.Max(Computed[i, c], (Computed[i, (c - items[i].Capacity)] + items[i].Value));
                    }
                    else
                    {
                        Computed[i+1, c] = Computed[i, c];
                    }
                }
            }

            return Computed[items.Length, capacity];
        }

        /// <summary>
        /// Given a knapsack computed Array 
        /// reconstruct the items part of the knapsack array
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Item> Reconstruct()
        {
            List<Item> result = new List<Item>();
            int c = Capacity;
            var items = input.ToArray();
            for (int i = Computed.GetLength(0)-1; i > 0; i--)
            {
                if(items[i-1].Capacity <= c && (Computed[i , c] <= (Computed[i-1, ((c - items[i-1].Capacity))] + items[i-1].Value)))
                {
                     result.Add(items[i-1]);
                     c = c - items[i-1].Capacity;                    
                }
            }

            return result;
        }
    }
}
