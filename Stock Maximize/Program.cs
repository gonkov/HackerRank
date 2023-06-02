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
     * Complete the 'stockmax' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts INTEGER_ARRAY prices as parameter.
     */

    public static long stockmax(long s, List<int> prices)
    {
        // 1st special case - the lenght of the List is 1
        if (prices.Count == 1)
        {
            return s;
        }
        // define maximum in the List
        int max = 0;
        int maxI = 0;
        for (int i = 0; i < prices.Count; i++)
        {
            if (prices[i] > max)
            {
                max = prices[i];
                maxI = i;
            }
        }

        // counting S to the maxI
        for (int i = 0; i < maxI + 1; i++)
        {
            s = s + prices[maxI] - prices[i];
        }

        // 2nd special case - the max element of the list is the last element of the list
        if (prices.Count == maxI + 1)
        {
            return s;
        }

        // recurse
        prices.RemoveRange(0,maxI + 1);
        return stockmax(s, prices);

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> prices = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(pricesTemp => Convert.ToInt32(pricesTemp)).ToList();

            long result = Result.stockmax(0, prices);
            Console.WriteLine(result);
            //textWriter.WriteLine(result);
        }
        Console.ReadLine();
        //textWriter.Flush();
        //textWriter.Close();
    }
}
