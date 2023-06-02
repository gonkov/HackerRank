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

class Solution
{

    // !!! NOT FINISHED !!!!
    static int getMinimumCost(int k, int[] c)
    {
        int l = c.Length;
        // just sorting
        for (int i = 0; i < l; i++)
        {
            for (int j = 0; j < l - 1; j++)
            {
                if (c[j] < c[j+1] )
                {
                    int bufer = c[j];
                    c[j] = c[j+1];
                    c[j+1] = bufer;
                }
            }
        }

        // counting
        int mult = 1;
        int count = 0;
        int vspom = 0;
        for (int i = 0; i < l - k; i=i+k)
        {
            for (int j = 0; j < k; j++)
            {
                count = count + c[i + j]*mult;
            }
            mult++;
            vspom = i;
        }
        for (int i = vspom; i < l; i++)
        {
            count = count + c[i] * mult;
            mult++;
        }
        return count;

    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nk = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nk[0]);

        int k = Convert.ToInt32(nk[1]);

        int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp))
        ;
        int minimumCost = getMinimumCost(k, c);

        textWriter.WriteLine(minimumCost);

        textWriter.Flush();
        textWriter.Close();
    }
}
