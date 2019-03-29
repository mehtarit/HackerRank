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

    static long mergeHalvesCount(int[] array, int[] temp, int leftStart, int middle, int rightEnd)
    {
        long count = 0;
        int left = leftStart;
        int right = middle + 1;
        int index = leftStart; 

        while (left <= middle || right <= rightEnd) {
            if (left > middle) {
                array[index++] = temp[right++];
            } 
            else if (right > rightEnd) {
                array[index++] = temp[left++];
            } 
            else if (temp[left] <= temp[right]) {
                array[index++] = temp[left++];
            } 
            else {
                array[index++] = temp[right++];
                count += middle + 1 - left;
            }
        }
        return count;
    }

    static long mergeSortCount(int[] array, int[] temp, int leftStart, int rightEnd)
    { 
        if(leftStart >= rightEnd)
        {
            return 0;
        }

        long count = 0;
        int middle = leftStart  + (rightEnd - leftStart)/2;
        count = count + mergeSortCount(temp, array, leftStart, middle);
        count = count + mergeSortCount(temp, array, middle +1, rightEnd);
        count = count + mergeHalvesCount(array, temp, leftStart, middle, rightEnd);
        return count;
    }

    static long countInversions(int[] arr) {

        int[] temp = (int[])arr.Clone();
        long count = mergeSortCount(arr, temp, 0, arr.Length-1);
        return count;        
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++) {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
            ;
            long result = countInversions(arr);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
