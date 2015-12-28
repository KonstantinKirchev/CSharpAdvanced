using System;
using System.Collections.Generic;

namespace Plus_Remove
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            List<char[]> outputReal = new List<char[]>();
            List<char[]> outputCopy = new List<char[]>();

            while (input != "END")
            {
                char[] chars = input.ToCharArray();
                outputReal.Add(chars);
                char[] charsLower = input.ToLower().ToCharArray();
                outputCopy.Add(charsLower);
                input = Console.ReadLine();
            }
            for (int row = 0; row < outputCopy.Count - 2; row++)
            {
                int maxLength = Math.Min(outputCopy[row].Length - 1,
                    (Math.Min(outputCopy[row + 1].Length - 2, outputCopy[row + 2].Length - 1)));
                
                for (int col = 0; col < maxLength; col++)
                {
                    int top = outputCopy[row][col + 1];
                    int left = outputCopy[row + 1][col];
                    int middle = outputCopy[row + 1][col + 1];
                    int right = outputCopy[row + 1][col + 2];
                    int down = outputCopy[row + 2][col + 1];

                    if (top == left && left == middle && middle == right && right == down)
                    {
                        outputReal[row][col + 1] = '\0';
                        outputReal[row + 1][col] = '\0';
                        outputReal[row + 1][col + 1] = '\0';
                        outputReal[row + 1][col + 2] = '\0';
                        outputReal[row + 2][col + 1] = '\0';
                    }
                }
            }

            foreach (var output in outputReal)
            {
                foreach (var valid in output)
                {
                    if (valid != '\0')
                    {
                        Console.Write(valid);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
