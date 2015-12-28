using System;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;

namespace TextTransformer
{
    class Program
    {
        static void Main()
        {
            StringBuilder input = new StringBuilder();
            string line = Console.ReadLine();
            
            while (line != "burp")
            {
                input.Append(line);
                line = Console.ReadLine();
            }
            string result = Regex.Replace(input.ToString(),@"\s+", " ");
  
            Regex reg = new Regex(@"([$%&'])([^$%'&]+)\1");
            MatchCollection matches = reg.Matches(result);
            StringBuilder output = new StringBuilder();
    
            foreach (Match match in matches)
            {
                string sign = match.Groups[1].Value;
                int num = 0;
                switch (sign)
                {
                    case "$":
                        num = 1;
                        break;
                    case "%":
                        num = 2;
                        break;
                    case "'":
                        num = 4;
                        break;
                    case "&":
                        num = 3;
                        break;
                }
                string text = match.Groups[2].Value;
                for (int i = 0; i < text.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        char ch = (char)(text[i] + num);
                        output.Append(ch);
                    }
                    else
                    {
                        char ch = (char)(text[i] - num);
                        output.Append(ch);
                    }
                    
                }

                output.Append(" ");
            }
            Console.Write(output + " ");
        }
    }
}
