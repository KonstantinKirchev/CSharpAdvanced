using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _4.ExamScore
{
    class Program
    {
        static void Main()
        {
            var exam = new SortedDictionary<int, SortedDictionary<string, double>>();
            string a = Console.ReadLine();
            string b = Console.ReadLine();
            string c = Console.ReadLine();
            string input = Console.ReadLine();
            while (input[0] != '-')
            {
                string result = Regex.Replace(input, @"[\s\|]+", " ").Trim();
                string[] line = result.Split();
                string name = line[0]+ " "+ line[1];
                int score = int.Parse(line[2]);
                double grade = double.Parse(line[3]);
             
                if (!exam.ContainsKey(score))
                {
                    exam[score] = new SortedDictionary<string, double>();
                    if (!exam[score].ContainsKey(name))
                    {
                        exam[score][name] = grade;
                    }
                    exam[score][name] = grade;
                }
                else
                {
                    if (!exam[score].ContainsKey(name))
                    {
                        exam[score][name] = grade;
                    }
                    exam[score][name] = grade;
                }
                input = Console.ReadLine();
            }
            foreach (var student in exam)
            {
                Console.Write("{0}",student.Key + " -> [");
                string result = student.Value.Select(x => x.Key).Aggregate((s1, s2) => s1 + ", " + s2);
                Console.Write(result);
                double sum = 0;
                foreach (var info in student.Value)
                {
                    sum += info.Value;              
                }
                double avg = sum/student.Value.Count;
                
                Console.WriteLine("]; avg={0:f2}",avg);
            }
        }
    }
}
