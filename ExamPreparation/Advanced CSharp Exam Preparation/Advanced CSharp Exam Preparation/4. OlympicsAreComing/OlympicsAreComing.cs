using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _4.OlympicsAreComing
{
    using System;

    public class OlympicsAreComing
    {
        public static void Main()
        {
            string currentLine = Console.ReadLine();
            var countryInfos = new Dictionary<string, CountryInfo>();
            while (currentLine != "report")
            {
                string[] playerAndCountry = currentLine.Split('|');

                string player = RemoveWhitespaces(playerAndCountry[0]);
                string country = RemoveWhitespaces(playerAndCountry[1]);

                if (!countryInfos.ContainsKey(country))
                {
                    countryInfos[country] = new CountryInfo(country);
                }

                countryInfos[country].PlayerNames.Add(player);
                countryInfos[country].Wins++;

                currentLine = Console.ReadLine();
            }

            var orderedCountryInfos = countryInfos.Values.OrderByDescending(w => w.Wins);

            foreach (var countryInfo in orderedCountryInfos)
            {
                var countryName = countryInfo.Country;
                var playersCount = countryInfo.PlayerNames.Count;
                var winsCount = countryInfo.Wins;
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

    public class CountryInfo
    {
        public CountryInfo(string country, int wins, HashSet<string> playerNames)
        {
            this.Country = country;
            this.Wins = wins;
            this.PlayerNames = playerNames;
        }

        public CountryInfo(string country)
            : this(country, 0, new HashSet<string>())
        {
        }

        public string Country { get; set; }

        public int Wins { get; set; }

        public HashSet<string> PlayerNames { get; set; }
    }
}
