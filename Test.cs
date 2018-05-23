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

    // Complete the missingNumbers function below.
    static int[] missingNumbers(int[] arr, int[] brr) {
        
        List<int> result = new List<int>();
        
        Array.Sort(arr);
        Array.Sort(brr);
        
        int ib = 0;
        
        for(int ia = 0; ia < arr.Length; ia++){
            if (arr[ia] != brr[ib]){
                if(!result.Contains(brr[ib])){
                    result.Add(brr[ib]);
                }
                
                ia -= 1;
            }  
            ib += 1;
        }
        
        int[] arrayResult = result.ToArray();
        Array.Sort(arrayResult);
        return arrayResult;

    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int m = Convert.ToInt32(Console.ReadLine());

        int[] brr = Array.ConvertAll(Console.ReadLine().Split(' '), brrTemp => Convert.ToInt32(brrTemp))
        ;
                
        int[] result = missingNumbers(arr, brr);
        textWriter.WriteLine(string.Join(" ", result));    
               
        textWriter.Flush();
        textWriter.Close();
    }
}
