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

    static Dictionary<int, List<string>> GetWordLengthMap(string words){
        var wordList = words.Split(';').ToList();
        var result = new Dictionary<int, List<string>>();

        foreach(var word in wordList){
            if(!result.ContainsKey(word.Length)){
                result.Add(word.Length,new List<string>(){word});
                continue;
            }
            result[word.Length].Add(word);
        }
        return result;
    }

    static string[] Fill(string[] crossword, Dictionary<Tuple<int, int>, char> map){
        for(int i=0; i< crossword.Length; i++){
            var row = crossword[i];
            var stringBuilder= new StringBuilder(row);
            for(int j = 0; j < row.Length; j++){
                var currentCell = Tuple.Create(i, j);
                if(!map.ContainsKey(currentCell)) continue;
                stringBuilder[j] = map[currentCell];
            }
            crossword[i] = stringBuilder.ToString();
        }
        return crossword;
    }

    static void Print(Dictionary<int, List<string>> wordLengthMap){
          foreach(var result in wordLengthMap){
              Console.Write($"{result.Key}: ");
              foreach(var word in result.Value){
                  Console.Write($"{word} ");
              }
              Console.WriteLine();
          }
    }

    static void FillMatrixMap(string[] crossword,
    Dictionary<int, List<string>> wordLengthMap, 
    Dictionary<Tuple<int, int>, char> matrixMap)
    {
        var tuple = Tuple.Create(1, 2);
        matrixMap.Add(tuple, 'Z');
    }

    // Complete the crosswordPuzzle function below.
    static string[] crosswordPuzzle(string[] crossword, string words) {
         
          var wordLengthMap = GetWordLengthMap(words);          
          Print(wordLengthMap);
          var matrixMap = new Dictionary<Tuple<int, int>, char>();
          FillMatrixMap(crossword, wordLengthMap, matrixMap);
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
