using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem._1
{
    class Program
    {
        static void Main()
        {

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int numOfRows = input[0];
            int numOfCols = input[1];
            int[,] matrix = new int[numOfRows,numOfCols];

            for (int row = 0; row < numOfRows; row++)
            {
                string[] line = Console.ReadLine().Split();
                for (int col = 0; col < numOfCols; col++)
                {
                    matrix[row, col] = int.Parse(line[col]);
                }
            }

            //PrintMatrix(matrix);

            string command = Console.ReadLine();
            while (command != "cease fire!")
            {
                string[] com = command.Split();
                int bombRow = int.Parse(com[0]);
                int bombCol = int.Parse(com[1]);
                char powerSymbol = Convert.ToChar(com[2]);
                int power = powerSymbol - 0;
                double lowerPower = Math.Ceiling(powerSymbol / (double)2);
                //Console.WriteLine(lowerPower);
                int cellBomb = matrix[bombRow, bombCol] - powerSymbol;
     
                matrix[bombRow, bombCol] = cellBomb;
                //Console.WriteLine(cellBomb);
                if (bombRow-1 >= 0 && bombCol -1 >= 0)
                {
                    matrix[bombRow - 1, bombCol - 1] = (int)(matrix[bombRow - 1, bombCol - 1] - lowerPower);
                }
                if (bombRow - 1 >= 0)
                {
                    matrix[bombRow - 1, bombCol] = (int)(matrix[bombRow - 1, bombCol] - lowerPower);
                }
                if (bombRow - 1 >= 0 && bombCol + 1 < matrix.GetLength(1))
                {
                    matrix[bombRow - 1, bombCol + 1] = (int)(matrix[bombRow - 1, bombCol + 1] - lowerPower);
                }
                if (bombCol - 1 >= 0)
                {
                    matrix[bombRow, bombCol - 1] = (int)(matrix[bombRow, bombCol - 1] - lowerPower);
                }
                if (bombCol + 1 < matrix.GetLength(1))
                {
                    matrix[bombRow, bombCol + 1] = (int)(matrix[bombRow, bombCol + 1] - lowerPower);
                }
                if (bombRow + 1 < matrix.GetLength(0) && bombCol - 1 >= 0)
                {
                    matrix[bombRow + 1, bombCol - 1] = (int)(matrix[bombRow + 1, bombCol - 1] - lowerPower);    
                }
                if (bombRow + 1 < matrix.GetLength(0))
                {
                    matrix[bombRow + 1, bombCol] = (int)(matrix[bombRow + 1, bombCol] - lowerPower);    
                }
                if (bombRow + 1 < matrix.GetLength(0) && bombCol + 1 < matrix.GetLength(1))
                {
                    matrix[bombRow + 1, bombCol + 1] = (int)(matrix[bombRow + 1, bombCol + 1] - lowerPower);
                }
                
                //Console.WriteLine(powerSymbol/2);
                command = Console.ReadLine();
            }
            int countDestroyed = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col] <= 0)
                    {
                        countDestroyed++;
                    }
                }
            }
            double allRows = numOfRows * numOfCols;
            Console.WriteLine("Destroyed bunkers: {0}",countDestroyed);
            double damageDone = countDestroyed / allRows * 100;
            Console.WriteLine("Damage done: {0:f1} %",damageDone);
            //PrintMatrix(matrix);
            
        }
        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
