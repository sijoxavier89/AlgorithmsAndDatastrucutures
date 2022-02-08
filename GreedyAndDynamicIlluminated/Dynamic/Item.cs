namespace GreedyAndDynamicIlluminated.Dynamic
{
    public class Item
    {
        public Item(int key, int value, int capacity)
        {
            Key = key;
            Value = value;
            Capacity = capacity;
        }

        public int Key { get; }
        public int Value { get; }
        public int Capacity { get; }
    }
}
