namespace _21.ITVillage
{
    using System;

    public class ITVillage
    {
        private const int FieldSize = 4;
        private const int InitialCoins = 50;
        private const int MoneyPerOwnedInn = 20;

        private static int coins = InitialCoins;
        private static int ownedInns = 0;
        private static int totalInns = 0;
        private static bool steppedOnNakov = false;
        private static string[,] field = new string[FieldSize, FieldSize];
        private static int[] moves;
        private static int currentMoveIndex = 0;

        public static void Main()
        {
            // TODO: Extract classes to ensure strong cohesion and loose coupling
            string[] fieldParts = Console.ReadLine().Split('|');
            for (int row = 0; row < FieldSize; row++)
            {
                var itemsInRow = fieldParts[row].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < FieldSize; col++)
                {
                    field[row, col] = itemsInRow[col];
                }
            }

            CountInns();

            string[] startingPositionAsStrings = Console.ReadLine().Split(' ');
            int[] startingPosition = ParseNumbersArray(startingPositionAsStrings);
            string[] movesAsStrings = Console.ReadLine().Split(' ');
            moves = ParseNumbersArray(movesAsStrings);

            int currentRow = startingPosition[0] - 1;
            int currentCol = startingPosition[1] - 1;

            while (true)
            {
                int[] currentPosition = GetNextPosition(currentMoveIndex, currentRow, currentCol);

                string currentItem = field[currentPosition[0], currentPosition[1]];
                ProcessCurrentMove(currentItem);
                bool gameEnded = CheckForGameEnding(moves);
                if (gameEnded)
                {
                    return;
                }

                UpdateInnCoins();
                
                currentRow = currentPosition[0];
                currentCol = currentPosition[1];
            }
        }

        private static int[] ParseNumbersArray(string[] numbersAsStrings)
        {
            int[] result = new int[numbersAsStrings.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = int.Parse(numbersAsStrings[i]);
            }

            return result;

            // This should also work ;)
            // return numbersAsStrings.Select(int.Parse).ToArray();
        }

        private static void CountInns()
        {
            for (int row = 0; row < FieldSize; row++)
            {
                for (int col = 0; col < FieldSize; col++)
                {
                    if (field[row, col] == "I")
                    {
                        totalInns++;
                    }
                }
            }
        }

        private static int[] GetNextPosition(int moveIndex, int currentRow, int currentCol)
        {
            int numberOfMoves = moves[moveIndex];
            int nextRow = currentRow;
            int nextCol = currentCol;
            while (numberOfMoves > 0)
            {
                if (nextCol == 0)
                {
                    // Left side
                    if (nextRow == 0)
                    {
                        // Top left corner
                        nextCol++;
                    }
                    else
                    {
                        nextRow--;
                    }
                }
                else if (nextRow == 0)
                {
                    // Top side
                    if (nextCol == FieldSize - 1)
                    {
                        // Top right corner
                        nextRow++;
                    }
                    else
                    {
                        nextCol++;
                    }
                }
                else if (nextCol == FieldSize - 1)
                {
                    // Right side
                    if (nextRow == FieldSize - 1)
                    {
                        // Bottom right corner
                        nextCol--;
                    }
                    else
                    {
                        nextRow++;
                    }
                }
                else if (nextRow == FieldSize - 1)
                {
                    // Bottom left corner
                    if (nextCol == 0)
                    {
                        nextRow--;
                    }
                    else
                    {
                        nextCol--;
                    }
                }

                numberOfMoves--;
            }

            return new[] { nextRow, nextCol };
        }

        private static void ProcessCurrentMove(string currentItem)
        {
            switch (currentItem)
            {
                case "P":
                    coins -= 5;
                    break;
                case "I":
                    if (coins >= 100)
                    {
                        ownedInns++;
                        coins -= 100;
                    }
                    else
                    {
                        coins -= 10;
                    }
                    break;
                case "F":
                    coins += 20;
                    break;
                case "S":
                    currentMoveIndex += 2;
                    break;
                case "V":
                    coins *= 10;
                    break;
                case "N":
                    steppedOnNakov = true;
                    break;
                case "0": break;
                default: break;
            }

            currentMoveIndex++;
        }

        private static void UpdateInnCoins()
        {
            coins += ownedInns * MoneyPerOwnedInn;
        }

        private static bool CheckForGameEnding(int[] moves)
        {
            bool gameEnded = true;
            if (coins < 0)
            {
                // Run out of money
                Console.WriteLine("<p>You lost! You ran out of money!<p>");
            }
            else if (ownedInns == totalInns)
            {
                // Buy all inns
                Console.WriteLine("<p>You won! You own the village now! You have {0} coins!<p>", coins);
            }
            else if (currentMoveIndex >= moves.Length)
            {
                // No more moves
                Console.WriteLine("<p>You lost! No more moves! You have {0} coins!<p>", coins);
            }
            else if (steppedOnNakov)
            {
                // Stepped on Nakov
                Console.WriteLine("<p>You won! Nakov's force was with you!<p>");
            }
            else
            {
                gameEnded = false;
            }

            return gameEnded;
        }
    }
}
