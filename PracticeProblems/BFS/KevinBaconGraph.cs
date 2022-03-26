using Algorithms;
using System;
using System.Collections.Generic;
using System.IO;

namespace PracticeProblems.BFS
{
    public  class KevinBaconGraph
    {
        private GraphSx graph;
        private Dictionary<int, bool> marked;
        private Dictionary<int, int> distTo;
        private Dictionary<int, int> edgeTo;
        private Dictionary<string, int> actorMap;
        private Dictionary<int, string> actorList;
        private Dictionary<int, string> movieList;
        private Dictionary<int, int> degree;
        private const string FILEPATH = "C:\\Users\\sijox\\source\\repos\\AlgorithmsAndDatastrucutures\\PracticeProblems\\BFS\\";


        public KevinBaconGraph(string actors, string movies, string actormoviemap)
        {
            actorList = ReadFromFile(actors);
            InitializeActorMap(actorList);
            movieList = ReadFromFile(movies);
            int vertices = actorList.Count + movieList.Count;
            graph = new GraphSx(vertices);
            InitializeGraph(graph, actormoviemap);

            InitializeGlobals();

        }

        private void InitializeGlobals()
        {
            //
            marked = new Dictionary<int, bool>();
            foreach (int v in graph.Vertices())
            {
                marked.Add(v, false);
            }
            distTo = new Dictionary<int, int>();
            foreach (int v in graph.Vertices())
            {
                distTo.Add(v, 0);
            }
            edgeTo = new Dictionary<int, int>();
            foreach (int v in graph.Vertices())
            {
                edgeTo.Add(v, 0);
            }

            degree = new Dictionary<int, int>();
            foreach (int v in graph.Vertices())
            {
                degree.Add(v, 0);
            }

        }
        private Dictionary<int, string> ReadFromFile(string fileName)
        {
            string fullPth = FILEPATH + fileName;
            string[] lines = File.ReadAllLines(fullPth);
            Dictionary<int, string> result = new Dictionary<int, string>();

            foreach(string entry in lines)
            {
                string[] split = entry.Split(",");
                result.Add(Convert.ToInt32(split[0]), split[1]);
            }

            return result;
        }

        private void InitializeActorMap(Dictionary<int, string> actors)
        {
            actorMap = new Dictionary<string, int>();
            foreach(int key in actors.Keys)
            {
                actorMap.Add(actors[key], key);
            }
        }
        private void InitializeGraph(GraphSx pGraph, string fileName)
        {
            string fullPth = FILEPATH + fileName;
            string[] lines = File.ReadAllLines(fullPth);

            foreach (string entry in lines)
            {
                string[] split = entry.Split(",");
                int v = Convert.ToInt32(split[0]);
                for(int i = 1; i < split.Length; i++)
                {
                    int w = Convert.ToInt32(split[i]);
                    pGraph.AddEdge(v, w);
                }
            }
        }
        public IEnumerable<string> GetActors(string actor, int degree)
        {
            var actorIds = BFS(actorMap[actor], degree);
            List<string> selected = new List<string>();

            foreach(var item in actorIds)
            {
                selected.Add(actorList[item]);
            }

            return selected;
        }

        private IEnumerable<int> BFS(int rootActor, int targetDegree)
        {
            Queue<int> queue = new Queue<int>();
             queue.Enqueue(rootActor);
            marked[rootActor] = true;
            List<int> actors = new List<int>();
            degree[rootActor] = -1;
            while(queue.Count > 0)
            {
                int v = queue.Dequeue();

                if (distTo[v] <= targetDegree)
                {
                    foreach (int w in graph.Adj(v))
                    {
                        if (!marked[w])
                        {
                            distTo[w] = distTo[v] + 1;
                            if (distTo[w] % 2 == 0)
                                actors.Add(w);
                            marked[w] = true;
                            queue.Enqueue(w);
                            edgeTo[w] = v;
                           

                        }
                    }
                }
      
            }
            return actors;
        }
    }
}
