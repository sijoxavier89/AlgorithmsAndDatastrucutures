using System;

namespace PracticeProblems.HashTable
{
    public class HashTable<TKey, TValue>
    {

        int currentSize;
        int Max;
        private LinkedList<TKey, TValue>[] arr;


        public HashTable(int count)
        {
            Max = count;
            arr = new LinkedList<TKey, TValue>[count];
        }


        public void Insert(TKey key, TValue value)
        {
            //TODO validate key 
            int index = HashValue(key);
            Validate(index);

            if (arr[index] != null)
            {
                arr[index].AppendToTail(key, value);
            }
            else
            {
                arr[index] = new LinkedList<TKey, TValue>();
                arr[index].AppendToTail(key, value);
            }

            currentSize++;

        }

        public int Count { get { return currentSize; } }

        public TValue Get(TKey key)
        {
            int index = HashValue(key);
            Validate(index);

            return arr[index].GetValue(key);
        }

        // return integer based index
        private int HashValue(TKey key)
        {
            int hashcode = 0x7FFFFFFF & key.GetHashCode();
            int index = hashcode % Max;
            return index;

        }


        // validate key is 
        private void Validate(int index)
        {
            if (index < 0 || index >= Max)
                throw new Exception();
        }


    }

    /*
     LinkdeList
    */
    class LinkedList<TKey, TValue>
    {

        Node head;
        Node tail;

        class Node
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
            public Node Next;

            public Node(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }
        }

        public void AppendToTail(TKey key, TValue value)
        {
            if (head == null)
            {
                head = new Node(key, value);
                tail = head;
            }

            tail.Next = new Node(key, value);

        }

        public TValue GetValue(TKey key)
        {
            if (head == null) throw new Exception();

            Node current = head;

            while (current != null)
            {

                if (current.Key.Equals(key)) break;

                current = current.Next;
            }

            return current.Value;
        }



    } // end of Linked List
}
