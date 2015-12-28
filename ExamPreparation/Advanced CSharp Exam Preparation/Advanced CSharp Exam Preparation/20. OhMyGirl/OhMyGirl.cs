namespace _20.OhMyGirl
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class OhMyGirl
    {
        public static void Main()
        {
            string key = Console.ReadLine();
            var encryptedMessage = new StringBuilder();
            string currentLine;
            while ((currentLine = Console.ReadLine()) != "END")
            {
                encryptedMessage.Append(currentLine);
            }

            string extendedKey = string.Empty;
            if (!char.IsLetterOrDigit(key[0]))
            {
                // The first symbol is special
                extendedKey += "\\";
            }

            extendedKey += key[0].ToString();
            extendedKey += BuildRegexPattern(key.Substring(1, key.Length - 2));
            if (!char.IsLetterOrDigit(key[key.Length - 1]))
            {
                // The last symbol is special
                extendedKey += "\\";
            }

            extendedKey += key[key.Length - 1].ToString();

            var decryptRegex = new Regex(extendedKey + "(.{2,6})" + extendedKey);
            var matches = decryptRegex.Matches(encryptedMessage.ToString());
            foreach (Match match in matches)
            {
                Console.Write(match.Groups[1]);
            }
        }

        private static string BuildRegexPattern(string key)
        {
            var regex = new Regex("([^A-Za-z0-9])");
            key = regex.Replace(key, "\\$1");

            regex = new Regex("[A-Z]+");
            key = regex.Replace(key, "[A-Z]*");
            regex = new Regex("[a-z]+");
            key = regex.Replace(key, "[a-z]*");
            regex = new Regex("[0-9]+");
            key = regex.Replace(key, "[0-9]*");
            return key;
        }
    }
}
