using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OlympicsAreComing
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<string,Country> report = new Dictionary<string, Country>();

            while (input != "report")
            {
                string[] line = input.Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries);
  
                string lineName = line[0].Trim();
                Regex regex = new Regex(@"\s+");
                string name = regex.Replace(lineName, " ");

                string lineCountry = line[1].Trim();
                string country = regex.Replace(lineCountry, " ");
                if (!report.ContainsKey(country))
                {
                    report[country] = new Country();
                }
                if (!report[country].Name.Contains(name))
                {
                    report[country].Name.Add(name);
                    report[country].Participants++;
                }
                report[country].Wins++;
                input = Console.ReadLine();
            }
            var orderReport = report
                .OrderByDescending(r => r.Value.Wins);

            StringBuilder output = new StringBuilder();

            foreach (var info in orderReport)
            {
                output.AppendLine(string.Format("{0} ({1} participants): {2} wins", info.Key, info.Value.Participants,
                    info.Value.Wins));
            }
            Console.WriteLine(output);
        }

        public class Country
        {
            public Country()
            {
                this.Name = new List<string>();
            }
            public List<string> Name { get; set; }
            public int Wins { get; set; }
            public int Participants { get; set; }
        }
    }
}
