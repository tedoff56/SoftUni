using System;

namespace ValidUsernames01
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var username in usernames)
            {
                if (IsValid(username))
                {
                    Console.WriteLine(username);
                }
            }
        }

        static bool IsValid(string username)
        {
            bool hasValidLength = username.Length >= 3 && username.Length <= 16;
            
            return hasValidLength && HasOnlyValidSymbols(username);
        }

        static bool HasOnlyValidSymbols(string username)
        {
            foreach (var letter in username)
            {
                if (!(char.IsLetterOrDigit(letter) || letter == '-' || letter == '_'))
                {
                    return false;
                }
            }

            return true;
        }
    }
}