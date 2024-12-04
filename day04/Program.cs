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
    static char check(string[] lines, int r, int c)
    {
        if (r < 0 || r >= lines.Length || c < 0 || c >= lines[0].Length)
        {
            return ' ';
        }
        return lines[r][c];
    }
    static bool search(string[] lines, int r, int c)
    {
        // top left to bottom right
        if ((check(lines, r-1, c-1) == 'M' && check(lines,r+1,c+1) == 'S') ||
            (check(lines, r - 1, c - 1) == 'S' && check(lines, r + 1, c + 1) == 'M'))
        {
            // top right to bottom left
            if ((check(lines, r - 1, c + 1) == 'M' && check(lines, r + 1, c - 1) == 'S') ||
                (check(lines, r - 1, c + 1) == 'S' && check(lines, r + 1, c - 1) == 'M'))
            {
                return true;
            }
        }
        return false;
    }

    static void Main(string[] args)
    {
        // string[] lines = File.ReadAllLines("example.txt");
        string[] lines = File.ReadAllLines("input.txt");

        int sum = 0;
        int rows = lines.Length;
        int cols = lines[0].Length;
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (lines[r][c] == 'A')
                {
                    if (search(lines, r, c))
                    {
                        sum++;
                    }
                }
            }
        }

        Console.WriteLine($"day 04p2: {sum}" );
    }
}
