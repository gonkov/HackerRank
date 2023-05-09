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
     * Complete the 'nonDivisibleSubset' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. INTEGER_ARRAY s
     */

    public static int nonDivisibleSubset(int k, List<int> s)
    {
        if (k == 1)
        {
            return 1;
        }

        if (s.Count == 1)
        {
            return 1;
        }
        
        List<int> dict = new List<int>(k);
        for (int i = 0; i < k; i++)
        {
            dict.Add(0);
        }
        foreach (int item in s)
        {
            int ostatok = item % k;
            dict[ostatok]++;
        }
        int result = 0;
        if (dict[0] > 0)
        {
            result++;
        }
        for (int i = 1; i < k/2; i++)
        {
            if (dict[i] > dict[k-i])
            {
                result = result + dict[i];
            }
            else
            {
                result = result + dict[k-i];
            }
        }

        if ((k/2)*2 == k)
        {
            if (dict[k/2] > 0)
            {
                result++;
            }
        }
        else
        {
            if (dict[k/2] > dict[k/2 + 1])
            {
                result = result + dict[k/2];
            }
            else
            {
                result = result + dict[k/2 + 1];
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

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

        int res = Result.nonDivisibleSubset(k, s);

        Console.WriteLine(res);
        Console.ReadLine();

        /*
        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
        */
    }
}
