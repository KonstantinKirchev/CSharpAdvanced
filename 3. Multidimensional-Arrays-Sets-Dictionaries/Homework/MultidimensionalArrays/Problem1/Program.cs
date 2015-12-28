using System;

namespace Problem1
{
    class Program
    {
        static void Main()
        {
            int[,] matrix = new int[4,4];
            int[,] snakeMatrix = new int[4, 4];
            int count = 1;
            int reverseCount = 0;
            int rowCount = 1;
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    matrix[col, row] = count++;
                }
            }

            for (int row = 0; row < 4; row++)
            {
                if (rowCount % 2 == 0)
                {
                    reverseCount = count + 3;
                    for (int col = 0; col < 4; col++)
                    {
                        snakeMatrix[col, row] = reverseCount--;
                        count++;
                    }
                }
                else
                {
                    for (int col = 0; col < 4; col++)
                    {
                        snakeMatrix[col, row] = count++;
                    }
                }
                rowCount++;
            }

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Console.Write("{0,4}",matrix[row,col]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Console.Write("{0,4}", snakeMatrix[row, col]);
                }
                Console.WriteLine();
            }


        }
    }
}
