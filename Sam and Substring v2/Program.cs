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
    [Serializable]
    public class ErrorWhileMunising : Exception
    {
        public ErrorWhileMunising(string message)
            : base(message) { }
    }

      /*
  Time Limit on Big Data; 
      */
    public static int substrings(string n)
    {
        // convert input string to the list
        List<int> x = new List<int>();
        for (int i = 0; i < n.Length; i++)
        {
            x.Add(Convert.ToInt32(n[i].ToString()));
        }
        List<int> m = new List<int>() { 1, 0, 0, 0, 0, 0, 0, 0, 0, 7 };

        List<int> sum = new List<int>(); // the resulting sum

        // main code
        List<long> mainList = new List<long>();
        long sum_for_mainList = 0;
        for (int i = 0; i < x.Count; i++)
        {
            sum_for_mainList = sum_for_mainList + x[i]*(i+1);
            mainList.Add(sum_for_mainList);
        }
        for (int i = x.Count-1; i > 0; i--)
        {
            sum.Insert(0, Convert.ToInt32(mainList[i]%10));
            mainList[i - 1] = mainList[i - 1] + mainList[i] / 10;
        }
        while (mainList[0] > 0)
        {
            sum.Insert(0, Convert.ToInt32(mainList[0] % 10));
            mainList[0] = mainList[0] / 10;
        }

        sum = Modulo2(sum, m); // bringing the result to the modulo 10^9 + 7;

        // converting the result to Int 32
        string s = "";
        foreach (int item in sum)
        {
            s = s + item.ToString();
        }

        return Convert.ToInt32(s);

    }

    private static List<int> Modulo(List<int> sum, List<int> m)
    {

        while (ifMoreOrEqual(sum, m))
        {
            List<int> m_temp = new List<int>(m);
            m_temp.Add(0);
            while (ifMoreOrEqual(sum, m_temp))
            {
                m_temp.Add(0);
            }
            m_temp.RemoveAt(m_temp.Count - 1);
            while (ifMoreOrEqual(sum, m_temp))
            {
                sum = Minus(sum, m_temp);
            }

        }
        return sum;
    }
    private static List<int> Modulo2(List<int> sum, List<int> m)
    {
        List<int> m_temp = new List<int>(m);
        m_temp.Add(0);
        while (ifMoreOrEqual(sum, m_temp))
        {
            m_temp.Add(0);
        }
        while (ifMoreOrEqual(m_temp, m))
        {
            while (ifMoreOrEqual(sum, m_temp))
            {
                sum = Minus(sum, m_temp);
            }
            m_temp.RemoveAt(m_temp.Count - 1);
        }
        return sum;
    }
    private static bool ifMoreOrEqual(List<int> sum, List<int> m)
    {
        if (sum.Count > m.Count)
        {
            return true;
        }
        if (sum.Count < m.Count)
        {
            return false;
        }
        for (int i = 0; i < sum.Count; i++)
        {
            if (sum[i] > m[i])
            {
                return true;
            }
            if (sum[i] < m[i])
            {
                return false;
            }
        }
        return true;
    }
    public static List<int> Plus(List<int> a, List<int> b)
    {
        int perenos = 0;

        if (a.Count > b.Count)
        {
            int i = a.Count - 1;
            int j = b.Count - 1;
            while (j >= 0)
            {
                a[i] = a[i] + b[j];
                if (perenos == 1)
                {
                    a[i] = a[i] + 1;
                    perenos--;
                }
                if (a[i] > 9)
                {
                    a[i] = a[i] - 10;
                    perenos++;
                }
                i--;
                j--;
            }
            while (i >= 0)
            {
                if (perenos == 1)
                {
                    a[i] = a[i] + 1;
                    perenos--;
                }
                if (a[i] > 9)
                {
                    a[i] = a[i] - 10;
                    perenos++;
                }
                i--;
            }
            if (perenos == 1)
            {
                a.Insert(0, 1);
            }
            return a;
        }

        else
        {
            int i = b.Count - 1;
            int j = a.Count - 1;
            while (j >= 0)
            {
                b[i] = b[i] + a[j];
                if (perenos == 1)
                {
                    b[i] = b[i] + 1;
                    perenos--;
                }
                if (b[i] > 9)
                {
                    b[i] = b[i] - 10;
                    perenos++;
                }
                i--;
                j--;
            }
            while (i >= 0)
            {
                if (perenos == 1)
                {
                    b[i] = b[i] + 1;
                    perenos--;
                }
                if (b[i] > 9)
                {
                    b[i] = b[i] - 10;
                    perenos++;
                }
                i--;
            }
            if (perenos == 1)
            {
                b.Insert(0, 1);
            }
            return b;
        }
    }
    public static List<int> Minus(List<int> a, List<int> b) // a must be > than b.
    {
        List<int> p = new List<int>();
        Normalize(a, b);
        int perenos = 0;
        for (int i = a.Count - 1; i > 0 - 1; i--)
        {
            p.Insert(0, a[i] - b[i]);
            if (perenos == 1)
            {
                p[0] = p[0] - 1;
                perenos--;
            }
            if (p[0] < 0)
            {
                p[0] = p[0] + 10;
                perenos++;
            }
        }
        if (perenos != 0)
        {
            throw new ErrorWhileMunising("Error While minusing."); // Exception , if the result (p) is negative (<0).
        }
        DeleteZeroS(p);
        DeleteZeroS(b);
        return p;
    }
    public static void Normalize(List<int> x, List<int> y)
    {
        while (x.Count > y.Count)
        {
            y.Insert(0, 0);
        }
        while (y.Count > x.Count)
        {
            x.Insert(0, 0);
        }
    }
    public static void DeleteZeroS(List<int> x)
    {
        while (x.Count > 0 && x[0] == 0)
        {
            x.RemoveAt(0);
        }

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string n = Console.ReadLine();

        int result = Result.substrings(n);

        Console.WriteLine(result);
        Console.ReadLine();

        /*
        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
        */
    }
}
