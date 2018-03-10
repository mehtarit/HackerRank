using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    
    static Dictionary<int, int> map = new Dictionary<int, int>();
    static int GetNumWays(int n)
    {
        if(n==1)return 1;
        if(n==2)return 2;
        if(n==3)return 4;
        if(!map.ContainsKey(n))
        {
            int numWays = GetNumWays(n-1) + GetNumWays(n-2) + GetNumWays(n-3);
            map.Add(n, numWays);
        }
        return map[n];
    }

    static void Main(String[] args) {
        int s = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < s; a0++){
            int n = Convert.ToInt32(Console.ReadLine());            
            int numWays = GetNumWays(n);
            Console.WriteLine(numWays);
            
        }
    }
}
