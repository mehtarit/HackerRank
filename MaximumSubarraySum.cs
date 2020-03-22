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

    // Complete the maximumSum function below.
    static long maximumSum(long[] a, long m) {
        long n = a.Length;
        long [] prefix = new long[n];
        
        //create prefix array
        long current = 0;
        for(int i = 0; i < n; i++){
            current = (a[i]%m + current)%m;
            prefix[i] = current;
        }

        long result = 0;
        for(int j = 1; j < n; j++){
            for(int i = j-1; i >=0; i--){
                long sum = (prefix[j]-prefix[i] + m)%m;
                if(sum > result) result = sum;
            }
        }
        if(prefix[0]>result) result = prefix[0];
        return result;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++) {
            string[] nm = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nm[0]);

            long m = Convert.ToInt64(nm[1]);

            long[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt64(aTemp))
            ;
            long result = maximumSum(a, m);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
