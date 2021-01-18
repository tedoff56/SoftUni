using System;

namespace Login_05
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = "";
            int cnt = 0;
            
            while (true)
            {
                password = Console.ReadLine();
                
                char[] charArray = username.ToCharArray();
                Array.Reverse(charArray);
                string usernameReverse = new string(charArray);

                if (password.Equals(usernameReverse))
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
                else
                {
                    cnt++;
                    if (cnt == 4)
                    {
                        Console.WriteLine($"User {username} blocked!");
                        break;
                    }
                    Console.WriteLine("Incorrect password. Try again.");

                }

            }
        }
    }
}