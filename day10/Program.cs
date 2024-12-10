using System;
using System.IO;

class Program
{

    static int Search(int[,] top, int cur, int row, int col)
    {
        if (cur == 9)
        {
            top[row, col] = 99;
            return 1;
        }

        int maxrow = top.GetLength(0);
        int maxcol = top.GetLength(1);

        int sum = 0;
        int next = cur + 1;
        if (row > 0 && top[row - 1, col] == next)
        {
            sum += Search(top, next, row - 1, col);
        }
        if (row < maxrow - 1 && top[row + 1, col] == next)
        {
            sum += Search(top, next, row + 1, col);
        }
        if (col > 0 && top[row, col - 1] == next)
        {
            sum += Search(top, next, row, col - 1);
        }
        if (col < maxcol - 1 && top[row, col + 1] == next)
        {
            sum += Search(top, next, row, col + 1);
        }
        return sum;
    }

    static void Reset(int[,] top)
    {
        int maxrow = top.GetLength(0);
        int maxcol = top.GetLength(1);

        for (int i = 0; i < maxrow; i++)
        {
            for (int j = 0; j < maxcol; j++)
            {
                if (top[i, j] == 99)
                {
                    top[i, j] = 9;

                }
            }
        }
    }

    static void Main(string[] args)
    {
        int sum = 0;
        string[] lines = File.ReadAllLines("input.txt");
        //string[] lines = File.ReadAllLines("input.txt");

        int rows = lines.Length;
        int cols = lines[0].Length;
        int[,] top = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                top[i, j] = int.Parse(lines[i][j].ToString());
            }
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (top[i, j] == 0)
                {
                    sum += Search(top, 0, i, j);
                    Reset(top);
                }
            }
        }

        Console.WriteLine($"day 10p1: {sum}");
    }
}
