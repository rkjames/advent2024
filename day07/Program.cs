using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("example.txt");
        //string[] lines = File.ReadAllLines("input.txt");

        foreach (var line in lines)
        {
            Console.WriteLine(line);
        }

        int sum = 0;


        Console.WriteLine($"day 07p1: {sum}");
    }
}
