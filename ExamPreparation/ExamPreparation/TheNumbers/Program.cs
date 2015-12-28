using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TheNumbers
{
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            Regex regex = new Regex(@"[0-9]+");
            MatchCollection matches = regex.Matches(text);
            List<string> output = new List<string>();
            foreach (Match match in matches)
            {
                int number = int.Parse(match.Value);
                string hex = number.ToString("X");
                if (hex.Length == 1)
                {
                    hex = "0x000" + hex;
                }
                else if (hex.Length == 2)
                {
                    hex = "0x00" + hex;
                }
                else if (hex.Length == 3)
                {
                    hex = "0x0" + hex;
                }
                else if (hex.Length == 4)
                {
                    hex = "0x" + hex;
                }
                output.Add(hex);
            }
            Console.WriteLine(string.Join("-",output));
        }
    }
}
