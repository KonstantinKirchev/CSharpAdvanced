using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LittleJohn
{
    class Program
    {
        static void Main()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 4; i++)
            {
                string input = Console.ReadLine();
                sb.Append(input + " ");
            }
            Regex regex = new Regex(@">>>----->>|>>----->|>----->");
            MatchCollection matches = regex.Matches(sb.ToString());
            int big = 0;
            int medium = 0;
            int small = 0;
            string number = String.Empty;
            foreach (Match match in matches)
            {
                switch (match.ToString())
                {
                    case ">>>----->>":
                        big++;
                        break;
                    case ">>----->":
                        medium++;
                        break;
                    case ">----->":
                        small++;
                        break;
                }
            }

            number = "" + small + medium + big;
            int decimalNum = int.Parse(number);
            string binNum = Convert.ToString(decimalNum, 2);
            string resultBin = binNum;
            string reverse = ReverseString(binNum);
            resultBin += reverse;
            int result = Convert.ToInt32(resultBin, 2);
    
            Console.WriteLine(result);
        }

        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

    }
}
