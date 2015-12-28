using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Numerics;

namespace Problem._2
{
    class Program
    {
        static void Main()
        {
            BigInteger[] collection = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(BigInteger.Parse).ToArray();
            string command = Console.ReadLine();
            int currentIndex = 0;
            while (command != "stop")
            {
                string[] commandArgs = command.Split();
                int offset = int.Parse(commandArgs[0]) % collection.Length;
                string operation = commandArgs[1];
                int operand = int.Parse(commandArgs[2]);
       
                if (offset < 0)
                {
                    offset += collection.Length;
                }

                currentIndex = (currentIndex + offset) % collection.Length;
                
                switch (operation)
                {
                    case "&":
                        collection[currentIndex] &= operand;      
                        break;
                    case "|":
                        collection[currentIndex] |= operand;
                        break;
                    case "^":
                        collection[currentIndex] ^= operand;
                        break;
                    case "+":
                        collection[currentIndex] += operand;
                        break;
                    case "-":
                        collection[currentIndex] -= operand;
                        break;
                    case "*":
                        collection[currentIndex] *= operand;
                        break;
                    case "/":
                        collection[currentIndex] /= operand;
                        break;
                }
                if (collection[currentIndex] < 0)
                {
                    collection[currentIndex] = 0;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine("[{0}]", string.Join(", ", collection));
        }
    }
}
