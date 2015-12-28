using System;
using System.Collections.Generic;
using System.Linq;

namespace Weightlifting
{
    class Program
    {
        static void Main()
        {
            var players = new SortedDictionary<string, SortedDictionary<string, long>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split();
                string player= line[0];
                string exercise = line[1];
                int weight = int.Parse(line[2]);

                if (!players.ContainsKey(player))
                {
                    players[player] = new SortedDictionary<string, long>();
                    if (!players[player].ContainsKey(exercise))
                    {
                        players[player][exercise] = weight;
                    }
                }
                else
                {
                    if (!players[player].ContainsKey(exercise))
                    {
                        players[player][exercise] = weight;
                    }
                    else
                    {
                        players[player][exercise] += weight;
                    }
                }
            }
            foreach (var player in players)
            {
                var sub =
                    player.Value.Select(x => x.Key + " - " + x.Value).Aggregate((x, y) => x + " kg" + ", " + y);
                Console.WriteLine("{0} : {1} kg", player.Key, sub);
            }
        }
    }
}
