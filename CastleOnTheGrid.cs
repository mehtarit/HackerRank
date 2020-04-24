using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {

    // Complete the minimumMoves function below.
    static int minimumMoves(string[] grid, int startX, int startY, int goalX, int goalY) {
        var n = grid.Length;
        var distanceQueue = new Queue<int>();
        var NodesToVisitQueue = new Queue<Tuple<int, int>>();
        var nodesVisitedSet = new HashSet<Tuple<int, int>>();

        var position = new Tuple<int, int>(startX, startY);
        NodesToVisitQueue.Enqueue(position);
        nodesVisitedSet.Add(position);
        distanceQueue.Enqueue(0);

        var neighbourVectors = new List<Tuple<int, int>>(){
           new Tuple<int, int>(-1, 0),
           new Tuple<int, int>(0, -1),
           new Tuple<int, int>(1, 0),
           new Tuple<int, int>(0, 1)
        };

        while (NodesToVisitQueue.Count != 0){

            var currentNode = NodesToVisitQueue.Peek();
            if(currentNode.Item1 == goalX && currentNode.Item2 == goalY){
                return distanceQueue.Peek();
            }

            for(int i = 0; i < neighbourVectors.Count; i++){
                var newX = currentNode.Item1 + neighbourVectors[i].Item1;
                var newY = currentNode.Item2 + neighbourVectors[i].Item2;


                while(newX >= 0 && newX < n && newY >= 0 && newY < n && grid[newX][newY] != 'X')
                {
                    var neighbour = new Tuple<int, int>(newX, newY);
                    newX = newX + neighbourVectors[i].Item1;
                    newY = newY + neighbourVectors[i].Item2;

                    if(nodesVisitedSet.Contains(neighbour)){
                      continue;
                    }

                    NodesToVisitQueue.Enqueue(neighbour);
                    distanceQueue.Enqueue(distanceQueue.Peek() + 1);
                    nodesVisitedSet.Add(neighbour);
                }

            }
            NodesToVisitQueue.Dequeue();
            distanceQueue.Dequeue();

        }

        return 0;
}

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        string[] grid = new string [n];

        for (int i = 0; i < n; i++) {
            string gridItem = Console.ReadLine();
            grid[i] = gridItem;
        }

        string[] startXStartY = Console.ReadLine().Split(' ');

        int startX = Convert.ToInt32(startXStartY[0]);

        int startY = Convert.ToInt32(startXStartY[1]);

        int goalX = Convert.ToInt32(startXStartY[2]);

        int goalY = Convert.ToInt32(startXStartY[3]);

        int result = minimumMoves(grid, startX, startY, goalX, goalY);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
