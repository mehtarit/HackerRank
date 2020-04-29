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

    // Complete the poisonousPlants function below.
    static int poisonousPlants(int[] p) {
        var stack1 = new Stack<int>();
        var stack2 = new Stack<int>();

        int initialNumberOfPlants = p.Length;
        int newNumberOfPlants = 0;
        int dayCount = -1;

        //initialize first stack
        for(int i = 0; i < p.Length; i++){
            stack1.Push(p[i]);
        }

        while(initialNumberOfPlants != newNumberOfPlants){
            dayCount++;
            initialNumberOfPlants = stack1.Count;
            while(stack1.Count !=0){
                var current = stack1.Peek();
                stack1.Pop();
                if(stack1.Count == 0){
                    stack2.Push(current);
                    continue;
                }
                var left = stack1.Peek();
                if(current <= left){
                    stack2.Push(current);
                }
            }
                newNumberOfPlants = stack2.Count;
                if(newNumberOfPlants == initialNumberOfPlants){
                    return dayCount;
                }
                dayCount++;

                initialNumberOfPlants = newNumberOfPlants;
                var first = stack2.Peek();
                stack1.Push(first);

                while(stack2.Count !=0){
                    var current = stack2.Peek();
                    stack2.Pop();
                    if(stack2.Count == 0){
                        continue;
                    }
                    var left = stack2.Peek();
                    if(left <= current){
                        stack1.Push(left);
                    }
                }              
                newNumberOfPlants = stack1.Count;
            }
            
             return dayCount;
        
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
