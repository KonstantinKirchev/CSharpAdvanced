using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Пърамид
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int currentNum = int.Parse(Console.ReadLine());
            List<int> output = new List<int>();
            output.Add(currentNum);
            
            for (int i = 1; i < n; i++)
            {
                bool isFound = true;
                int[] numbers = Console.ReadLine().Split(new []{' '},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                List<int> num = numbers.ToList();
                num.Sort();
              
                for (int j = 0; j < num.Count; j++)
                {
                    if (currentNum < num[j])
                    {
                        currentNum = num[j];
                        output.Add(num[j]);
                        isFound = false;
                        break;
                    }
                }
                if (isFound)
                {
                    currentNum++;
                }
                
            }
            Console.WriteLine(string.Join(", ",output));
        }
    }
}
