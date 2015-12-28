using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem9
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"\|(.*?)\|";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(input);
            int sum = 0;
            string result = match.Groups[1].ToString();
            for (int i = 0; i < result.Length; i++)
            {
                sum += result[i];
            }
            int repNum = sum % 10;
            Console.WriteLine(repNum);
            string patternRep = @"\w{"+repNum+@"}\|(.*?)\|\w{2}";
            StringBuilder sb = new StringBuilder();

            Regex regexRep = new Regex(patternRep);
            Match matchRep = regexRep.Match(input);
            for (int i = 0; i < matchRep.Groups[0].Length; i++)
            {
                sb.Append('.');
            }
            string replacement = sb.ToString();
            string resultRep = regex.Replace(input, replacement);
            Console.WriteLine(resultRep);
        }
    }
}
