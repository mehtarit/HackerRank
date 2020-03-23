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

public static class Solution {
    public static string RemoveFirstLowerCaseLetter(this string str){
        if(string.IsNullOrEmpty(str)) return str;
        if(str.Length == 1)
        {
            if(char.IsLower(str[0])) return string.Empty;
            return str;
        }
        var indexToRemove = -1;
        for(int i = 0; i < str.Length; i++)
        {
            var c = str[i];
            if(char.IsLower(c))
            {
                indexToRemove = i;
                break;
            }
        }
        if(indexToRemove < 0) return str;
        return str.Remove(indexToRemove, 1);
    }
    public static string FirstLowerCaseLetterToUpper(this string str)
    {
        if(string.IsNullOrEmpty(str)) return str;
        if(str.Length == 1)
        {
            return str.ToUpper();
        }
        var indexToCapitalize = -1;
        for(int i = 0; i < str.Length; i++)
        {
            var c = str[i];
            if(char.IsLower(c))
            {
                indexToCapitalize = i;
                break;
            }
        }
        if(indexToCapitalize < 0) return str;
        var capitalized = char.ToUpper(str[indexToCapitalize]).ToString();
        var beforeStr = str.Substring(0, indexToCapitalize);
        var afterStr = str.Substring(indexToCapitalize+1);

        return beforeStr + capitalized + afterStr;

    }
    static bool possible = false;
    static HashSet<string> memo = new HashSet<string>();

    static void abbreviation_helper(string a, string b)
    {
        Console.WriteLine("Consider case with a: " + a + " and b: " + b);
        if(possible) return;
        if(a.Length < b.Length) return;
        if(memo.Contains(a)) return;

        if(a.Length == b.Length) {
            var a_upper = a.ToUpper();
            if(a_upper.Equals(b)){
                possible = true;
                return;
            }        
        }

        if(!memo.Contains(a)) memo.Add(a);

        if(a.Length > b.Length){
            abbreviation_helper(a.RemoveFirstLowerCaseLetter(), b);
            if(possible) return;
            abbreviation_helper(a.FirstLowerCaseLetterToUpper(), b);
        }     
    }
    // Complete the abbreviation function below.
    static string abbreviation(string a, string b) {
        possible = false;
        memo = new HashSet<string>();
        abbreviation_helper(a, b);
        if(possible) return "YES";
        else return "NO";
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++) {
            string a = Console.ReadLine();

            string b = Console.ReadLine();

            string result = abbreviation(a, b);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
