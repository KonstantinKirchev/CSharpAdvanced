using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem6
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            SortedSet<string> output = new SortedSet<string>(StringComparer.Ordinal);
            for (int i = 0; i < input.Length; i++)
            {
                output.Add(String.Format("{0}: {1} time/s",input[i],input.Count(let=>let==input[i])));;
            } 
            foreach (var result in output)
            {
                Console.WriteLine(result);
            }
        }
    }
}
