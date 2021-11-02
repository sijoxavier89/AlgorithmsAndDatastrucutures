using System.Collections.Generic;

namespace PracticeProblems.CtCi.Hard
{
    public class BabyNames
    {
       
        Dictionary<string, int> trueFreq;
        public  IEnumerable<KeyValuePair<string, int>> TrueFreequency(Dictionary<string,int> freequencies, string[,] synonyms)
        {
            var graph = CreateGrap(freequencies);
            
            foreach(var item in freequencies)
            {
                var key = item.Key;
                var freeq = item.Value;

                graph.CreateNode(key, freeq);
            }

           
            trueFreq = new Dictionary<string, int>();
            // create graph
            for(int i = 0; i < synonyms.GetLength(0); i++)
            {
                graph.AddEdge(synonyms[i,0], synonyms[i,1]);

            }

           
            // do Dfs
            FindFreequencies(graph, synonyms, freequencies);

            return trueFreq;
        }

       private void FindFreequencies(Graph graph, string[,] synonym, Dictionary<string, int> freequencies)
        {
            trueFreq = new Dictionary<string, int>();
            foreach (var source in graph.GetNames())
            {
                var freequency = 0;
               if (!graph.GetNode(source).isVisited)
                freequency = Dfs(graph, source, freequencies);

                if(freequency != 0)
                trueFreq.Add(source, freequency);
            }
        }
        
        private int Dfs(Graph graph, string name, Dictionary<string, int> freequencies)
        {
            graph.UpateNode(name, true);
            int count = (freequencies.TryGetValue(name, out int value)) ? value : 0;

            foreach(var n in graph.Adj(name))
            {
                if(!graph.GetNode(n).isVisited)
                {
                   count += Dfs(graph, n, freequencies);
                }
            }

           
            return count;
        }
        private Graph CreateGrap(Dictionary<string, int> freequencies)
        {
            var graph = new Graph();

            foreach(var key in freequencies.Keys)
            {

            }
            return graph;
        }

        class Graph
        {
            Dictionary<string, List<string>> graph;
            Dictionary<string, GraphNode> nodes;

            public Graph()
            {
                graph = new Dictionary<string, List<string>>();
                nodes = new Dictionary<string, GraphNode>();
            }
            public IEnumerable<string> Adj(string key)
            {
                return graph[key];
            }

            public IEnumerable<string> GetNames()
            {
                return graph.Keys;
            }
            public void AddEdge(string name, string synonym)
            {
                // add name to graph
                if (!graph.ContainsKey(name))
                {
                    graph.Add(name, new List<string>() { synonym });
                   
                }
                else
                {
                    graph[name].Add(synonym);
                   
                }

                // add synonym to graph
                if (!graph.ContainsKey(synonym))
                {
                    graph.Add(synonym, new List<string>());

                }


                // create node
                if (!nodes.ContainsKey(name))
                CreateNode(name, 0);

                if (!nodes.ContainsKey(synonym))
                    CreateNode(synonym, 0);
            }

            public void CreateNode(string name, int freequency)
            {
                if (!nodes.ContainsKey(name))
                {
                    GraphNode node = new GraphNode(name, freequency);
                    nodes.Add(name, node);
                }
            }

            public void UpateNode(string name, bool visited)
            {
                if (nodes.ContainsKey(name))
                {
                    
                    nodes[name].isVisited = visited;
                }
            }

            public GraphNode GetNode(string name)
            {
                return nodes[name];
            }

        }

        class GraphNode
        {
            public string key;
            public int freequency;
            public bool isVisited;
            public GraphNode(string key, int freequency)
            {
                this.key = key;
                this.freequency = freequency;
            }
        }
    }
}
