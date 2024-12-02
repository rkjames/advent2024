using System;
//using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

// LINQ reminders
// Console.WriteLine("day 01p2 linq: " + left.Sum(i => i * right.Count(c => c == i)));
// var digits = line.Where(char.IsDigit).Select(c => int.Parse(c.ToString())).ToList();
class Program
{
    static void Main(string[] args)
    {
        //string[] lines = File.ReadAllLines("example.txt");
        string[] lines = File.ReadAllLines("input.txt");
        int safe_count = 0;

        foreach (string line in lines)
        {
            //Console.WriteLine(line);
            var s = line.Split();
            bool first = true;
            bool second = false;
            bool positive = false;
            bool safe = true;
            int prev = 0;
            foreach (var p in s)
            {
                var i = int.Parse(p);
                if (first)
                {
                    first = false;
                    second = true;
                    prev = i;
                    continue;                    
                }

                if (second)
                {
                    positive = prev < i;
                    second = false;
                }

                // The levels are either all increasing or all decreasing.
                if (positive && prev > i)
                {
                    //Console.WriteLine("positive: " + prev + " " + i);
                    safe = false;
                    break;
                }

                if (!positive && prev < i)
                {
                    //Console.WriteLine("!positive: " + prev + " " + i);
                    safe = false;
                    break;
                }

                // Any two adjacent levels differ by at least one and at most three.
                var delta = Math.Abs(prev - i);
                if (delta < 1 || delta > 3)
                {
                    //Console.WriteLine("delta: " + delta);
                    safe = false;
                    break;
                }

                prev = i;
            }

            if (safe)
            {
                //Console.WriteLine("safe");
                safe_count++;
            }

            //Console.WriteLine();
        }

        Console.WriteLine("day 02p1: " + safe_count);

    }
}
