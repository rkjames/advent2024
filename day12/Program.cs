using System;
using System.IO;
using System.Collections.Generic;
using System.Linq.Expressions;

class Program
{
    // add all perimeter pieces to perimeter set
    static void perimeter(char[][] grid, int i, int j, HashSet<(int, int, char)> perim)
    {
        char c = grid[i][j];

        if (i == 0 || grid[i - 1][j] != c)
        {
            perim.Add((i, j, 'u'));
        }
        if (i == grid.Length - 1 || grid[i + 1][j] != c)
        {
            perim.Add((i, j, 'd'));
        }
        if (j == 0 || grid[i][j - 1] != c)
        {
            perim.Add((i, j, 'l'));
        }
        if (j == grid[i].Length - 1 || grid[i][j + 1] != c)
        {
            perim.Add((i, j, 'r'));
        }
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
        // get all perimeter pieces
        // row, col, u/d/l/r
        var perim = new HashSet<(int, int, char)>();
        foreach (var p in s)
        {
            int x = p.Item1;
            int y = p.Item2;
            perimeter(grid, x, y, perim);
        }

        // apply discount, by discarding runs
        for (; ; )
        {
            var toRemove = new HashSet<(int, int, char)>();
            foreach (var p in perim)
            {
                int row = p.Item1;
                int col = p.Item2;
                char d = p.Item3;

                // check for horizontal runs
                if (d == 'u' || d == 'd')
                {
                    // remove to the right
                    for (int cur = col + 1; cur < grid[row].Length; cur++)
                    {
                        if (!perim.Contains((row, cur, d)))
                        {
                            break;
                        }
                        toRemove.Add((row, cur, d));
                    }

                    // remove to the left
                    for (int cur = col - 1; cur >= 0; cur--)
                    {
                        if (!perim.Contains((row, cur, d)))
                        {
                            break;
                        }
                        toRemove.Add((row, cur, d));
                    }
                }

                // check for vertical runs
                if (d == 'l' || d == 'r')
                {
                    // remove down
                    for (int cur = row + 1; cur < grid.Length; cur++)
                    {
                        if (!perim.Contains((cur, col, d)))
                        {
                            break;
                        }
                        toRemove.Add((cur, col, d));
                    }

                    // remove up
                    for (int cur = row - 1; cur >= 0; cur--)
                    {
                        if (!perim.Contains((cur, col, d)))
                        {
                            break;
                        }
                        toRemove.Add((cur, col, d));
                    }
                }

                if (toRemove.Count > 0)
                {
                    break;
                }
            }

            if (toRemove.Count == 0)
            {
                // no removals
                break;
            }
            perim.ExceptWith(toRemove);
        }


        // mark as visited
        foreach (var p in s)
        {
            int x = p.Item1;
            int y = p.Item2;
            grid[x][y] = '1';
        }

        return perim.Count * s.Count;
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

        Console.WriteLine($"day 12p2: {sum}");
    }
}
