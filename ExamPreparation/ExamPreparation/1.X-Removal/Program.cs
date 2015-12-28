using System;
using System.Collections.Generic;

namespace _1.X_Removal
{
    class Program
    {
        static void Main()
        {
            List<char[]> matrix = new List<char[]>();
            List<char[]> matrixCopy = new List<char[]>();
            string input = Console.ReadLine();
            while (input != "END")
            {
                char[] line = input.ToCharArray();
                char[] lineCopy = input.ToLower().ToCharArray();
                matrix.Add(line);
                matrixCopy.Add(lineCopy);
                input = Console.ReadLine();
            }

            for (int row = 0; row < matrixCopy.Count - 2; row++)
            {
                int minLength = Math.Min(matrixCopy[row].Length - 2, Math.Min(matrixCopy[row + 1].Length - 1,
                    matrixCopy[row + 2].Length - 2));
                for (int col = 0; col < minLength; col++)
                {
                    char topLeft = matrixCopy[row][col];
                    char topRight = matrixCopy[row][col + 2];
                    char middle = matrixCopy[row + 1][col + 1];
                    char bottomLeft = matrixCopy[row + 2][col];
                    char bottomRight = matrixCopy[row + 2][col + 2];

                    if (topLeft == topRight && topRight == middle && middle == bottomLeft && bottomLeft == bottomRight)
                    {
                        matrix[row][col] = '\0';
                        matrix[row][col + 2] = '\0';
                        matrix[row + 1][col + 1] = '\0';
                        matrix[row + 2][col] = '\0';
                        matrix[row + 2][col + 2] = '\0';
                    }
                }
            }

            foreach (var row in matrix)
            {
                foreach (var col in row)
                {
                    if (col != '\0')
                    {
                        Console.Write(col);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
