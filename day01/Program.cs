// playing with advent 2024 day 1
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        int sum = 0;
        //string[] lines = File.ReadAllLines("example.txt");
        string[] lines = File.ReadAllLines("input.txt");
        var left = new List<int>();
        var right = new List<int>();

        foreach (string line in lines)
        {
            var s = line.Split();
            Console.WriteLine($"{s[0]} {s[3]}");
            left.Add(int.Parse(s[0]));
            right.Add(int.Parse(s[3]));
        }

        left.Sort();
        right.Sort();
        for (int i = 0; i < left.Count; i++)
        {
            int diff = Math.Abs(left[i] - right[i]);
            sum += diff;
        }

        Console.WriteLine($"day 01 {sum}");
    }
}
