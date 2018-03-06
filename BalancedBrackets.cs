using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        int t = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < t; a0++){
            string expression = Console.ReadLine();
            if(IsBalanced(expression)) Console.WriteLine("YES");
            else Console.WriteLine("NO");
        }
    }
    
    static bool IsBalanced(string brackets)
    {
        if(string.IsNullOrEmpty(brackets)) return false;
        if(brackets.Length == 0)return false;
        if(brackets.Length % 2 != 0) return false;
        
        Stack<char> bracketStack = new Stack<char>();
        
        foreach(var c in brackets)
        {
            if(c == '{') bracketStack.Push('}');
            else if(c == '[') bracketStack.Push(']');
            else if(c == '(') bracketStack.Push(')');
            else if(bracketStack.Count ==0 || c != bracketStack.Peek())return false;
            else bracketStack.Pop();
        }
        
        return bracketStack.Count == 0;
    }
}