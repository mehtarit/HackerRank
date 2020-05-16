using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    public class Graph {
        
        private int _size;
        private Dictionary<int, List<int>> _graph;
        private int [] _result;
        
        public Graph(int size) {
            _size = size;
            _graph = new Dictionary<int, List<int>>();
            Console.WriteLine("Size is " + _size);
            _result = new int[_size+1];
        }

        public void addEdge(int first, int second) {
            if(!_graph.ContainsKey(first)){
                _graph.Add(first, new List<int>());
                _graph[first].Add(second);
            }
            else
            {
                if(!_graph[first].Contains(second))
                {
                    _graph[first].Add(second);
                }
            }
            if(!_graph.ContainsKey(second)){
                _graph.Add(second, new List<int>());
                _graph[second].Add(first);
            }
            else
            {
                if(!_graph[second].Contains(first))
                {
                    _graph[second].Add(first);
                }
            }
        }
        
        public int[] shortestReach(int startId) { // 0 indexed
           var nodesToVisit = new Queue<(int, int)>();
           var visited = new HashSet<int>();

           if(!_graph.ContainsKey(startId)){
              for(int i = 0; i < _size; i++){
                  _result[i]= -1;
              }
              return _result;
           }
        
           for(int i=0; i < _graph[startId].Count; i++){
               int x = _graph[startId][i];
               int y = 1;
               nodesToVisit.Enqueue((x, y));
           }

           while(nodesToVisit.Count != 0)
           {
               var current = nodesToVisit.Dequeue();

               if(visited.Contains(current.Item1)) continue;
               visited.Add(current.Item1);

               _result[current.Item1] = current.Item2*6;

               for(int j = 0; j < _graph[current.Item1].Count; j++){
                   nodesToVisit.Enqueue((_graph[current.Item1][j], current.Item2+1));
               }
           }

           for(int k = 0; k < _size; k++){
               if(_result[k] == 0){
                   _result[k] = -1;
               }
           }

           return _result;
        }
    }
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        
        TextWriter textWriter = new StreamWriter   (@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int queries = Convert.ToInt32(Console.ReadLine());

        for (int t = 0; t < queries; t++) {
            var nodesEdges = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(nodesEdges[0]);
            var graph = new Graph(n);
            int m = Convert.ToInt32(nodesEdges[1]);

            for(int i = 0; i < m; i++){
              var edges = Console.ReadLine().Split(' ');
              int u = Convert.ToInt32(edges[0]);
              int v = Convert.ToInt32(edges[1]);
              graph.addEdge(u, v);
            }
            
            var startId = Convert.ToInt32(Console.ReadLine());
            var distances = graph.shortestReach(startId);

            for(int i= 1; i < distances.Length; i++){
                if (i != startId){
                    if(distances[i] == 0){
                        distances[i] = -1;
                    }
                    textWriter.Write(distances[i]);
                    textWriter.Write(" ");
                }
            }

            textWriter.WriteLine();
        }
        
        textWriter.Flush();
        textWriter.Close();
    }
}
