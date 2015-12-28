using System;
using System.Text.RegularExpressions;

namespace BiggestTableRow
{
    class Program
    {
        static void Main()
        {
            string nothing = Console.ReadLine();
            string nothing2 = Console.ReadLine();
            string input = Console.ReadLine();
            double sum = 0;
            double maxSum = Double.MinValue;
            string output = String.Empty;
            double store1 = 0;
            double store2 = 0;
            double store3 = 0;
            while (input != "</table>")
            {
                Regex regex = new Regex(@"<tr><td>.*?<\/td><td>([0-9.\-]+)<\/td><td>([0-9.\-]+)<\/td><td>([0-9.\-]+)<\/td><\/tr>");
                Match matches = regex.Match(input);
                if (matches.Groups[1].Value == "-")
                {
                    store1 = 0;
                }
                else
                {
                    store1 = double.Parse(matches.Groups[1].Value);
                }
                if (matches.Groups[2].Value == "-")
                {
                    store2 = 0;
                }
                else
                {
                    store2 = double.Parse(matches.Groups[2].Value);
                }
                if (matches.Groups[3].Value == "-")
                {
                    store3 = 0;
                }
                else
                {
                    store3 = double.Parse(matches.Groups[3].Value);
                }
                
                sum = store1 + store2 + store3;
                if (sum > maxSum)
                {
                    maxSum = sum;
                    if (matches.Groups[1].Value == "-")
                    {
                        output = sum + " = " + matches.Groups[2].Value + " + " + matches.Groups[3].Value;
                    }
                    else if (matches.Groups[2].Value == "-")
                    {
                        output = sum + " = " + matches.Groups[1].Value +  " + " + matches.Groups[3].Value;    
                    }
                    else if (matches.Groups[3].Value == "-")
                    {
                        output = sum + " = " + matches.Groups[1].Value + " + " + matches.Groups[2].Value;
                    }
                    else
                    {
                        output = sum + " = " + matches.Groups[1].Value + " + " + matches.Groups[2].Value + " + " + matches.Groups[3].Value;
                    }

                    if (matches.Groups[2].Value == "-" && matches.Groups[3].Value == "-")
                    {
                        output = sum + " = " + matches.Groups[1].Value;
                    }
                    else if (matches.Groups[1].Value == "-" && matches.Groups[2].Value == "-")
                    {
                        output = sum + " = " + matches.Groups[3].Value;
                    }
                    else if (matches.Groups[1].Value == "-" && matches.Groups[3].Value == "-")
                    {
                        output = sum + " = " + matches.Groups[2].Value;
                    }
                    
                }
                input = Console.ReadLine();
            }
            if (maxSum == 0)
            {
                
            }
            Console.WriteLine(sum != 0 ? output : "no data");
        }
    }
}
