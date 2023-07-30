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

class Result
{

    /*
     * Complete the 'organizingContainers' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts 2D_INTEGER_ARRAY container as parameter.
     */

    public static string organizingContainers(List<List<int>> container , int n)
    {
        /*if (n == 1)
        {
            return "Possible";

        }*/
        for (int z = 0; z < n; z++)
        {
            for (int i = 0; i < n; i++)
            {
                int sum_i = 0;
                for (int j = 0; j < n; j++)
                {
                    sum_i = sum_i + container[i][j];
                }
                int sum_j = 0;
                for (int k = 0; k < n; k++)
                {
                    sum_j = sum_j + container[k][z];
                }

                if (sum_i == sum_j)
                {
                    i = n; // exit from 'for (int i = 0; i < n; i++)'
                    //swap();
                }
                if (i == n - 1)
                {
                    return "Impossible"; // was no 'exit' , so it is impossible
                }
            }
        }
        return "Possible";


    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> container = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                container.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(containerTemp => Convert.ToInt32(containerTemp)).ToList());
            }

            string result = Result.organizingContainers(container, n);
            Console.WriteLine(result);
            Console.ReadLine();
            //textWriter.WriteLine(result);
        }

        //textWriter.Flush();
        //textWriter.Close();
    }
}
