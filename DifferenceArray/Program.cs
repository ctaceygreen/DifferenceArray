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

class Solution
{

    // Complete the arrayManipulation function below.
    static long arrayManipulation(int n, int[][] queries)
    {
        long[] array = new long[n];
        for (long queryRow = 0; queryRow < queries.GetLength(0); queryRow++)
        {
            var query = queries[queryRow];
            int startIndex = query[0];
            int endIndex = query[1];
            long increment = query[2];
            array[startIndex - 1] += increment;
            if(endIndex < n)
            {
                array[endIndex] -= increment;
            }
        }
        long max = long.MinValue;
        long runningTotal = 0;
        for (int i = 0; i < array.Length; i++)
        {
            runningTotal += array[i];
            max = Math.Max(max, runningTotal);
        }
        return max;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nm = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nm[0]);

        int m = Convert.ToInt32(nm[1]);

        int[][] queries = new int[m][];

        for (int i = 0; i < m; i++)
        {
            queries[i] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
        }

        long result = arrayManipulation(n, queries);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
