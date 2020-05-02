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

class Pair {
    public int val;
    public int count;
    public Pair(int val, int count) {
        this.val = val;
        this.count = count;
    }
}

// Complete the poisonousPlants function below.
static int poisonousPlants(int[] p) {
    var stack = new Stack<Pair>();
    int maxDays = 0;
    for (int i = p.Length - 1; i >= 0; i--) {
        int temp = 0;
        while (stack.Count!=0 && p[i] < stack.Peek().val) {
            temp++;
            Pair pair = stack.Pop();
            temp = Math.Max(temp, pair.count);
        }
        stack.Push(new Pair(p[i], temp));
    }

    foreach(var s in stack){
        if(s.count > maxDays){maxDays = s.count;
        }
    }

    return maxDays;
}

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] p = Array.ConvertAll(Console.ReadLine().Split(' '), pTemp => Convert.ToInt32(pTemp))
        ;
        int result = poisonousPlants(p);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
