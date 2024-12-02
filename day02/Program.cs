using System;
//using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

// LINQ reminder
// Console.WriteLine("day 01p2 linq: " + left.Sum(i => i * right.Count(c => c == i)));
class Program
{
    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("example.txt");
        // string[] lines = File.ReadAllLines("input.txt");
        var left = new List<int>();

        foreach (string line in lines)
        {
            var s = line.Split();
            Console.WriteLine($"{s[0]} {s[3]}");
            left.Add(int.Parse(s[0]));
        }

    }
}
