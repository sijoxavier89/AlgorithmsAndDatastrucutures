using PracticeProblems.Graph;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace TestProject.Graph
{
    public class SCCKosarajuTests
    {
        [Fact]
        public void SCC_Test1()
        {
            string path = @"C:\Users\sijox\source\repos\AlgorithmsAndDatastrucutures\TestProject\Graph\TestData\problem8.10test1.txt";
            Digraph g = new Digraph(path);

            SCCKosaraju scc = new SCCKosaraju(g);
            var cc = scc.SCC();

            var sccList = ((Dictionary<int, int>)cc);

            
            List<int> sccCount = CountComp(sccList);


            Assert.Equal(3, sccCount[0]);
            Assert.Equal(3, sccCount[1]);
            Assert.Equal(3, sccCount[2]);
        }


        [Fact]
        public void SCC_Test2()
        {
            string path = @"C:\Users\sijox\source\repos\AlgorithmsAndDatastrucutures\TestProject\Graph\TestData\cc.txt";
            Digraph g = new Digraph(path);

            SCCKosaraju scc = new SCCKosaraju(g);
            var cc = scc.SCC();

            var sccList = ((Dictionary<int, int>)cc);
            List<int> sccCount = CountComp(sccList);
        

            Assert.Equal(4, sccCount[0]);
            Assert.Equal(3, sccCount[1]);
            Assert.Equal(1, sccCount[2]);
        }

        [Fact]
        public void SCC_Test8_2()
        {
            string path = @"C:\Users\sijox\source\repos\AlgorithmsAndDatastrucutures\TestProject\Graph\TestData\problem8.10test2.txt";
            Digraph g = new Digraph(path);

            SCCKosaraju scc = new SCCKosaraju(g);
            var cc = scc.SCC();

            var sccList = ((Dictionary<int, int>)cc);


            List<int> sccCount = CountComp(sccList);


            Assert.Equal(3, sccCount[0]);
            Assert.Equal(3, sccCount[1]);
            Assert.Equal(2, sccCount[2]);
        }

        [Fact]
        public void SCC_Test8_3()
        {
            string path = @"C:\Users\sijox\source\repos\AlgorithmsAndDatastrucutures\TestProject\Graph\TestData\problem8.10test3.txt";
            Digraph g = new Digraph(path);

            SCCKosaraju scc = new SCCKosaraju(g);
            var cc = scc.SCC();

            var sccList = ((Dictionary<int, int>)cc);


            List<int> sccCount = CountComp(sccList);


            Assert.Equal(3, sccCount[0]);
            Assert.Equal(3, sccCount[1]);
            Assert.Equal(1, sccCount[2]);
        }

        [Fact]
        public void SCC_Test8_4()
        {
            string path = @"C:\Users\sijox\source\repos\AlgorithmsAndDatastrucutures\TestProject\Graph\TestData\problem8.10test4.txt";
            Digraph g = new Digraph(path);

            SCCKosaraju scc = new SCCKosaraju(g);
            var cc = scc.SCC();

            var sccList = ((Dictionary<int, int>)cc);


            List<int> sccCount = CountComp(sccList);


            Assert.Equal(7, sccCount[0]);
            Assert.Equal(1, sccCount[1]);
           
        }

        [Fact]
        public void SCC_Test8_5()
        {
            string path = @"C:\Users\sijox\source\repos\AlgorithmsAndDatastrucutures\TestProject\Graph\TestData\problem8.10test5.txt";
            Digraph g = new Digraph(path);

            SCCKosaraju scc = new SCCKosaraju(g);
            var cc = scc.SCC();

            var sccList = ((Dictionary<int, int>)cc);


            List<int> sccCount = CountComp(sccList);


            Assert.Equal(6, sccCount[0]);
            Assert.Equal(3, sccCount[1]);
            Assert.Equal(2, sccCount[2]);

        }
        private List<int> CountComp(Dictionary<int,int> scc)
        {
            Dictionary<int,int> result = new Dictionary<int,int>();
            foreach (var sccItem in scc)
            {
                if(!result.ContainsKey(sccItem.Value))
                {
                    result.Add(sccItem.Value, 1);
                }
                else
                {
                    result[sccItem.Value]++;
                }
            }

            var list = result.Values.ToList();
            list.Sort();
            list.Reverse();
            return list;

        }
    }
}
