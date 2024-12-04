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
    static int search(string[] lines, int startr, int startc)
    {
        int found = 0;
        int rows = lines.Length;
        int cols = lines[0].Length;

        int[] deltas = { -1, 0, 1 };
        foreach (int dr in deltas)
        {
            foreach (int dc in deltas)
            {
                if (dr == 0 && dc == 0)
                {
                    continue;
                }
                string goal = "XMAS";
                int pos = 0;
                while (pos < goal.Length)
                {
                    int r = startr + pos * dr;
                    int c = startc + pos * dc;
                    if (r < 0 || r >= rows || c < 0 || c >= cols)
                    {
                        break;
                    }
                    if (lines[r][c] != goal[pos])
                    {
                        break;
                    }
                    pos++;
                }
                if (pos == goal.Length)
                {
                    found++;
                }
            }
        }
        return found;
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
                if (lines[r][c] == 'X')
                {
                    sum += search(lines, r, c);
                }
            }
        }

        Console.WriteLine($"day 04p1: {sum}" );
    }
}
