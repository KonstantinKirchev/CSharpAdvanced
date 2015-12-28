using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Problem2
{
    class Program
    {
        static void Main()
        {
            int[] rowCol = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[,] matrix = new int[rowCol[0],rowCol[1]];
            for (int row = 0; row < rowCol[0]; row++)
            {
                int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < rowCol[1]; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            //for (int row = 0; row < rowCol[0]; row++)
            //{
            //    for (int col = 0; col < rowCol[1]; col++)
            //    {
            //        Console.Write("{0,3}",matrix[row,col]);
            //    }
            //    Console.WriteLine();
            //}
            int sum = 0;
            int maxSum = Int32.MinValue;
            int maxRow = 0;
            int maxCol = 0;
            for (int row = 0; row < rowCol[0] - 2; row++)
            {
                for (int col = 0; col < rowCol[1] - 2; col++)
                {
                    sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                          matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                          matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Sum = {0}",maxSum);
            for (int row = maxRow; row < maxRow + 3; row++)
            {
                for (int col = maxCol; col < maxCol + 3; col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
