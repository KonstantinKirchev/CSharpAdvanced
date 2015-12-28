using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolSystem
{
    class Program
    {
        static void Main()
        {
            var schoolBook = new SortedDictionary<string, SortedDictionary<string, List<double>>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split();
                string name = line[0] + " " + line[1];
                string subject = line[2];
                double grade = double.Parse(line[3]);

                if (!schoolBook.ContainsKey(name))
                {
                    schoolBook[name] = new SortedDictionary<string, List<double>>();
                    if (!schoolBook[name].ContainsKey(subject))
                    {
                        schoolBook[name][subject] = new List<double>();
                    }
                    schoolBook[name][subject].Add(grade); 
                }
                else
                {
                    if (!schoolBook[name].ContainsKey(subject))
                    {
                        schoolBook[name][subject] = new List<double>();
                    }
                    schoolBook[name][subject].Add(grade);  
                }
                
            }

            foreach (var student in schoolBook)
            {
                string result =
                    student.Value.Select(x => x.Key + " - " + x.Value.Average().ToString("0.00"))
                        .Aggregate((s1, s2) => s1 + ", " + s2);
                Console.WriteLine("{0}: [{1}]",student.Key,result);
            }
        }
    }
}
