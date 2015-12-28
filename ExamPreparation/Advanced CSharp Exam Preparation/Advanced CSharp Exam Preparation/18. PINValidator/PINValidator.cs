using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace _18.PINValidator
{
    using System;

    public class PINValidator
    {
        static void Main()
        {
            string name = Console.ReadLine();
            string gender = Console.ReadLine();
            string pin = Console.ReadLine();


            var isValid = IsValidData(name, pin, gender);

            if (isValid)
            {
                Console.WriteLine("{{\"name\":\"{0}\",\"gender\":\"{1}\",\"pin\":\"{2}\"}}", name, gender, pin);
            }
            else
            {
                Console.WriteLine("<h2>Incorrect data</h2>");
            }
        }

        private static bool IsValidData(string name, string pin, string gender)
        {
            if (!Regex.IsMatch(name, @"^[A-Z]([a-z])+\s[A-Z]([a-z])+$"))
            {
                return false;
            }

            if (pin.Length != 10 || pin.Any(pinDigit => !char.IsDigit(pinDigit)))
            {
                return false;
            }

            int month = int.Parse(pin.Substring(2, 2));
            int realMonth = 0;
            if (1 <= month && month <= 12)
            {
                realMonth = month;
            }
            else if (21 <= month && month <= 32)
            {
                realMonth = month - 20;
            }
            else if (41 <= month && month <= 52)
            {
                realMonth = month - 40;
            }
            else
            {
                return false;
            }

            try
            {
                string birthdayAsString = realMonth + "/" + pin.Substring(4, 2) + "/" + pin.Substring(0, 2);
                Convert.ToDateTime(birthdayAsString, CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                return false;
            }

            if (!VerifyGender(pin, gender))
            {
                return false;
            }

            if (!VerifyChecksum(pin))
            {
                return false;
            }

            return true;
        }

        private static bool VerifyGender(string pin, string gender)
        {
            if (gender == "male")
            {
                return int.Parse(pin[8].ToString()) % 2 == 0;
            }
            else // gender = "female"
            {
                return int.Parse(pin[8].ToString()) % 2 != 0;
            }
        }

        private static bool VerifyChecksum(string pin)
        {
            int[] pinDigits = pin.Substring(0, 9).Select(ch => int.Parse(ch.ToString())).ToArray();
            int[] weights = new[] { 2, 4, 8, 5, 10, 9, 7, 3, 6 };
            var checksum = (pinDigits
                .Select((element, index) => element * weights[index])
                .Sum()) % 11;
            if (checksum == 10)
            {
                checksum = 0;
            }

            return checksum == int.Parse(pin[9].ToString());
        }
    }
}
