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

    // Complete the minTime function below.
    static long minTime(long[] machines, long goal) {
        long minGuess = 0;
        long maxGuess = machines.Min()*goal;
        if(machines.Length == 1){
            return maxGuess;
        }
        long guess = 0;
        long itemCount =0;

        while(minGuess != maxGuess)
        {
            guess = (long)Math.Floor((double)(minGuess+maxGuess)/2);
            itemCount =0;
            foreach(var machineTime in machines)
            {               
                var numItems = (long)Math.Floor((double)guess/machineTime);
                itemCount = itemCount + numItems;
                if(itemCount > goal)
                {
                    break;
                }
            }
            if(itemCount >= goal)
            {
                maxGuess = guess;
                continue;
            }

            minGuess = guess+1;
        }

        return minGuess;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nGoal = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nGoal[0]);

        long goal = Convert.ToInt64(nGoal[1]);

        long[] machines = Array.ConvertAll(Console.ReadLine().Split(' '), machinesTemp => Convert.ToInt64(machinesTemp))
        ;
        long ans = minTime(machines, goal);

        textWriter.WriteLine(ans);

        textWriter.Flush();
        textWriter.Close();
    }
}
