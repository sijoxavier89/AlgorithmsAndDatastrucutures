using GreedyAndDynamicIlluminated.Dynamic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace GreedyAndDynamicIlluminated.Tests.Dynamic
{
    public class KnapsackTests
    {
        [Fact]
        public void TestKnapsackValueBasic()
        {
            string path = @"C:\Users\sijox\source\repos\AlgorithmsAndDatastrucutures\GreedyAndDynamicIlluminated.Tests\Dynamic\TestData\knapsackbasic.txt";
            int capacity = 0;
            var input = Input(path, ref capacity);
            Knapsack knapsack = new Knapsack(input, capacity);
            // Act
            var ksvalue = knapsack.MaxValue(capacity);
            var list = knapsack.Reconstruct();
            // Assert
            Assert.Equal(8, ksvalue);
            Assert.Equal(8, list.Sum(x => x.Value));
        }

        [Fact]
        public void TestKnapsackValue()
        {
            string path = @"C:\Users\sijox\source\repos\AlgorithmsAndDatastrucutures\GreedyAndDynamicIlluminated.Tests\Dynamic\TestData\167knapsack.txt";
            int capacity = 0;
            var input = Input(path, ref capacity);
            Knapsack  knapsack = new Knapsack(input, capacity);
            // Act
            var ksvalue = knapsack.MaxValue(capacity);

            // Assert
            Assert.Equal(2493893, ksvalue);
        }

        private static List<Item> Input(string path, ref int capacity)
        {
            List<Item> input = new List<Item>();

            string[] lines = File.ReadAllLines(path);
            capacity = Convert.ToInt32(lines[0].Split(" ")[0]);
            for (int i = 1; i < lines.Length; i++)
            {
                var item = new Item(i , Convert.ToInt32(lines[i].Split(" ")[0]), Convert.ToInt32(lines[i].Split(" ")[1]));

                input.Add(item);
            }

            return input;


        }
    }
}
