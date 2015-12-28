using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem3
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Regex regex = new Regex(@"([^0-9]+)(\d+)");
            MatchCollection matches = regex.Matches(input);
            StringBuilder output = new StringBuilder();
            Regex unique = new Regex(@"[^0-9]");
            HashSet<char> strCount = new HashSet<char>();
            int count = 0;
            foreach (Match match in matches)
            {
                count++;
                string line = match.Groups[1].Value.ToUpper();
               
                char[] symbols = line.ToCharArray();
                foreach (var symbol in symbols)
                {
                    strCount.Add(symbol);     
                }
                
               
                int number = int.Parse(match.Groups[2].Value);
               
                for (int i = 0; i < number; i++)
                {
                    output.Append(line);
                }
            }
            Console.WriteLine("Unique symbols used: {0}",strCount.Count);
            Console.WriteLine(output);
            

        }
    }
}
