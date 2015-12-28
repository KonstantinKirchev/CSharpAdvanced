using System;
using System.Text.RegularExpressions;

namespace _2.MagicCard
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string result = Regex.Replace(input, "10", "1");
            string[] cards = result.Split();
            string oddOrEven = Console.ReadLine();
            string magicStr = Console.ReadLine();
            string resultMagic = Regex.Replace(magicStr, "10", "1");
            char[] magic = resultMagic.ToCharArray();
            int sum = 0;
            if (oddOrEven == "even")
            {
                for (int i = 0; i < cards.Length; i+=2)
                {
                    int value = 0;     
                    char[] num = cards[i].ToCharArray();

                    switch (num[0])
                    {
                        case '2':
                            value = 20;
                            break;
                        case '3':
                            value = 30;
                            break;
                        case '4':
                            value = 40;
                            break;
                        case '5':
                            value = 50;
                            break;
                        case '6':
                            value = 60;
                            break;
                        case '7':
                            value = 70;
                            break;
                        case '8':
                            value = 80;
                            break;
                        case '9':
                            value = 90;
                            break;
                        case '1':
                            value = 100;
                            break;
                        case 'J':
                            value = 120;
                            break;
                        case 'Q':
                            value = 130;
                            break;
                        case 'K':
                            value = 140;
                            break;
                        case 'A':
                            value = 150;
                            break;
                        
                    }
                    if (num[0] == magic[0])
                    {
                        value *= 3;
                    }
                    if (num[1] == magic[1])
                    {
                        value *= 2;
                    }
                    sum += value;
                }
            }
            else
            {
                for (int i = 1; i < cards.Length; i += 2)
                {
                    int value = 0;
                    char[] num = cards[i].ToCharArray();

                    switch (num[0])
                    {
                        case '2':
                            value = 20;
                            break;
                        case '3':
                            value = 30;
                            break;
                        case '4':
                            value = 40;
                            break;
                        case '5':
                            value = 50;
                            break;
                        case '6':
                            value = 60;
                            break;
                        case '7':
                            value = 70;
                            break;
                        case '8':
                            value = 80;
                            break;
                        case '9':
                            value = 90;
                            break;
                        case '1':
                            value = 100;
                            break;
                        case 'J':
                            value = 120;
                            break;
                        case 'Q':
                            value = 130;
                            break;
                        case 'K':
                            value = 140;
                            break;
                        case 'A':
                            value = 150;
                            break;

                    }
                    if (num[0] == magic[0])
                    {
                        value *= 3;
                    }
                    if (num[1] == magic[1])
                    {
                        value *= 2;
                    }
                    sum += value;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
