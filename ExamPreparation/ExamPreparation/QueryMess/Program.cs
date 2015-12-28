using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace QueryMess
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            while (input != "END")
            {
                Dictionary<string, List<string>> phoneBook = new Dictionary<string, List<string>>();
                Regex regex = new Regex(@"([^&\?\s]+)=([^&\?\s]+)");
                MatchCollection matches = regex.Matches(input);

                foreach (Match match in matches)
                {
                    if (!phoneBook.ContainsKey(match.Groups[1].Value))
                    {
                        phoneBook[Regex.Replace(match.Groups[1].Value, @"(%20|\+)+", " ").Trim()] = new List<string>();
                    }

                    phoneBook[Regex.Replace(match.Groups[1].Value, @"(%20|\+)+", " ").Trim()].Add(Regex.Replace(match.Groups[2].Value, @"(%20|\+)+", " ").Trim());
                }
                foreach (var phones in phoneBook)
                {
                    sb.Append(String.Format("{0}=[{1}]", phones.Key, string.Join(", ", phones.Value)));
                }
                sb.AppendLine();
                
               
                input = Console.ReadLine();   
            }

            Console.WriteLine(sb);
        }
    }
}
