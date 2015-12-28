using System;
using System.Security;
using System.Text;

namespace TextGravity
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfCols = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            
            int numOfRows = text.Length / numOfCols;
       
            if (text.Length % numOfCols != 0)
            {
                numOfRows++;
            }
            
            char[,] matrix = new char[numOfRows,numOfCols];
            int currentIndex = 0;
            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (currentIndex < text.Length)
                    {
                        matrix[row, col] = text[currentIndex];
                        currentIndex++;
                    }
                    else
                    {
                        matrix[row, col] = ' ';
                    }   
                }
            }
            
            for (int col = 0; col < matrix.GetLength(1); col++)
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
            
            StringBuilder output = new StringBuilder();
            output.Append("<table>");
            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                output.Append("<tr>");
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    output.AppendFormat("<td>{0}</td>", SecurityElement.Escape(matrix[row, col].ToString()));
                }
                output.Append("</tr>");
            }
            
            output.Append("</table>");
            Console.WriteLine(output);
        }
    }
}
