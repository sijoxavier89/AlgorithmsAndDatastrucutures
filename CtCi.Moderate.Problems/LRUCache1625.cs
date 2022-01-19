using System;
using System.Collections.Generic;

namespace CtCi.Moderate.Problems
{
    /// <summary>
    /// Design and build a "least recently used" cache, which evicts the least 
    /// recently used item. The cache should map from keys to values and be initialized with 
    /// Max size. when it is full it should evicts the least recently used item.
    /// </summary>
    public class LRUCache1625<TKey, TValue>
    {
        private readonly int maxSize;
        private Dictionary<TKey, LRULinkedListNode> lookup;
        private LRULinkedListNode first;
        private LRULinkedListNode last;

        public LRUCache1625(int maxSize)
        {
            this.maxSize = maxSize;
            lookup = new Dictionary<TKey, LRULinkedListNode>();
        }
        public void Insert(TKey key, TValue value)
        {
            if(lookup.ContainsKey(key))
            {
                Remove(key);
            }

            if(lookup.Count == maxSize)
            {
                // remove from the tail
                var keyOfLast = last.key;

                RemoveFromList(lookup[keyOfLast]);
                lookup.Remove(keyOfLast);
            }

            var newNode = new LRULinkedListNode(key, value);

            // add to head
            AppendToTail(newNode);
            lookup.Add(key, newNode);
        }

        public TValue Get(TKey key)
        {
            LRULinkedListNode node;
            if(lookup.TryGetValue(key,out node))
            {
                if (node != first)
                {
                    RemoveFromList(node);
                    AddtoHead(node);
                }
                return node.value;
            }



            return default; 
          
        }

        public void Remove(TKey key)
        {
            var nodeToRemove = lookup[key];
            RemoveFromList(nodeToRemove);
            lookup.Remove(key);
        }

        private void RemoveFromList(LRULinkedListNode node)
        {
            if (node == null) return;
            // if this first node
            if(node == first)
            {
                first = node.next;
              
            }
            if(node == last) // last node
            {
                last = node.prev;
                
            }

           if(node.prev != null)
            node.prev.next = node.next;

            if (node.next != null)
                node.next.prev = node.prev;
               
        }

        private void AppendToTail(LRULinkedListNode node)
        {
            if (first == null)
            {
                first = node;
                last = node;
            }

            last.next = node;
            node.prev = last;
            last = node;
        }

        private void AddtoHead(LRULinkedListNode node)
        {
            if (first == null)
            {
                first = node;
                last = first;
            }
            else
            {
                node.next = first;
                first.prev = node;
                first = node;
                first.prev = null;
            }
        }
        
        class LRULinkedListNode
        {
            public TKey key { get; set; }
            public  TValue value { get; set; }
            public LRULinkedListNode  next { get; set; }
            public LRULinkedListNode  prev { get; set; }
            public LRULinkedListNode(TKey key, TValue value)
            {
                this.key = key;
                this.value = value;
            }
        }
    }
}
