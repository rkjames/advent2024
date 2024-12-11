using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("example.txt");
        //string[] lines = File.ReadAllLines("input.txt");

        int sum = 0;

        for (int rowobs = 0; rowobs < lines.Length; rowobs++)
        {
            for (int colobs = 0; colobs < lines[0].Length; colobs++)
            {
                // strings are immutable.
                char[][] grid = new char[lines.Length][];
                for (int i = 0; i < lines.Length; i++)
                {
                    grid[i] = lines[i].ToCharArray();
                }

            }
        }

        Console.WriteLine($"day 11p1: {sum}");
    }
}
