using System;
using System.IO;
using System.Collections.Generic;
using System.Linq.Expressions;

class Program
{
    // calculates perimeter of a cell that needs fence.
    static int perimeter(char[][] grid, int i, int j)
    {
        int ret = 0;
        char c = grid[i][j];

        if (i == 0 || grid[i-1][j] != c)
        {
            ret++;
        }
        if (i == grid.Length - 1 || grid[i+1][j] != c)
        {
            ret++;
        }
        if (j == 0 || grid[i][j-1] != c)
        {
            ret++;
        }
        if (j == grid[i].Length -1|| grid[i][j+1] != c)
        {
            ret++;
        }

        return ret;
    }

    static int visit(char[][] grid, int i, int j)
    {
        int c = grid[i][j];

        // identify all cells
        var s = new HashSet<(int, int)>();
        s.Add((i, j));
        int size = s.Count;
        for (; ; )
        {
            var itercopyset = new HashSet<(int, int)>(s);
            foreach (var p in itercopyset)
            {
                int x = p.Item1;
                int y = p.Item2;
                if (x > 0 && grid[x - 1][y] == c)
                {
                    s.Add((x - 1, y));
                }
                if (x < grid.Length - 1 && grid[x + 1][y] == c)
                {
                    s.Add((x + 1, y));
                }
                if (y > 0 && grid[x][y - 1] == c)
                {
                    s.Add((x, y - 1));
                }
                if (y < grid[x].Length - 1 && grid[x][y + 1] == c)
                {
                    s.Add((x, y + 1));
                }
            }

            if (s.Count == size)
            {
                // no growth
                break;
            }
            size = s.Count;
        }

        // calculate perimeter
        int perim = 0;
        foreach (var p in s)
        {
            int x = p.Item1;
            int y = p.Item2;
            perim += perimeter(grid, x, y);
        }

        // mark as visited
        foreach (var p in s)
        {
            int x = p.Item1;
            int y = p.Item2;
            grid[x][y] = '1';
        }

        return perim * s.Count;
    }

    static void Main(string[] args)
    {
        //string[] lines = File.ReadAllLines("example3.txt");
        string[] lines = File.ReadAllLines("input.txt");
        char[][] grid = new char[lines.Length][];
        for (int i = 0; i < lines.Length; i++)
        {
            grid[i] = lines[i].ToCharArray();
        }

        int sum = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] != '1')
                {
                    var c = grid[i][j];
                    var tmp = visit(grid, i, j);
                    Console.WriteLine($"{c} price {tmp}");
                    sum += tmp;
                }
            }
        }

        Console.WriteLine($"day 12p1: {sum}");
    }
}
