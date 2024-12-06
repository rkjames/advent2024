using System;
using System.IO;

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
        var g = new Guard();
        bool found = false;

        // strings are immutable.
        char[][] grid = new char[lines.Length][];
        for (int i = 0; i < lines.Length; i++)
        {
            grid[i] = lines[i].ToCharArray();
        }

        // parse
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

        if (found)
        {
            Console.WriteLine($"found start row: {g.row}, col: {g.col}");
        }
        else
        {
            Console.WriteLine("no start found");
            return;
        }

        // step according to rules
        int c = 0;
        while (true)
        {
            int nextrow = 0;
            int nextcol = 0;
            g.nextstep(out nextrow, out nextcol);

            // we're done if out of bounds
            if (nextrow < 0 || nextrow >= grid.Length || nextcol < 0 || nextcol >= grid[0].Length)
            {
                Console.WriteLine($"finished row: {nextrow}, col: {nextcol}");
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
            Console.WriteLine($"step to row: {g.row}, col: {g.col}");

            // debug break out
            //c++;
            //if (c > 10)
            //{
            //    Console.WriteLine("break 10 steps");
            //    break;
            //}
        }

        // count
        for (int row = 0; row < grid.Length; row++)
        {
            for (int col = 0; col < grid[row].Length; col++)
            {
                if (grid[row][col] == 'X')
                {
                    sum++;
                }
            }
        }

        Console.WriteLine($"day 06p1: {sum}");
    }
}
