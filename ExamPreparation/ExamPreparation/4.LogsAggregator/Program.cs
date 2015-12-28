using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _4.LogsAggregator
{
    class Program
    {
        static void Main()
        {
            var logs = new SortedDictionary<string, SortedDictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] line = input.Split();
                string ip = line[0];
                int duration = int.Parse(line[2]);
                string user = line[1];

                if (!logs.ContainsKey(user))
                {
                    logs[user] = new SortedDictionary<string, int>();
                    if (!logs[user].ContainsKey(ip))
                    {
                        logs[user][ip] = duration;
                    }
                }
                else
                {
                    if (!logs[user].ContainsKey(ip))
                    {
                        logs[user][ip] = duration;
                    }
                    else
                    {
                        logs[user][ip] += duration;
                    }
                    
                }
            }
                
            foreach (var student in logs)
            {
                Console.Write("{0}", student.Key + ": ");
                
                int sum = 0;
                foreach (var info in student.Value)
                {
                    sum += info.Value;
                }
                Console.Write("{0} [", sum);
                string result = student.Value.Select(x => x.Key).Aggregate((s1, s2) => s1 + ", " + s2);
                Console.WriteLine(result + "]");
            }
        }
    }
}
