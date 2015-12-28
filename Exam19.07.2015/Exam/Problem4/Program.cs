using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem4
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<string, Countries> countries = new Dictionary<string, Countries>();

            while (input != "report")
            {
                string[] line = input.Split('|');
                string city = line[0];
                string country = line[1];
                int population = int.Parse(line[2]);

                if (!countries.ContainsKey(country))
                {
                    countries[country] = new Countries();
                    
                }
                if (!countries[country].Cities.ContainsKey(city))
                {
                    countries[country].Cities.Add(city,population);
                    countries[country].Country = country;

                }
                countries[country].TotalPopulation += population;
                input = Console.ReadLine();
            }

            foreach (var city in countries.Values.OrderByDescending(x => x.TotalPopulation))
            {
                Console.Write(city.Country + " ");
                Console.WriteLine("(total population: {0})", city.TotalPopulation);
                
                foreach (var cit in city.Cities.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine("=>{0}: {1}",cit.Key , cit.Value);
                }
            }
        }

        public class Countries

        {
            public Countries()
            {
                this.Cities = new Dictionary<string,long>();
            }
            
            public long TotalPopulation { get; set; }
            public Dictionary<string,long> Cities { get; set; }
            public string Country { get; set; }
        }
    }
}
