using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PhoneNumbers
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<string,string> phoneBook = new Dictionary<string, string>();
            while (input != "END")
            {
                Regex regex = new Regex(@"([A-Z][A-Za-z]*)[^A-Za-z\+0-9]*(\+*[0-9]+[)(\-\s\/.0-9]*[0-9]+)[^A-Za-z\+]*");
                MatchCollection matches = regex.Matches(input);
               
                foreach (Match match in matches)
                {
                    phoneBook[match.Groups[1].Value] = match.Groups[2].Value;
                }
                input = Console.ReadLine();
            }
            if (phoneBook.Count < 1)
            {
                Console.WriteLine("<p>No matches!</p>");
            }
            else
            {
                Console.Write("<ol>");
                foreach (var phones in phoneBook)
                {
                    Console.Write("<li><b>{0}:</b> {1}</li>", phones.Key, Regex.Replace(phones.Value, @"[\s\.\(\)\-\/]", ""));
                }
                Console.WriteLine("</ol>");    
            }
            
        }
    }
}
