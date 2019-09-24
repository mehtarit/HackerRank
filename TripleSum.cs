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

    // Complete the triplets function below.
    static long triplets(int[] a, int[] b, int[] c) {
        Array.Sort(a);
        Array.Sort(b);
        Array.Sort(c);

        var b_arr = b.Distinct().ToArray();
        var a_arr = a.Distinct().ToArray();
        var c_arr = c.Distinct().ToArray();

        int a_start= 0;
        int c_start =0;

        long count = 0;
        for(int i=0; i< b_arr.Length; i++)
        {
            int a_combinations =0;
            int c_combinations =0;
                 
            for(int j=a_start; j< a_arr.Length; j++)
            {
                if(a_arr[j] <= b_arr[i])
                {
                    a_combinations++;
                }               
                else 
                {
                    break;
                }
                
            }

            for(int k=c_start; k< c_arr.Length; k++)
            {
                if(c_arr[k] <= b_arr[i])
                c_combinations++;
                else
                break;
            }

            a_start = a_start + a_combinations;
            c_start = c_start + c_combinations;
            count = count + (long)a_start*(long)c_start;
        }

        return count;

    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] lenaLenbLenc = Console.ReadLine().Split(' ');

        int lena = Convert.ToInt32(lenaLenbLenc[0]);

        int lenb = Convert.ToInt32(lenaLenbLenc[1]);

        int lenc = Convert.ToInt32(lenaLenbLenc[2]);

        int[] arra = Array.ConvertAll(Console.ReadLine().Split(' '), arraTemp => Convert.ToInt32(arraTemp))
        ;

        int[] arrb = Array.ConvertAll(Console.ReadLine().Split(' '), arrbTemp => Convert.ToInt32(arrbTemp))
        ;

        int[] arrc = Array.ConvertAll(Console.ReadLine().Split(' '), arrcTemp => Convert.ToInt32(arrcTemp))
        ;
        long ans = triplets(arra, arrb, arrc);

        textWriter.WriteLine(ans);

        textWriter.Flush();
        textWriter.Close();
    }
}
