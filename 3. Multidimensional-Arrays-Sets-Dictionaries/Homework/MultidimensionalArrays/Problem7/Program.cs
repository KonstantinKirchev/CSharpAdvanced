using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Problem7
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, string> phonebook = new Dictionary<string, string>();
            string input = Console.ReadLine();
            string pattern = @"(.*?)-(.*)";
            Regex regex = new Regex(pattern);
            while (input != "search")
            {
                if (input != null)
                {
                    Match match = regex.Match(input);
                    Console.WriteLine(match.Groups.Count);
                    Console.WriteLine(match.Groups[0].Value);
                    Console.WriteLine(match.Groups[1].Value);
                    Console.WriteLine(match.Groups[2].Value);
                    //phonebook[match.Groups[1]] = match.Groups[2];
                }

                input = Console.ReadLine();
            }
            //string text = "Nakov: 123";
            //string pattern = @"([A-Z][a-z]+): (\d+)";
            //Regex regex = new Regex(pattern);
            //Match match = regex.Match(text);

            //Console.WriteLine(match.Groups.Count); // 3
            //Console.WriteLine("Matched text: \"{0}\"", match.Groups[0]);
            //Console.WriteLine("Name: {0}", match.Groups[1]); // Nakov
            //Console.WriteLine("Number: {0}", match.Groups[2]); // 123

        }
    }
}
