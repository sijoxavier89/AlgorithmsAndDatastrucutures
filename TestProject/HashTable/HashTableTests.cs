using PracticeProblems.HashTable;
using Xunit;

namespace PracticeProblems.Tests.HashTable
{
    /*
     Hash table wiith Insert, Add 
    */
    public class HashTableTests
    {
        [Fact]
        public void TestHashTable()
        {
            int size = 10;

            HashTable<int,string> hashTable = new HashTable<int,string>(size);

            Assert.Equal(0, hashTable.Count);

            hashTable.Insert(1, "Sijo");
            hashTable.Insert(2, "Akshay");
            hashTable.Insert(3, "Sahil");

            Assert.Equal(3, hashTable.Count);
            Assert.Equal("Sijo", hashTable.Get(1));
            Assert.Equal("Akshay", hashTable.Get(2));
            Assert.Equal("Sahil", hashTable.Get(3));

            
        }

    }
}

   