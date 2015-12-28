using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02StringMatrixRotation
{
    class StringMatrixRotation
    {
        static void Main()
        {
            string rotateStr = Console.ReadLine();
            string pattern = @"\d+";
            int rotate = int.Parse(Regex.Match(rotateStr, pattern).ToString());
            List<string> allLine = new List<string>();
            int maxLine = 0;
            string line = Console.ReadLine();
            while (line != "END")
            {
                allLine.Add(line);

                if (line.Length > maxLine)
                {
                    maxLine = line.Length;
                }
                line = Console.ReadLine();
            }
            int realRotate = (rotate / 90) % 4;
            switch (realRotate)
            {
                case 0:
                    char[,] result0 = Rotate0Degree(allLine, maxLine);
                    PrintMatrix(result0);
                    break;
                case 1:
                    char[,] result = Rotate90Degree(allLine, maxLine);
                    PrintMatrix(result);
                    break;
                case 2: result = Rotate180Degree(allLine, maxLine);
                    PrintMatrix(result);
                    break;
                case 3: result = Rotate270Degree(allLine, maxLine);
                    PrintMatrix(result);
                    break;
            }

        }
        static private char[,] Rotate0Degree(List<string> allLine, int maxLine)
        {
            int row = allLine.Count();
            int col = maxLine;
            char[,] matrix = new char[row, col];

            for (int r = 0, countLine = 0; r < row; r++, countLine++)
            {
                string line = allLine[countLine];
                for (int c = 0; c < col; c++)
                {
                    if (c >= line.Length)
                    {
                        matrix[r, c] = ' ';
                    }
                    else
                    {
                        char temp = line[c];
                        matrix[r, c] = temp;
                    }
                }
            }
            return matrix;

        }

        static private char[,] Rotate90Degree(List<string> allLine, int maxLine)
        {
            int row = maxLine;
            int col = allLine.Count();
            char[,] matrix = new char[row, col];

            for (int c = col - 1, countLine = 0; c >= 0; c--, countLine++)
            {
                string line = allLine[countLine];
                for (int r = 0; r < row; r++)
                {
                    if (r >= line.Length)
                    {
                        matrix[r, c] = ' ';
                    }
                    else
                    {
                        char temp = line[r];
                        matrix[r, c] = temp;
                    }
                }
            }
            return matrix;

        }

        static private char[,] Rotate180Degree(List<string> allLine, int maxLine)
        {
            int row = allLine.Count();
            int col = maxLine;
            char[,] matrix = new char[row, col];

            for (int r = row - 1, countLine = 0; r >= 0; r--, countLine++)
            {
                string line = allLine[countLine];
                for (int c = col - 1, charCounter = 0; c >= 0; c--, charCounter++)
                {
                    if (charCounter >= line.Length)
                    {
                        matrix[r, c] = ' ';
                    }
                    else
                    {
                        char temp = line[charCounter];
                        matrix[r, c] = temp;
                    }
                }
            }
            return matrix;

        }

        static private char[,] Rotate270Degree(List<string> allLine, int maxLine)
        {
            int row = maxLine;
            int col = allLine.Count();
            char[,] matrix = new char[row, col];

            for (int c = 0, countLine = 0; c < col; c++, countLine++)
            {
                string line = allLine[countLine];
                for (int r = row - 1, charCounter = 0; r >= 0; r--, charCounter++)
                {
                    if (r < row - line.Length)
                    {
                        matrix[r, c] = ' ';
                    }
                    else
                    {
                        char temp = line[charCounter];
                        matrix[r, c] = temp;
                    }
                }
            }
            return matrix;

        }

        private static void PrintMatrix(char[,] matrix)
        {
            StringBuilder sb = new StringBuilder();
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    sb.Append(matrix[r, c]);
                }
                Console.WriteLine(sb.ToString());
                sb.Clear();
            }
        }

    }
}

