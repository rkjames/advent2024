using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;

class Guard
{
    public int row = 0;
    public int col = 0;

    enum Direction
    {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3,
    };

    Direction facing = Direction.Up;

    public void nextstep(out int orow, out int ocol)
    {
        orow = row;
        ocol = col;
        switch (facing)
        {
            case Direction.Left:
                ocol = col - 1;
                break;
            case Direction.Right:
                ocol = col + 1;
                break;
            case Direction.Up:
                orow = row - 1;
                break;
            case Direction.Down:
                orow = row + 1;
                break;
        }
    }

    public void rotate()
    {
        facing = (Direction)(((int)facing + 1) % 4);
    }
}

class Program
{
    static void Main(string[] args)
    {
        //string[] lines = File.ReadAllLines("example.txt");
        string[] lines = File.ReadAllLines("input.txt");

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

                if (grid[rowobs][colobs] != '.')
                {
                    // only want to test obstructions in empty space.
                    continue;
                }
                grid[rowobs][colobs] = '#';

                // parse
                var g = new Guard();
                bool found = false;
                for (int row = 0; row < grid.Length && !found; row++)
                {
                    for (int col = 0; col < grid[row].Length; col++)
                    {
                        if (grid[row][col] == '^')
                        {
                            grid[row][col] = 'X';
                            g.row = row;
                            g.col = col;
                            found = true;
                        }
                    }
                }

                if (!found)
                {
                    Console.WriteLine("no start found");
                    return;
                }

                var cycle = new Dictionary<(int, int), int>();

                // step according to rules
                while (true)
                {
                    g.nextstep(out int nextrow, out int nextcol);

                    // we're done if out of bounds
                    if (nextrow < 0 || nextrow >= grid.Length || nextcol < 0 || nextcol >= grid[0].Length)
                    {
                        //Console.WriteLine($"finished row: {nextrow}, col: {nextcol}");
                        break;
                    }

                    // bugbug: cycle detection needed?

                    // obstacle?
                    if (grid[nextrow][nextcol] == '#')
                    {
                        g.rotate();
                        continue;
                    }

                    // update state.
                    g.row = nextrow;
                    g.col = nextcol;
                    grid[g.row][g.col] = 'X';
                    //Console.WriteLine($"step to row: {g.row}, col: {g.col}");

                    // no defaultdict in c#
                    cycle[(g.row, g.col)] = cycle.ContainsKey((g.row, g.col)) ? cycle[(g.row, g.col)] + 1 : 1;
                    if (cycle[(g.row, g.col)] > 4)
                    {
                        // cycle detected. note that a single cell might be visited multiple times without a cycle.
                        sum++;
                        break;
                    }
                }
            }
        }

        Console.WriteLine($"day 06p2: {sum}");
    }
}
