namespace _4.OlympicsAreComing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class OlympicsAreComing_NoCustomClass
    {
        // TODO: Change to Main() in order to use this solution
        public static void Main_NoCustomClass()
        {
            string currentLine = Console.ReadLine();
            var playersByCountry = new Dictionary<string, HashSet<string>>();
            var winsByCountry = new Dictionary<string, int>();
            while (currentLine != "report")
            {
                string[] playerAndCountry = currentLine.Split('|');

                string player = RemoveWhitespaces(playerAndCountry[0]);
                string country = RemoveWhitespaces(playerAndCountry[1]);

                if (!playersByCountry.ContainsKey(country))
                {
                    playersByCountry[country] = new HashSet<string>();
                    winsByCountry[country] = 0;
                }

                playersByCountry[country].Add(player);
                winsByCountry[country]++;

                currentLine = Console.ReadLine();
            }

            var orderedCountryInfos = winsByCountry.OrderByDescending(w => w.Value);
            foreach (var countryInfo in orderedCountryInfos)
            {
                var countryName = countryInfo.Key;
                var playersCount = playersByCountry[countryName].Count();
                var winsCount = countryInfo.Value;
                Console.WriteLine(
                    "{0} ({1} participants): {2} wins",
                    countryName,
                    playersCount,
                    winsCount);
            }
        }

        private static string RemoveWhitespaces(string input)
        {
            return Regex
                .Replace(input, @"\s+", " ")
                .Trim();
        }
    }
}