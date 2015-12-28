using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VladkoNotebook
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<string, Player> playerInfo = new Dictionary<string, Player>();
            
            while (input != "END")
            {
                string[] line = input.Split('|');  
                string color = line[0];
                
                if (!playerInfo.ContainsKey(color))
                {
                    playerInfo[color] = new Player();
                }
                
                Player currentPlayer = playerInfo[color];
                string info = line[1];
                
                if (info == "age")
                {
                    currentPlayer.Age = int.Parse(line[2]);
                }
                else if (info == "name")
                {
                    currentPlayer.Name = line[2];
                }
                else if (info == "win")
                {
                    currentPlayer.Wins++;
                    currentPlayer.Opponents.Add(line[2]);
                }
                else if(info == "loss")
                {
                    currentPlayer.Losses++;
                    currentPlayer.Opponents.Add(line[2]);
                }
                input = Console.ReadLine();
            }
            var validPlayerInfo = playerInfo
                .Where(p => p.Value.Age != 0 && p.Value.Name != null)
                .OrderBy(p => p.Key);

            if (!validPlayerInfo.Any())
            {
                Console.WriteLine("No data recovered.");
                return;
            }
           
            StringBuilder output = new StringBuilder();
            
            foreach (var info in validPlayerInfo)
            {
                if (info.Value.Opponents.Count == 0)
                {
                    info.Value.Opponents.Add("(empty)");
                }
                output.AppendLine(string.Format("Color: {0}", info.Key));
                output.AppendLine(string.Format("-age: {0}", info.Value.Age));
                output.AppendLine(string.Format("-name: {0}", info.Value.Name));
                output.AppendLine(string.Format("-opponents: {0}", string.Join(", ", info.Value.Opponents.OrderBy(o => o , StringComparer.Ordinal))));
                output.AppendLine(string.Format("-rank: {0:f2}", (info.Value.Wins + 1)/(info.Value.Losses + 1)));
            }

            Console.WriteLine(output);
        }

        public class Player
        {
            public Player()
            {
                this.Opponents = new List<string>();
            }
            public string Name { get; set; }
            public int Age { get; set; }
            public List<string> Opponents { get; set; }
            public double Wins { get; set; }
            public double Losses { get; set; }
        }
    }
}
