﻿using System.CodeDom.Compiler;
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
     * Complete the 'breakingRecords' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY scores as parameter.
     */

    public static List<int> breakingRecords(List<int> scores, int n)
    {
        List<int> result = new List<int>(2);
        result.Add(0);
        result.Add(0);        
        int max = scores[0];
        int min = scores[0];

        for (int i = 1; i < n; i++)
        {
            if (scores[i] > max)
            {
                max = scores[i];
                result[0] = result[0] + 1;
            }
            else
            {
                if (scores[i] < min)
                {
                    min = scores[i];
                    result[1] = result[1] + 1;
                }
            }
        }

        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> scores = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(scoresTemp => Convert.ToInt32(scoresTemp)).ToList();

        List<int> result = Result.breakingRecords(scores , n);

        Console.WriteLine(result[0]);
        Console.WriteLine(result[1]);
        Console.ReadLine();

        /*textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
        */
    }
}
