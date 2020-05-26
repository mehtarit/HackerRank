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

    static string[] Fill(string[] crossword, Dictionary<Tuple<int, int>, char> map){
        for(int i=0; i< crossword.Length; i++){
            var row = crossword[i];
            for(int j = 0; j < row.Length; j++){
                var currentCell = Tuple.Create(i, j);
                if(!map.ContainsKey(currentCell)) continue;
                crossword[i][j] = map[currentCell];
                //strings in c# are immutable so this will not work.
            }
        }

        return crossword;

    }

    // Complete the crosswordPuzzle function below.
    static string[] crosswordPuzzle(string[] crossword, string words) {

           var matrixMap = new Dictionary<Tuple<int, int>, char>();
           var tuple = Tuple.Create(1, 2);
           matrixMap.Add(tuple, 'Z');
           return Fill(crossword,matrixMap);
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] crossword = new string [10];

        for (int i = 0; i < 10; i++) {
            string crosswordItem = Console.ReadLine();
            crossword[i] = crosswordItem;
        }

        string words = Console.ReadLine();

        string[] result = crosswordPuzzle(crossword, words);

        textWriter.WriteLine(string.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
