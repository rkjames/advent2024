using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.ExceptionServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    // returns true if even split happened
    static bool Split(int num, ref int first, ref int second)
    {
        first = 0;
        second = 0;

        // check if even
        var temp = num;
        int count = 0;
        while (temp != 0)
        {
            temp /= 10;
            count++;
        }

        if (count % 2 != 0)
        {
            return false;
        }

        int mask = (int)Math.Pow(10, count/2);
        first = num / mask;
        second = num % mask;

        return true;
    }

    static void Main(string[] args)
    {
        //string[] lines = File.ReadAllLines("example.txt");
        string[] lines = File.ReadAllLines("input.txt");

        var list = new LinkedList<int>();
        var s = lines[0].Split();
        foreach (var chunk in s)
        {
            list.AddLast(int.Parse(chunk));
        }

        for (int i = 0; i < 25; i++)
        {
            var cur = list.First;
            while (cur != null)
            {
                if (cur.Value == 0)
                {
                    cur.Value = 1;
                }
                else
                {
                    int first = 0;
                    int second = 0;
                    if (Split(cur.Value, ref first, ref second))
                    {
                        list.AddBefore(cur, first);
                        cur.Value = second;
                    }
                    else
                    {
                        var old = cur.Value;
                        cur.Value *= 2024;
                        if (cur.Value / 2024 != old)
                        {
                            throw new Exception($"overflow 2024: {old} {cur.Value}");
                        }
                    }
                }

                cur = cur.Next;
            }
        }

        Console.WriteLine($"day 11p1: {list.Count}");
        //foreach (var item in list)
        //{
        //    Console.Write(item + " ");
        //}
        //Console.WriteLine();
    }
}
