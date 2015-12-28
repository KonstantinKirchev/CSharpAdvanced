using System;
using System.Linq;

namespace TargetPractice
{
    class Program
    {
        static void Main()
        {
            string[] dimentions = Console.ReadLine().Split();
            int numOfRows = int.Parse(dimentions[0]);
            int numOfCols = int.Parse(dimentions[1]);
            string snake = Console.ReadLine();
            int[] circle = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int impactRow = circle[0];
            int impactCol = circle[1];
            int radius = circle[2];
            char[,] matrix = new char[numOfRows, numOfCols];
            bool hasMovedLeft = true;
            int currentIndex = 0;

            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                if (hasMovedLeft)
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        if (currentIndex >= snake.Length)
                        {
                            currentIndex = 0;
                        }
                        matrix[row, col] = snake[currentIndex];
                        currentIndex++;
                    }
                }
                else
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (currentIndex >= snake.Length)
                        {
                            currentIndex = 0;
                        }
                        matrix[row, col] = snake[currentIndex];
                        currentIndex++;
                    }
                }

                hasMovedLeft = !hasMovedLeft;
            }

            ClearingCells(matrix, impactRow, impactCol, radius);

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Gravity(matrix, col);
            }
            PrintMatrix(matrix);
        }

        private static void Gravity(char[,] matrix, int col)
        {
            while (true)
            {
                bool hasMoved = false;

                for (int row = 1; row < matrix.GetLength(0); row++)
                {
                    if (matrix[row - 1, col] != ' ' && matrix[row, col] == ' ')
                    {
                        matrix[row, col] = matrix[row - 1, col];
                        matrix[row - 1, col] = ' ';
                        hasMoved = true;
                    }
                }
                if (!hasMoved)
                {
                    break;
                }
            }
        }

        private static void ClearingCells(char[,] matrix, int impactRow, int impactCol, int radius)
        {
       
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if ((col - impactCol) * (col - impactCol) + (row - impactRow) * (row - impactRow) <= radius * radius)
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }

        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
