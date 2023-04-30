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
     * Complete the 'dayOfProgrammer' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts INTEGER year as parameter.
     */

    public static string dayOfProgrammer(int year)
    {
        string leap = "12.09.";
        string notLeap = "13.09.";
        string year1918 = "26.09.";

        if (year < 1918)
        {
            if (year % 4 == 0)
            {
                return leap + year;
            }
            else
            {
                return notLeap + year;
            }
        }
        else
        {
            if (year > 1918)
            {
                if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
                {
                    return leap + year;
                }
                else
                {
                    return notLeap + year;
                }
            }
            else
            {
                return year1918 + year;
            }
        }

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int year = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.dayOfProgrammer(year);

        Console.WriteLine(result);
        Console.ReadLine();
        /*
        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
        */
    }
}
