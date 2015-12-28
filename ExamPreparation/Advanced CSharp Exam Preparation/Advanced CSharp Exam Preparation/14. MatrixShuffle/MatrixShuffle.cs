namespace _14.MatrixShuffle
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class MatrixShuffle
    {
        public static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            var matrix = FillSpiralMatrix(matrixSize, input);
            
            string leftString = string.Empty;
            string rightString = string.Empty;
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    if ((row + col) % 2 == 0)
                    {
                        leftString += matrix[row, col];
                    }
                    else
                    {
                        rightString += matrix[row, col];
                    }
                }
            }

            string finalString = leftString + rightString;
            string reversedString = string.Join("", finalString.Reverse());
            bool isPalindrome = GetStringForChecking(finalString) == GetStringForChecking(reversedString);
            Console.WriteLine("<div style='background-color:#{0}'>{1}</div>", isPalindrome ? "4FE000" : "E0000F", finalString);
        }

        private static string[,] FillSpiralMatrix(int size, string input)
        {
            string[,] matrix = new string[size, size];

            // Initialize with spaces in order to prevent null values
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = " ";
                }
            }

            // TODO: Refactor loops to be more meaningful and more easy to read
            int currentNumber = 0;
            int row = 0;
            int column = 0;
            int maxRow = size - 1;
            int maxColumn = size - 1;
            while (currentNumber < size * size)
            {
                for (int i = column; i <= maxColumn; i++)
                {
                    matrix[row, i] = input[currentNumber].ToString();
                    currentNumber++;
                }
                if (currentNumber >= input.Length)
                {
                    break;
                }
                row++;
                for (int i = row; i <= maxRow; i++)
                {
                    matrix[i, maxColumn] = input[currentNumber].ToString();
                    currentNumber++;
                }
                if (currentNumber >= input.Length)
                {
                    break;
                }
                maxColumn--;
                for (int i = maxColumn; i >= column; i--)
                {
                    matrix[maxRow, i] = input[currentNumber].ToString();
                    currentNumber++;
                }
                if (currentNumber >= input.Length)
                {
                    break;
                }
                maxRow--;
                for (int i = maxRow; i >= row; i--)
                {
                    matrix[i, column] = input[currentNumber].ToString();
                    currentNumber++;
                }
                if (currentNumber >= input.Length)
                {
                    break;
                }
                column++;
            }

            return matrix;
        }

        private static string GetStringForChecking(string stringToCheck)
        {
            var regex = new Regex("[^A-Za-z0-9]");
            string result = regex.Replace(stringToCheck, string.Empty);
            return result.ToLower();
        }
    }
}