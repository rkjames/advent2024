using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("example.txt");
        //string[] lines = File.ReadAllLines("input.txt");

        var s = lines[0].Split();
        Console.WriteLine($"day 12p1: 42");
    }
}
