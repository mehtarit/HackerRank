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
    // Complete the maxSubsetSum function below.
    static int maxSubsetSum(int[] arr) {
        var maxArr = new int[arr.Length];

        maxArr[0] = arr[0];
        maxArr[1] = Math.Max(arr[0], arr[1]);

        for(int i = 2; i < arr.Length; i++){
            var currentValue = arr[i];
            var latestMax = maxArr[i-1];
            var addedMax = currentValue + maxArr[i-2];
            var maxContenderList = new List<int>(){
                currentValue, latestMax, addedMax
            };
            maxArr[i] = maxContenderList.Max();
        }

        return maxArr[arr.Length-1];

    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int res = maxSubsetSum(arr);

        textWriter.WriteLine(res);

        textWriter.Flush();
        textWriter.Close();
    }
}
