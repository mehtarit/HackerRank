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

    // Complete the riddle function below.
    static long[] riddle(long[] arr) {
        var maxWindowSizeWhereMinMap = new Dictionary<long, long>();
        for(int i = 0; i < arr.Length; i++){
            long current = arr[i];

            long leftWindowSize =0;
            for(int j = i; j >=0; j--){
                if(arr[j] < current){
                   break;
                }
                leftWindowSize++;
            }

            long rightWindowSize =0;
            for(int k = i; k < arr.Length; k++){
                if(arr[k] < current){
                    break;
                }
                rightWindowSize++;
            }
            long maxWindowSize = leftWindowSize + rightWindowSize -1;
            if(maxWindowSizeWhereMinMap.ContainsKey(current)){
                var value =maxWindowSizeWhereMinMap[current];
                if(value < maxWindowSize){
                    maxWindowSizeWhereMinMap[current] = maxWindowSize;
                }
            }
            else maxWindowSizeWhereMinMap.Add(current, maxWindowSize);
        }
        var invertedMaxMap = new Dictionary<long, long>();
        foreach(var pair in maxWindowSizeWhereMinMap){
            if(!invertedMaxMap.ContainsKey(pair.Value)){
                invertedMaxMap.Add(pair.Value, pair.Key);
                continue;
            }
            var consideringKey = pair.Value;
            var consideringValue = pair.Key;
            var existingValue = invertedMaxMap[consideringKey];
            if(existingValue < consideringValue){
                invertedMaxMap[consideringKey] = consideringValue;
            }
        }

        var result = new long[arr.Length];

        
        for(int i = arr.Length -1; i >=0; i--){
            if(invertedMaxMap.ContainsKey(i+1)){
                 result[i] = invertedMaxMap[i+1];
                 continue;
                }
           }
        
        //fill gaps
        for(int i = arr.Length -2; i >=0; i--){
            result[i] = Math.Max(result[i], result[i+1]);
        }

        return result;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        long[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt64(arrTemp))
        ;
        long[] res = riddle(arr);

        textWriter.WriteLine(string.Join(" ", res));

        textWriter.Flush();
        textWriter.Close();
    }
}
