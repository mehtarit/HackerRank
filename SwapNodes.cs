using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {

    /*
     * Complete the swapNodes function below.
     */

    public class TreeNode {
       public  TreeNode RightChild {get; set;}
       public  TreeNode LeftChild {get; set;}
       public  int Depth {get; set;}
       public  int Index {get; set;}
       public  TreeNode Parent {get; set;}
    }


   static void InOrderTraversal(TreeNode root, List<int> result)
   {
       if(root == null) return;
       if(root.LeftChild!=null){
           InOrderTraversal(root.LeftChild, result);
       }
       result.Add(root.Index);
       if(root.RightChild!=null){
           InOrderTraversal(root.RightChild, result);
       }
   }

   static void Print(List<int> list){
       foreach(var number in list){
           Console.Write(number + " ");
       }
       Console.WriteLine();
   }
   static TreeNode BuildTree(int[][] indexes, int i,  int depth, int index){
        
        if(i >= indexes.Length) return null;

        var arr = indexes[i];
        var result = new TreeNode {
            Depth = depth,
            Index = index,
            Parent = null
        };
        
        if(arr[0] == -1){
            result.LeftChild = null;
        }
        else{
            i++;
            result.LeftChild = BuildTree(indexes, i, depth+1, arr[0]);
        }
        if(arr[1] == -1){
            result.RightChild = null;
        }
        else{
            i++;           
            result.RightChild= BuildTree(indexes, i, depth+1, arr[1]);
        }

        if(result.LeftChild !=null) result.LeftChild.Parent = result;
        if(result.RightChild !=null) result.RightChild.Parent = result;
        return result;       
    }

    static int[][] swapNodes(int[][] indexes, int[] queries) {
        int queryCount = queries.Length;
        int [][] result = new int[queryCount][];

       TreeNode root = BuildTree(indexes, 0, 1, 1);
       

        var listToPrint = new List<int>();
       InOrderTraversal(root, listToPrint);
       Print(listToPrint);

        //want to see it has the correct array

        for(int i = 0; i< queries.Length; i++)
        {
            int k = queries[i];
            break;
            //todo: Breadth first traversal 
            //if depth is multiple of k, swap its children.
            
            //todo: depth first traversal add to list
           // var inOrderTraversal = InOrderTraversal(root);
            //result[i] = inOrderTraversal;
            //assign array to result[i];
        }

        return result;

    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[][] indexes = new int[n][];

        for (int indexesRowItr = 0; indexesRowItr < n; indexesRowItr++) {
            indexes[indexesRowItr] = Array.ConvertAll(Console.ReadLine().Split(' '), indexesTemp => Convert.ToInt32(indexesTemp));
        }

        int queriesCount = Convert.ToInt32(Console.ReadLine());

        int[] queries = new int [queriesCount];

        for (int queriesItr = 0; queriesItr < queriesCount; queriesItr++) {
            int queriesItem = Convert.ToInt32(Console.ReadLine());
            queries[queriesItr] = queriesItem;
        }

        int[][] result = swapNodes(indexes, queries);

       // textWriter.WriteLine(String.Join("\n", result.Select(x => String.Join(" ", x))));

        textWriter.Flush();
        textWriter.Close();
    }
}
