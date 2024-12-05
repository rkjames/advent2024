using System;
//using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

// LINQ reminders
// Console.WriteLine("day 01p2 linq: " + left.Sum(i => i * right.Count(c => c == i)));
// var digits = line.Where(char.IsDigit).Select(c => int.Parse(c.ToString())).ToList();
class Program
{

    static void Main(string[] args)
    {
        //string[] lines = File.ReadAllLines("example.txt");
        string[] lines = File.ReadAllLines("input.txt");

        int sum = 0;
        var before = new Dictionary<int, List<int>>();
        foreach (string line in lines)
        {
            if (line.Contains("|"))
            {
                var s = line.Split("|");
                int key = int.Parse(s[0]);
                int value = int.Parse(s[1]);
                if (!before.ContainsKey(key))
                {
                    before[key] = new List<int>();
                }
                before[key].Add(value);
            }
            if (line.Contains(","))
            {
                var s = line.Split(",");
                var list = new List<int>();
                var valid = true;
                foreach (var num in s)
                {
                    list.Add(int.Parse(num));
                }

                for (int i = 0; i < list.Count; i++)
                {
                    if (before.ContainsKey(list[i]))
                    {
                        for (int j = 0; j < i; j++)
                        {
                            if (before[list[i]].Contains(list[j]))
                            {
                                valid = false;
                                break;
                            }
                        }
                    }
                }

                if (valid)
                {
                    sum += list[list.Count / 2];
                }
            }
        }

        Console.WriteLine($"day 05p1: {sum}" );
    }
}
