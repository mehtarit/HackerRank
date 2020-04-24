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

    // Complete the largestRectangle function below.
    static long largestRectangle(int[] h) {

        var areas = new int[h.Length];
        for(int i = 0; i < h.Length; i++)
        {
            int currentHeight = h[i];
            int rightBuildings = 0;
            for(int j = i; j < h.Length; j++){
                if(h[j] < currentHeight){
                    break;
                }
                rightBuildings++;
            }
            int leftBuildings = 0;
            for(int m = i; m >=0; m--){
                if(h[m] < currentHeight){
                    break;
                }
                leftBuildings++;
            }
            int k = rightBuildings + leftBuildings -1;
            areas[i] = k*currentHeight;
        }

        var max = -1;
        for(int i = 0; i < h.Length; i++){
            if(areas[i] > max){
                max = areas[i];
            }
        }

        return max;

    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] h = Array.ConvertAll(Console.ReadLine().Split(' '), hTemp => Convert.ToInt32(hTemp))
        ;
        long result = largestRectangle(h);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
