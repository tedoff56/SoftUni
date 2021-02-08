using System;

namespace Password_Validator_04
{
    class Program
    {
        static void Main(string[] args)
        {
            PasswordValidator();
        }

        static void PasswordValidator()
        {
            string password = Console.ReadLine();
            
            bool totalSizeValid = password.Length >= 6 && password.Length <= 10;
            bool digAndLetValid = HasOnlyDigitsAndLeters(password);
            bool atleastTwoDigits = AtleastTwoDigits(password);

            bool passwordIsValid = totalSizeValid && digAndLetValid && atleastTwoDigits;

            if (passwordIsValid)
            {
                Console.WriteLine("Password is valid");
            }
            if(!totalSizeValid)
                Console.WriteLine("Password must be between 6 and 10 characters");
            if(!digAndLetValid)
                Console.WriteLine("Password must consist only of letters and digits");
            if(!atleastTwoDigits)
                Console.WriteLine("Password must have at least 2 digits");
            

        }

        static bool HasOnlyDigitsAndLeters(string password)
        {
            int cnt = 0;
            bool hasOnlyDigAndLet = false;
            for (int i = 0; i < password.Length; i++)
            {
                if ((char) password[i] >= 48 && (char) password[i] <= 57 || 
                    (char) password[i] >= 65 && (char) password[i] <= 90 || 
                    (char) password[i] >= 97 && (char) password[i] <= 122)
                {
                    cnt++;
                }
                
            }

            if (cnt == password.Length)
            {
                hasOnlyDigAndLet = true;
            }

            return hasOnlyDigAndLet;
        }

        static bool AtleastTwoDigits(string password)
        {
            bool hasAtleastTwoDigits = false;
            int totalDigits = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= 48 && password[i] <= 57)
                {
                    totalDigits++;
                }
            }

            if (totalDigits >= 2)
            {
                hasAtleastTwoDigits = true;
            }

            return hasAtleastTwoDigits;
        }
    }
}