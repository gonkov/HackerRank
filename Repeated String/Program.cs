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
     * Complete the 'repeatedString' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. LONG_INTEGER n
     */

    public static long repeatedString(string s, long n)
    {
        long l = s.Length;
        long m = n / l; // l = m * l + r;
        long r = n % l;
        long c_1 = 0; // counter for multiplier m
        long c_2 = 0; // counter for modulo r

        if (m > 0)
        {
            foreach (char item in s)
            {
                if (item == 'a')
                {
                    c_1++;
                }
                            
            }
        }
        for (int i = 0; i < r; i++)
        {
            if (s[i] == 'a')
            {
                c_2++;
            }
        }
        return (c_1 * m) + c_2;

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        long n = Convert.ToInt64(Console.ReadLine().Trim());

        long result = Result.repeatedString(s, n);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
