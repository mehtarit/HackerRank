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

    // Complete the getMinimumCost function below.
    static int getMinimumCost(int k, int[] c) {

        Array.Sort<int>(c);

        int start = c.Length-1;
        int end = start - k +1;
        if(end < 0) end = 0;
        
        int multiplier = 1;
        int minCost =0;
        while(end >=0)
        {
            for(int i=start; i >=end; i--)
            {
                minCost = minCost + c[i]*multiplier;
            }
            start = end-1;
            end = start-k +1;
            multiplier++;
        }

        if(start < 0) return minCost;

  
        for(int i = start; i >=0; i--)
        {
            minCost = minCost + c[i]*multiplier;
        }

        return minCost;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nk = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nk[0]);

        int k = Convert.ToInt32(nk[1]);

        int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp))
        ;
        int minimumCost = getMinimumCost(k, c);

        textWriter.WriteLine(minimumCost);

        textWriter.Flush();
        textWriter.Close();
    }
}
