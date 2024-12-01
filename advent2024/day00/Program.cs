// playing with advent 2023 day 1
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        int sum = 0;
        //string[] lines = File.ReadAllLines("example.txt"); 
        string[] lines = File.ReadAllLines("input.txt");
        foreach (string line in lines)
        {
            int first = 0;
            int last = 0;
            bool foundfirst = false;
            foreach (char c in line)
            {
                if (char.IsDigit(c)) {
                    last = int.Parse(c.ToString());
                    if (!foundfirst)
                    {
                        first = last;
                        foundfirst = true;
                    }
                }
            }
            Console.WriteLine(first + " " + last);
            sum += first * 10 + last; 
        }

        Console.WriteLine(sum);
    }
}