using System;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

namespace UppercaseWords
{
    class Program
    {
        static void Main()
        {
            string line = Console.ReadLine();
       
            StringBuilder output = new StringBuilder();
            StringBuilder charsSb = new StringBuilder();
            
            int index = 0;
            
            while (line != "END")
            {
                Regex regex = new Regex("(?<![A-Za-z])[A-Z]+(?![A-Za-z])");
                MatchCollection matches = regex.Matches(line);
                string reverse = "";
                int prev = 0;
                foreach (Match match in matches)
                {
                    index = match.Index + prev;
                    if (match.Value != new string(match.Value.ToCharArray().Reverse().ToArray()))
                    {
                        reverse = new string(match.Value.ToCharArray().Reverse().ToArray());
                        line = line.Remove(index, match.Value.Length);
                        line = line.Insert(index, reverse);
                        
                    }
                    else if (match.Value == new string(match.Value.ToCharArray().Reverse().ToArray()))
                    {

                        foreach (var chars in match.Value)
                        {
                            charsSb.Append(chars + "" + chars);
                        }
                        line = line.Remove(index, match.Value.Length);
                        line = line.Insert(index, charsSb.ToString());

                        prev += match.Value.Length;
                        charsSb.Clear();
                    }
                }
                output.AppendLine(line);
                line = Console.ReadLine();
            }
            Console.WriteLine(SecurityElement.Escape(output.ToString()));
        }
    }
}
