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
                int value = int.Parse(s[1]);
                if (!before.ContainsKey(key))
                {
                    before[key] = new List<int>();
                }
                before[key].Add(value);
            }
            if (line.Contains(","))
            {
                var s = line.Split(",");
                var list = new List<int>();
                foreach (var num in s)
                {
                    list.Add(int.Parse(num));
                }

                var valid = true;
                var tweaked = false;
                while (true)
                {
                    valid = true;
                    for (int i = 0; i < list.Count && valid; i++)
                    {
                        if (before.ContainsKey(list[i]))
                        {
                            for (int j = 0; j < i; j++)
                            {
                                if (before[list[i]].Contains(list[j]))
                                {
                                    var temp = list[i];
                                    list[i] = list[j];
                                    list[j] = temp;
                                    valid = false;
                                    tweaked = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (valid)
                    {
                        break;
                    }
                }

                if (tweaked)
                {
                    sum += list[list.Count / 2];
                }
            }
        }

        Console.WriteLine($"day 05p2: {sum}");
    }
}
