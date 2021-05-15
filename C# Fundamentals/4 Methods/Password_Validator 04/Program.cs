using System;

namespace Password_Validator_04
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            
            if (TotalSizeValid(password) && 
                HasOnlyDigitsAndLeters(password) && 
                AtleastTwoDigits(password))
            {
                Console.WriteLine("Password is valid");
            }
            
            if(!TotalSizeValid(password))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            
            if(!HasOnlyDigitsAndLeters(password))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            
            if(!AtleastTwoDigits(password))
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
        }

        static bool TotalSizeValid(string password)
        {
            if (password.Length >= 6 && password.Length <= 10)
            {
                return true;
            }

            return false;
        }
        static bool HasOnlyDigitsAndLeters(string password)
        {
            int cnt = 0;
            foreach (var symbol in password)
            {
                if (char.IsLetterOrDigit(symbol))
                    {
                        cnt++;
                    }
            }

            if (cnt == password.Length)
            {
                return true;
            }

            return false;
        }

        static bool AtleastTwoDigits(string password)
        {
            int totalDigits = 0;
            foreach (var digit in password)
            {
                if (char.IsDigit(digit))
                {
                    totalDigits++;
                }
            }

            if (totalDigits >= 2)
            {
                return true;
            }

            return false;
        }
    }
}