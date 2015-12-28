using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.Orders
{
    class Program
    {
        static void Main()
        {
            var orders = new Dictionary<string, SortedDictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] line = input.Split();
                string customer = line[0];
                int amount = int.Parse(line[1]);
                string product = line[2];

                if (!orders.ContainsKey(product))
                {
                    orders[product] = new SortedDictionary<string, int>();
                    if (!orders[product].ContainsKey(customer))
                    {
                        orders[product][customer] = amount;
                    }
                }
                else
                {
                    if (!orders[product].ContainsKey(customer))
                    {
                        orders[product][customer] = amount;
                    }
                    else
                    {
                        orders[product][customer] += amount;
                    }

                }
            }

            foreach (var student in orders)
            {
                var sub = student.Value.Select(x => x.Key + " " + x.Value).Aggregate((x, y) => x + ", " + y);
                Console.WriteLine("{0}: {1}", student.Key, sub);
            }
        }
    }
}
