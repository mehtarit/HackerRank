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

    static int superDigit(long n){
        int numDigits = n.ToString().Length;

        long sum = 0;
        for(int i = 0; i < numDigits; i++){
            long current = n%10;
            sum = sum+current;
            n=n/10;
        }

        if(sum/10 == 0) return (int)sum;
        else return superDigit(sum);

    }

    // Complete the superDigit function below.
    static int superDigit(string n, int k) {
        
        long sum = 0;

        foreach(var c in n){
            int x = c - '0';
            sum = sum+(long)x;
        }
        sum = sum*k;
        return superDigit(sum);
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nk = Console.ReadLine().Split(' ');

        string n = nk[0];

        int k = Convert.ToInt32(nk[1]);

        int result = superDigit(n, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
