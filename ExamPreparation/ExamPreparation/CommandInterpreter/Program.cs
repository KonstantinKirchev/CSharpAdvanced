using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandInterpreter
{
    class Program
    {
        static void Main()
        {
            List<string> collection = Console.ReadLine().Split(new []{' ','\t'},StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] commandArgs = command.Split();
                switch (commandArgs[0])
                {
                    case "sort":
                        SortCommand(commandArgs, collection);
                        break;
                    case "reverse":
                        ReverseCommand(commandArgs, collection);
                        break;
                    case "rollLeft":
                        ExecuteRollLeftCommand(commandArgs, collection);
                        break;
                    case "rollRight":
                        ExecuteRollRightCommand(commandArgs, collection);
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine("[{0}]",string.Join(", ",collection));
        }

        private static void SortCommand(string[] commandArgs, List<string> collection)
        {
            int start = int.Parse(commandArgs[2]);
            int count = int.Parse(commandArgs[4]);
            if (count < 0 || start < 0 || start >= collection.Count || start + count > collection.Count)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }
            collection.Sort(start,count,StringComparer.InvariantCulture);
            //string[] sorted = collection.GetRange(start, count).ToArray();
            //Array.Sort(sorted);
            //collection.RemoveRange(start, count);
            //collection.InsertRange(start, sorted);
        }

        private static void ReverseCommand(string[] commandArgs, List<string> collection)
        {
            
            int start = int.Parse(commandArgs[2]);
            int count = int.Parse(commandArgs[4]);
            if (count < 0 || start < 0 || start >= collection.Count || start + count > collection.Count)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }
            collection.Reverse(start, count);
            //string[] reverse = collection.GetRange(start, count).ToArray();
            //Array.Reverse(reverse);
            //collection.RemoveRange(start,count);
            //collection.InsertRange(start,reverse);
        }

        private static void ExecuteRollRightCommand(string[] commandArgs, List<string> collection )
        {
            int count = int.Parse(commandArgs[1]) % collection.Count;
            if (count < 0)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }
            for (int i = 0; i < count; i++)
            {
                string lastElement = collection[collection.Count - 1];
                collection.RemoveAt(collection.Count - 1);
                collection.Insert(0, lastElement);
            }
        }

        private static void ExecuteRollLeftCommand(string[] commandArgs, List<string> collection )
        {
            int count = int.Parse(commandArgs[1]) % collection.Count;
            if (count < 0)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }
            for (int i = 0; i < count; i++)
            {
                string firstElement = collection[0];
                collection.RemoveAt(0);
                collection.Add(firstElement);
            }
        }
    }
}
