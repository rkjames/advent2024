using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Numerics;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

class Program
{
    // returns true if even split happened
    static bool Split(BigInteger num, ref BigInteger first, ref BigInteger second)
    {
        first = 0;
        second = 0;

        // check if even
        var temp = num;
        int count = 0;
        while (temp != 0)
        {
            temp /= 10;
            count++;
        }

        if (count % 2 != 0)
        {
            return false;
        }

        BigInteger mask = BigInteger.Pow(10, count / 2);
        first = num / mask;
        second = num % mask;

        return true;
    }

    // memoization (current number, depth to seek) -> count
    static Dictionary<(BigInteger, int), BigInteger> memo = new Dictionary<(BigInteger, int), BigInteger>();

    static BigInteger recurse(BigInteger num, int depth)
    {
        if (depth == 0)
        {
            return 1;
        }

        if (memo.ContainsKey((num, depth)))
        {
            return memo[(num, depth)];
        }

        BigInteger ret = 1;

        if (num == 0)
        {
            ret = recurse(1, depth - 1);
        }
        else
        {

            BigInteger first = 0;
            BigInteger second = 0;
            if (Split(num, ref first, ref second))
            {
                ret = recurse(first, depth - 1) + recurse(second, depth - 1);
            }
            else
            {
                ret = recurse(num * 2024, depth - 1);
            }
        }

        memo.Add((num, depth), ret);

        return ret;
    }

    static void Main(string[] args)
    {
        //string[] lines = File.ReadAllLines("example.txt");
        string[] lines = File.ReadAllLines("input.txt");

        var s = lines[0].Split();
        for (int steps = 1; steps < 76; steps++)
        {
            BigInteger sum = 0;
            foreach (var chunk in s)
            {
                sum += recurse(BigInteger.Parse(chunk), steps);
            }
            Console.WriteLine($"day 11p2, step {steps}: {sum}");
        }
    }
}
