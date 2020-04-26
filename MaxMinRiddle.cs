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

    static long GetMax(long [] arr){
        long max = -1;
        for(int i = 0; i < arr.Length; i++){
            if(arr[i] > max){
                max = arr[i];
            }
        }
        return max;
    }

    static long GetMin(long [] arr){
        long min = long.MaxValue;
        for(int i = 0; i < arr.Length; i++){
            if(arr[i] < min){
                min = arr[i];
            }
        }
        return min;
    }

    static long GetMaximumMin(long [] arr, int windowSize){
        if(windowSize == 1) return GetMax(arr);
        if(windowSize == arr.Length) return GetMin(arr);
        long max = -1;
        for(int i = 0; i < arr.Length - windowSize; i++){
            long [] currentArr = new long [windowSize];
            int start = i;
            int end = i+windowSize -1;
            int index = 0;
            for(int j = start; j <=end; j++){
               currentArr[index] = arr[j];
               index++;
            }
            long currentArrMin = GetMin(currentArr);
            if(currentArrMin > max){
                max = currentArrMin;
            }
        }
        return max;
    }

    // Complete the riddle function below.
    static long[] riddle(long[] arr) {
        long [] result = new long [arr.Length];
        for(int i = 0; i < arr.Length; i++){
            var windowSize = i+1;
            result[i] = GetMaximumMin(arr, windowSize);
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
