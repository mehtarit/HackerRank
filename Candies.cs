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

    // Complete the candies function below.
    static long candies(int n, int[] arr) {

        int [] candies = new int[n];
        
        //every kid gets at least one candy
        for(int i = 0; i < n; i++){
            candies[i]=1;
        }

        //give candies to the right
        for(int i =1; i < n; i++)
        {
            if(arr[i] > arr[i-1]){
                candies[i] = candies[i-1]+1;
            }
        }
        
        //give candies to the left
        //take care of candies[i+1]+1 since trend can be going ascending or descending.
        for(int i= n-2; i>=0; i--)
        {
            if(arr[i] > arr[i+1]){
                if(candies[i] < candies[i+1]+1){
                    candies[i] = candies[i+1]+1;
                }
            }
        }

        long result=0;

        for(int i = 0; i < n; i++)
        {
            result = result + (long)candies[i];
        }

        return result;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int [n];

        for (int i = 0; i < n; i++) {
            int arrItem = Convert.ToInt32(Console.ReadLine());
            arr[i] = arrItem;
        }

        long result = candies(n, arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
