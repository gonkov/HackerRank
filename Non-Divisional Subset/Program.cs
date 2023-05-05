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
        int l = s.Count;
        for (int i = 0; i < l - 1; i++)
        {
            for (int j = i + 1; j < l; j++)
            {
                if ((s[i] + s[j]) % k == 0)
                {
                    List<int> a = new List<int> (s);
                    List<int> b = new List<int> (s);
                    a.RemoveAt(i);
                    b.RemoveAt(j);
                    int l1 = nonDivisibleSubset(k, a);
                    int l2 = nonDivisibleSubset(k, b);
                    if (l1 > l2)
                    {
                        return l1;
                    }
                    else
                    {
                        return l2;
                    }

                }
            }
        }
        return s.Count;

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

        int result = Result.nonDivisibleSubset(k, s);

        Console.WriteLine(result);
        Console.ReadLine();

        /*
        textWriter.WriteLine(result);
        textWriter.Flush();
        textWriter.Close();
        */
    }
}
