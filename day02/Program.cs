using System;
//using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;

// LINQ reminders
// Console.WriteLine("day 01p2 linq: " + left.Sum(i => i * right.Count(c => c == i)));
// var digits = line.Where(char.IsDigit).Select(c => int.Parse(c.ToString())).ToList();
class Program
{
    static bool check(List<int> list)
    {
        bool first = true;
        int prev = 0;

        bool positive = list.First() < list.Last();

        foreach (var i in list)
        {
            if (first)
            {
                first = false;
                prev = i;
                continue;
            }

            // The levels are either all increasing or all decreasing.
            if (positive && prev > i)
            {
                Console.WriteLine("positive: " + prev + " " + i);
                return false;
            }

            if (!positive && prev < i)
            {
                Console.WriteLine("!positive: " + prev + " " + i);
                return false;
            }

            // Any two adjacent levels differ by at least one and at most three.
            var delta = Math.Abs(prev - i);
            if (delta < 1 || delta > 3)
            {
                Console.WriteLine("delta: " + delta);
                return false;
            }

            prev = i;
        }

        return true;
    }

    static void Main(string[] args)
    {
        //string[] lines = File.ReadAllLines("example2.txt");
        string[] lines = File.ReadAllLines("input.txt");
        int safe_count = 0;

        foreach (string line in lines)
        {
            //Console.WriteLine(line);
            var s = line.Split();

            var list = new List<int>();

            foreach (var p in s)
            {
                var i = int.Parse(p);
                list.Add(i);
            }

            var safe = check(list);

            if (!safe)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    var clone = list.ToList();
                    clone.RemoveAt(i);
                    safe = check(clone);
                    if (safe)
                    {
                        break;
                    }
                }
            }

            if (safe)
            {
                Console.WriteLine("safe: " + line);
                safe_count++;
            }
            else
            {
                Console.WriteLine("unsafe: " + line);
            }

            //Console.WriteLine();
        }

        Console.WriteLine("day 02p1: " + safe_count);

    }
}
