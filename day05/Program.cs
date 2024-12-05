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

        var regex = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)|do\(\)|don't\(\)");
        int sum = 0;
        bool domul = true;

        foreach (string line in lines)
        {
            //Console.WriteLine($"Line: {line}");
            var matches = regex.Matches(line);
            foreach (Match match in matches)
            {
                switch (match.Value)
                {
                    case "do()":
                        //Console.WriteLine("Do");
                        domul = true;
                        break;
                    case "don't()":
                        //Console.WriteLine("Don't");
                        domul = false;
                        break;
                    default:
                        //Console.WriteLine($"Match: {match.Value}");
                        //Console.WriteLine($"Group 1: {match.Groups[1].Value}");
                        //Console.WriteLine($"Group 2: {match.Groups[2].Value}");
                        if (domul)
                            sum += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
                        break;
                }
            }
        }

        Console.WriteLine($"day 05p1: {sum}" );
    }
}
