using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Numerics;

class Program
{
    static bool exists(BigInteger current, BigInteger target, List<int> l)
    {
        if (l.Count == 0)
        {
            return current == target;
        }

        var next = l.First();
        l.RemoveAt(0);
        if (exists(current + next, target, l.ToList()))
        {
            return true;
        }
        if (exists(current * next, target, l.ToList()))
        {
            return true;
        }
        var s = current.ToString() + next.ToString();
        var weird = BigInteger.Parse(s);
        if (exists(weird, target, l.ToList()))
        {
            return true;
        }

        return false;
    }

    static void Main(string[] args)
    {
        //string[] lines = File.ReadAllLines("example.txt");
        string[] lines = File.ReadAllLines("input.txt");

        BigInteger sum = 0;

        foreach (var line in lines)
        {
            // target
            var s = line.Split(":");
            var target = BigInteger.Parse(s[0]);

            // numbers
            var l = new List<int>();
            s = s[1].Trim().Split();
            foreach (var num in s)
            {
                l.Add(int.Parse(num));
            }

            if (exists(0, target, l.ToList()))
            {
                Console.WriteLine($"{line} --> {target}");
                sum += target;
            }

        }



        Console.WriteLine($"day 07p1: {sum}");
    }
}
