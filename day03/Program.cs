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

    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("example.txt");
        // string[] lines = File.ReadAllLines("input.txt");

        foreach (string line in lines)
        {
            //Console.WriteLine(line);
            var s = line.Split();

            foreach (var p in s)
            {
                var i = int.Parse(p);
            }

        }

        Console.WriteLine("day 03p1: " );
    }
}
