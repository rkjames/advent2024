// playing with advent 2024 day 1
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int sum = 0;
        string[] lines = File.ReadAllLines("example.txt");
        // string[] lines = File.ReadAllLines("input.txt");
        var left = new List<int>();
        var right = new List<int>();

        foreach (string line in lines)
        {
            var s = line.Split();
            // Console.WriteLine($"{s[0]} {s[3]}");
            left.Add(int.Parse(s[0]));
            right.Add(int.Parse(s[3]));
        }

        var count = new Dictionary<int, int>();
        foreach (int i in right)
        {
            if (count.ContainsKey(i))
            {
                count[i] += 1;
            }
            else
            {
                count.Add(i, 1);
            }
        }

        foreach (int i in left)
        {
            if (count.ContainsKey(i))
            {
                sum += i * count[i];
            }
        }

        Console.WriteLine($"day 01p2 {sum}");

        // LINQ: https://github.com/tmbarker/advent-of-code/blob/main/Solutions/Y2024/D01/Solution.cs
        Console.WriteLine("day 01p2 linq: " + left.Sum(i => i * right.Count(c => c == i)));
    }
}
