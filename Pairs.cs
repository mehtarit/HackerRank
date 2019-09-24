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

    // Complete the pairs function below.
    static int pairs(int k, int[] arr) {
        HashSet<int> og_set = new HashSet<int>();
        HashSet<int> diff_set = new HashSet<int>();

        foreach(int i in arr)
        {
            if(!og_set.Contains(i))
             og_set.Add(i);

            int diff = i+k;
            if(!diff_set.Contains(diff))
            diff_set.Add(diff);
        }

        int count = 0;

        foreach(int i in diff_set)
        {
            if(og_set.Contains(i))
            count++;
        }

        return count;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nk = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nk[0]);

        int k = Convert.ToInt32(nk[1]);

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int result = pairs(k, arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
