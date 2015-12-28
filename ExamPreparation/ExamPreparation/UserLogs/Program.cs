using System;
using System.Collections.Generic;
using System.Linq;

namespace UserLogs
{
    class Program
    {
        static void Main()
        {
            var users = new SortedDictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();
            
            while (input != "end")
            {
                string[] line = input.Split();
                string user = line[2].Substring(5,line[2].Length - 5);
                string ip = line[0].Substring(3,line[0].Length - 3);
                int count = 1;
                if (!users.ContainsKey(user))
                {
                    users[user] = new Dictionary<string, int>();
                    if (!users[user].ContainsKey(ip))
                    {
                        users[user][ip] = count;
                    }
                }
                else
                {
                    if (!users[user].ContainsKey(ip))
                    {
                        users[user][ip] = count;
                    }
                    else
                    {
                        users[user][ip]++;
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var user in users)
            {
                var sub = user.Value.Select(x => x.Key + " => " + x.Value).Aggregate((x, y) => x + ", " + y);
                Console.WriteLine("{0}:\n{1}.", user.Key, sub);
            }
        }
    }
}
