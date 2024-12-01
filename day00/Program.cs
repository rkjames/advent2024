// playing with advent 2023 day 1
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        int sum = 0;
        string[] lines = File.ReadAllLines("input.txt");

        foreach (string line in lines)
        {
            var digits = line.Where(char.IsDigit).Select(c => int.Parse(c.ToString())).ToList();

            if (digits.Count > 0)
            {
                int firstDigit = digits.First();
                int lastDigit = digits.Last();
                Console.WriteLine($"{firstDigit} {lastDigit}");
                sum += firstDigit * 10 + lastDigit;
            }
            else
            {
                Console.WriteLine("No digits found in line.");
            }
        }

        Console.WriteLine(sum);
    }
}
