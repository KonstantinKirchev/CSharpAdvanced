using System;
using System.Collections.Generic;
using System.Security;

namespace ClearingCommands
{
    class Program
    {
        static void Main()
        {
            const string obstacles = "><^v";
            List<char[]> matrix = new List<char[]>();
            string input = Console.ReadLine();

            while (input != "END")
            {
                char[] chars = input.ToCharArray();
                matrix.Add(chars);
                input = Console.ReadLine();
            }

            for (int row = 0; row < matrix.Count; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    int currentRow;
                    int currentCol;

                    switch (matrix[row][col])
                    {
                        case '<':
                            currentRow = row;
                            currentCol = col - 1;

                            while (currentCol >= 0 && !obstacles.Contains(matrix[currentRow][currentCol].ToString()))
                            {
                                matrix[currentRow][currentCol] = ' ';
                                currentCol--;
                            }
                            break;
                        case '>':
                            currentRow = row;
                            currentCol = col + 1;

                            while (currentCol < matrix[currentRow].Length && !obstacles.Contains(matrix[currentRow][currentCol].ToString()))
                            {
                                matrix[currentRow][currentCol] = ' ';
                                currentCol++;
                            }
                            break;
                        case 'v':
                            currentRow = row + 1;
                            currentCol = col;

                            while (currentRow < matrix.Count && !obstacles.Contains(matrix[currentRow][currentCol].ToString()))
                            {
                                matrix[currentRow][currentCol] = ' ';
                                currentRow++;
                            }
                            break;
                        case '^':
                            currentRow = row - 1;
                            currentCol = col;

                            while (currentRow >= 0 && !obstacles.Contains(matrix[currentRow][currentCol].ToString()))
                            {
                                matrix[currentRow][currentCol] = ' ';
                                currentRow--;
                            }
                            break;

                    }
                    
                }
                
            }
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(List<char[]> matrix)
        {
            for (int row = 0; row < matrix.Count; row++)
            {
                Console.Write("<p>");
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(SecurityElement.Escape(matrix[row][col].ToString()));
                }
                Console.WriteLine("</p>");
            }
        }
    }
}
