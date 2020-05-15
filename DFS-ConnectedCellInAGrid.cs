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

    static List<(int x, int y)> GetTupleList(){
        
        var tupleList = new List<(int x, int y)>
        {
            (-1, 0),
            (-1, 1),
            (0, 1),
            (1, 1),
            (1, 0),
            (1, -1),
            (0, -1),
            (-1, -1)
        };

        return tupleList;
    }

    static int FindRegionSum(int row, int col, int[][] grid){
        Console.WriteLine("row: " + row + " col: " + col);
        grid[row][col] = 0;

        var tupleList = GetTupleList();
        int sum = 1;
        for(int k = 0; k < tupleList.Count; k++){
            var newrow = row + tupleList[k].x;
            var newcol = col + tupleList[k].y;
            Console.WriteLine("newrow: " + newrow + " newcol: " + newcol);
            if(newrow < 0 || newrow > grid.Length-1) continue;
            if(newcol < 0 || newcol > grid[row].Length-1) continue;
            if(grid[newrow][newcol] == 0 ) continue;
            sum = sum + FindRegionSum(newrow, newcol, grid);
        }

        return sum;
    }

    // Complete the maxRegion function below.
    static int maxRegion(int[][] grid) {

        List<int>regionSums = new List<int>();

        for(int i = 0; i < grid.Length; i++){
            for(int j = 0; j < grid[i].Length; j++){
                var current = grid[i][j];
                if(current == 0) continue;
                var regionSum = FindRegionSum(i, j, grid);
                regionSums.Add(regionSum);
            }
        }


        int max = 0;
        foreach(int sum in regionSums){
            if(sum > max) max = sum;
        }
        return max;


    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int m = Convert.ToInt32(Console.ReadLine());

        int[][] grid = new int[n][];

        for (int i = 0; i < n; i++) {
            grid[i] = Array.ConvertAll(Console.ReadLine().Split(' '), gridTemp => Convert.ToInt32(gridTemp));
        }

        int res = maxRegion(grid);

        textWriter.WriteLine(res);

        textWriter.Flush();
        textWriter.Close();
    }
}
