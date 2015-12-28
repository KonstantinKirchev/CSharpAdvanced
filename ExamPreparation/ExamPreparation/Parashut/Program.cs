using System;
using System.Collections.Generic;

namespace Parashut
{
    class Program
    {
        static void Main()
        {
            List<char[]> matrix = new List<char[]>();
            string input = Console.ReadLine();

            while (input != "END")
            {
                matrix.Add(input.ToCharArray());
                input = Console.ReadLine();
            }

            int playerRow = 0;
            int playerCol = 0;
            for (int row = 0; row < matrix.Count; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'o')
                    {
                        playerRow = row;
                        playerCol = col;
                        break;
                    }

                }
            }
            
            for (int row = playerRow + 1; row < matrix.Count; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    
                    switch (matrix[row][col])
                    {
                        case '>':
                            playerCol++;
                            break;
                        case  '<':
                            playerCol--;
                            break;
                    }
                }
                char playerPos = matrix[row][playerCol];

                if (playerPos == '_')
                {
                    Console.WriteLine("Landed on the ground like a boss!");
                    Console.WriteLine(row + " " + playerCol);
                    return;
                }
                else if (playerPos == '~')
                {
                    Console.WriteLine("Drowned in the water like a cat!");
                    Console.WriteLine(row + " " + playerCol);
                    return;
                }
                else if (playerPos == '|' || playerPos == '\\' || playerPos == '/')
                {
                    Console.WriteLine("Got smacked on the rock like a dog!");
                    Console.WriteLine(row + " " + playerCol);
                    return;
                }
            }
        }
    }
}
