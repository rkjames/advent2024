using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        //string[] lines = File.ReadAllLines("example.txt");
        string[] lines = File.ReadAllLines("input.txt");

        int sum = 0;
        var before = new Dictionary<int, List<int>>();
        foreach (string line in lines)
        {
            if (line.Contains("|"))
            {
                var s = line.Split("|");
                int key = int.Parse(s[0]);
            }
        }

        Console.WriteLine($"day 06p1: {sum}");
    }
}
