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

    /// <summary>
    /// Buscar los numeros perdidos.
    /// </summary>
    /// <param name="arr">Primera lista</param>
    /// <param name="brr">Segunda lista</param>
    /// <returns>
    /// Array con el listado de los numeros perdidos.
    /// </returns>
    static int[] missingNumbers(int[] arr, int[] brr) {
        
        //Guardar el resultado
        List<int> result = new List<int>(); 
        
        //Se ordenan los arrays
        Array.Sort(arr);
        
        //Recorrer el array brr
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

    //Metodo de inicio
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int m = Convert.ToInt32(Console.ReadLine());

        int[] brr = Array.ConvertAll(Console.ReadLine().Split(' '), brrTemp => Convert.ToInt32(brrTemp))
        ;
        
        //Ordenar segunda lista.
        Array.Sort(brr);
        
        //Configuracion Constraints
        if((n <= m) && (n >= 1) && (m <= 200000) && (brr[0] - brr[m-1] <= 100)){
            int[] result = missingNumbers(arr, brr);
            textWriter.WriteLine(string.Join(" ", result));    
        }
            
        textWriter.Flush();
        textWriter.Close();
    }
}
