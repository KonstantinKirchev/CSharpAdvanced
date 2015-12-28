using System;
using System.Collections.Generic;
using System.Linq;

namespace CouplesFrequency
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            Dictionary<string,int> couples = new Dictionary<string, int>();
            int numberOfFrequences = 0;
            for (int i = 0; i < input.Length - 1; i++)
            {
                numberOfFrequences++;
                if (!couples.ContainsKey(input[i]+" "+input[i+1]))
                {
                    couples.Add(input[i] + " " + input[i + 1],0);
                }
                couples[input[i] + " " + input[i + 1]]++;
            }
            double result = 0;
            foreach (var couple in couples)
            {
                result = ((double) couple.Value / numberOfFrequences) * 100;
                Console.WriteLine("{0} -> {1:f2}%", couple.Key, result);
            }
        }
    }
}
