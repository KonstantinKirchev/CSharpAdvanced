using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PINValidation
{
    class Program
    {
        static void Main()
        {
            string name = Console.ReadLine();
            if (!Regex.IsMatch(name, @"^[A-Z][a-z]+\s[A-Z][a-z]+$"))
            {
                Console.WriteLine("<h2>Incorrect data</h2>");
                return;
            }

            string gender = Console.ReadLine();
            if (gender != "male" && gender != "female")
            {
                Console.WriteLine("<h2>Incorrect data</h2>");
                return;
            }

            string pin = Console.ReadLine();
            if (pin.Length != 10 || pin.Any(pinDigit => !char.IsDigit(pinDigit)))
            {
                Console.WriteLine("<h2>Incorrect data</h2>");
                return;
            }

            int genderCheck = int.Parse(pin.Substring(8, 1));
            string realGender = "";

            if (genderCheck % 2 == 0)
            {
                realGender = "male";
            }
            else
            {
                realGender = "female";
            }

            if (realGender != gender)
            {
                Console.WriteLine("<h2>Incorrect data</h2>");
                return;
            }

            int first = int.Parse(pin[0].ToString());
            int second = int.Parse(pin[1].ToString());
            int third = int.Parse(pin[2].ToString());
            int forth = int.Parse(pin[3].ToString());
            int fifth = int.Parse(pin[4].ToString());
            int sixth = int.Parse(pin[5].ToString());
            int seventh = int.Parse(pin[6].ToString());
            int eight = int.Parse(pin[7].ToString());
            int ninth = int.Parse(pin[8].ToString());

            int sum = first * 2 + second*4 + third*8 + forth*5 + fifth*10 + sixth*9 + seventh*7 +
                      eight*3 + ninth*6;
            
            int remaider = sum % 11;
            
            if (remaider == 10)
            {
                remaider = 0;
            }
            
            int lastNum = int.Parse(pin[9].ToString());
            
            if ( lastNum != remaider)
            {
                Console.WriteLine("<h2>Incorrect data</h2>");
                return;
            }
         
            Console.WriteLine("{\"name\":\"" + name + "\",\"gender\":\"" + gender + "\",\"pin\":\"" + pin + "\"}");
        }
    }
}
