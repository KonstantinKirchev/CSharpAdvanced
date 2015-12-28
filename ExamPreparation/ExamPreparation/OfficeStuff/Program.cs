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
                string result = Regex.Replace(input, @"[\s\|\-]+", " ").Trim();
                string[] line = result.Split();
                string company = line[0];
                string product = line[2];
                int amount = int.Parse(line[1]);

                if (!info.ContainsKey(company))
                {
                    info[company] = new Dictionary<string, int>();
                    if (!info[company].ContainsKey(product))
                    {
                        info[company][product] = amount;
                    }            
                }
                else
                {
                    if (!info[company].ContainsKey(product))
                    {
                        info[company][product] = amount;
                    }
                    else
                    {
                        info[company][product] += amount;
                    }
                }
            }
            foreach (var str in info)
            {
                var sub = str.Value.Select(x => x.Key + "-" + x.Value).Aggregate((x, y) => x + ", " + y);
                Console.WriteLine("{0}: {1}", str.Key, sub);
            }
        }
    }
}
