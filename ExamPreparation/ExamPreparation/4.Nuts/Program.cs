using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace OfficeStuff
{
    class Program
    {
        static void Main()
        {
            var info = new SortedDictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string result = Regex.Replace(input, @"kg", " ").Trim();
                string[] line = result.Split();
                string company = line[0];
                string nut = line[1];
                int amount = int.Parse(line[2]);

                if (!info.ContainsKey(company))
                {
                    info[company] = new Dictionary<string, int>();
                    if (!info[company].ContainsKey(nut))
                    {
                        info[company][nut] = amount;
                    }
                }
                else
                {
                    if (!info[company].ContainsKey(nut))
                    {
                        info[company][nut] = amount;
                    }
                    else
                    {
                        info[company][nut] += amount;
                    }
                }
            }
            foreach (var str in info)
            {
                var sub = str.Value.Select(x => x.Key + "-" + x.Value).Aggregate((x, y) => x +"kg"+ ", " + y);
                Console.WriteLine("{0}: {1}kg", str.Key, sub);
            }
        }
    }
}
