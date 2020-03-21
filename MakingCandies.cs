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

    // Complete the minimumPasses function below.
    static long minimumPasses(long m, long w, long p, long n) {

        long current = 0;
        long numPasses = 0;
        long halfGoal = 0;

        if(n % 2 == 0) halfGoal = n/2;
        else halfGoal = n/2 +1;

        current = m*w;
        numPasses++;

        while(current < n)
        {
            if(current >= p){
                if(m < w){
                    long remainder = current % p;
                    long usedCandy = current - remainder;
                    long numMachinesToBuy = usedCandy/p;
                    current = current - usedCandy;
                    m = m + numMachinesToBuy;
                }
                else {
                    long remainder = current % p;
                    long usedCandy = current - remainder;
                    long numWorkersToBuy = usedCandy/p;
                    current = current - usedCandy;
                    w = w + numWorkersToBuy;
                }
            }

            long candyToBeAdded = m*w;
            current= current+(m*w);
            numPasses++;
            if(current + candyToBeAdded >= n){
                numPasses ++;
                break;
            }         
        }
        return numPasses;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] mwpn = Console.ReadLine().Split(' ');

        long m = Convert.ToInt64(mwpn[0]);

        long w = Convert.ToInt64(mwpn[1]);

        long p = Convert.ToInt64(mwpn[2]);

        long n = Convert.ToInt64(mwpn[3]);

        long result = minimumPasses(m, w, p, n);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
