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
        }

        Console.WriteLine($"day 10p1: {sum}");
    }
}
