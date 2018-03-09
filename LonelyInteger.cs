using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] a_temp = Console.ReadLine().Split(' ');
        int[] a = Array.ConvertAll(a_temp,Int32.Parse);
        int[] bit = new int[101];
        
        foreach(int a_i in a)
        {
            if(bit[a_i] == 0)
            bit[a_i] =1;
            else bit[a_i] = 0;
        }
        
        for(int i = 0; i < 101; i++)
        {
            if (bit[i] == 1)
            {
                Console.WriteLine(i);
                return;
            }
        }
    }
}