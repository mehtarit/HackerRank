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

    // Complete the reverseShuffleMerge function below.
    static string reverseShuffleMerge(string s) {

        Dictionary<char, int> count = new Dictionary<char, int>();
        foreach(char c in s)
        {
            if(!count.ContainsKey(c))
            {
                count.Add(c, 1);
            }
            else
            {
                count[c]++;
            }
        }

        Dictionary<char, int> minLimit = new Dictionary<char, int>();
        foreach(char c in count.Keys)
        {
            minLimit.Add(c, (count[c]/2));
        }


        char[] A = new char[s.Length/2];
        int index_a = 0;

        var sorted_list = count.Keys.ToList();
        sorted_list.Sort();

        for(int i = s.Length-1; i>=0; i--)
        {
            if(index_a == (s.Length/2)) break;
            char current = s[i];
            if(count[current] <= minLimit[current]) // if can't leave 
            {
                A[index_a] = current;
                index_a++;
                count[current]--;
            }
            else //if can leave
            {
                count[current]--;
                if(current == sorted_list[0])
                {
                    A[index_a] = current;
                    index_a++;
                    count[current]--;
                    sorted_list.Remove(current);   
                }
            }
        }
        string result = new string(A);
        return result;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = reverseShuffleMerge(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
