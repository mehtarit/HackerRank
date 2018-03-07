using System;
using System.Collections.Generic;
using System.IO;
public class Queue
{
    private Stack<int> Stack1;
    private Stack<int> Stack2; 
    
    public Queue()
    {
        Stack1 = new Stack<int>();
        Stack2 = new Stack<int>();
    }
    public void Enqueue(int data)
    {
        Stack1.Push(data);
    }
    
    public void Dequeue ()
    {
        PrepareDequeueStack();
        Stack2.Pop();
    }
    
    public void Print ()
    {
        PrepareDequeueStack();
        Console.WriteLine(Stack2.Peek());
    }
    
    private void PrepareDequeueStack()
    {
        if(Stack2.Count !=0 )return;
        while(Stack1.Count != 0)
        {
            Stack2.Push(Stack1.Pop());
        }
    }
}
class Solution {
    static void Main(String[] args) {
        int q = Convert.ToInt32(Console.ReadLine());
        Queue myQ = new Queue();
        for(int i = 0; i < q; i++)
        {
            string exp = Console.ReadLine();
            if(exp.Length == 1)
            {
                int ask = Convert.ToInt32(exp);
                if(ask == 2)myQ.Dequeue();
                if(ask == 3)myQ.Print();
                continue;
            }
            
            int numData = Convert.ToInt32(exp.Substring(2));
            myQ.Enqueue(numData);
        }
    }
}