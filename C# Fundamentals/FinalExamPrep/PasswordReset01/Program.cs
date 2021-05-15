using System;

namespace PasswordReset01
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Done")
                {
                    Console.WriteLine($"Your password is: {password}");
                    break;
                }
                else if (line == "TakeOdd")
                {
                    string concatString = String.Empty;
                    for (int i = 0; i < password.Length; i++)
                    {
                        if (i % 2 == 0)
                        {
                            continue;
                        }
                        concatString += password[i];
                    }

                    password = concatString;
                    Console.WriteLine(password);
                }
                else
                {
                    string[] tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string command = tokens[0];

                    if (command == "Cut")
                    {
                        int index = int.Parse(tokens[1]);
                        int length = int.Parse(tokens[2]);

                        password = password.Remove(index, length);

                        Console.WriteLine(password);
                    }
                    else if (command == "Substitute")
                    {
                        string substring = tokens[1];
                        string substitute = tokens[2];

                        if (!password.Contains(substring))
                        {
                            Console.WriteLine("Nothing to replace!");
                        }
                        else
                        {
                            while (password.Contains(substring))
                            {
                                password = password.Replace(substring, substitute);
                            }
                            
                            Console.WriteLine(password);
                        }
                        
                    }

                }
            }
        }
    }
}