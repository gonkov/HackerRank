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
     * Complete the 'biggerIsGreater' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING w as parameter.
     */

    public static string biggerIsGreater(string w)
    {
        int l = w.Length;
        for (int i = l - 1; i > 0; i--)
        {
            if (w[i] > w[i - 1])
            {
                // find 'm' - minimum from 'i' to 'l - 1' , which is larger than 'i - 1'
                int m = i;
                for (int j = i + 1; j < l; j++)
                {
                    if (w[j] > w[i-1] && w[j] < w[m])
                    {
                        m = j;
                    }
                }

                // switch 'm' and 'i-1' letters
                string ch = w[m].ToString();
                w = w.Remove(m, 1);
                w = w.Insert(i - 1, ch);

                // sorting string from 'i' to 'l'
                for (int p = i; p < l - 1; p++)
                {
                    for (int q = p + 1; q < l; q++)
                    {
                        if (w[q] < w[p])
                        {
                            string ch_p = w[p].ToString();
                            string ch_q = w[q].ToString();
                            w = w.Remove(q, 1);
                            w = w.Insert(q, ch_p);
                            w = w.Remove(p, 1);
                            w = w.Insert(p, ch_q);
                        }
                    }
                }

                return w;
            }
        }
        return "no answer";
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int T = Convert.ToInt32(Console.ReadLine().Trim());

        for (int TItr = 0; TItr < T; TItr++)
        {
            string w = Console.ReadLine();

            string result = Result.biggerIsGreater(w);

            Console.WriteLine(result);

            //textWriter.WriteLine(result);
        }
        Console.ReadLine();

        /*
        textWriter.Flush();
        textWriter.Close();
        */
    }
}
