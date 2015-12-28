using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace SumOfAllValues
{
    class Program
    {
        static void Main()
        {
            string keyString = Console.ReadLine();
            Regex regexKey = new Regex(@"^([A-Za-z_]+)[0-9].*?[0-9]([A-Za-z_]+)$");
            Match matchKey = regexKey.Match(keyString);
            
            string start = matchKey.Groups[1].Value;
            string end = matchKey.Groups[2].Value;
            if (!start.Any() || !end.Any())
            {
                Console.WriteLine("<p>A key is missing</p>");
                return;
            }
            string text = Console.ReadLine();
            Regex regexText = new Regex(start + "([0-9.]+)" + end);
            MatchCollection matchText = regexText.Matches(text);
            double sum = 0;
            foreach (Match match in matchText)
            {
                sum += double.Parse(match.Groups[1].Value);
            }
            if (sum != 0)
            {
                Console.WriteLine("<p>The total value is: <em>{0}</em></p>", sum);
            }
            else
            {
                Console.WriteLine("<p>The total value is: <em>nothing</em></p>");
            }
            
        }
    }
}
