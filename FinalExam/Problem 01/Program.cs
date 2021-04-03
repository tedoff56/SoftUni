using System;

namespace Problem_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Sign up")
                {
                    break;
                }

                string[] tokens = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                if (command == "Case")
                {
                    string lowerOrUpper = tokens[1];

                    if (lowerOrUpper == "lower")
                    {
                        username = username.ToLower();
                    }
                    else if (lowerOrUpper == "upper")
                    {
                        username = username.ToUpper();
                    }

                    Console.WriteLine(username);
                }
                else if (command == "Reverse")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);

                    if (!(IsIndexValid(startIndex, username) && IsIndexValid(endIndex, username)))
                    {
                        continue;
                    }
                    
                    int length = endIndex - startIndex + 1;
                    
                    string substring = username.Substring(startIndex, length);
                    
                    Console.WriteLine(Reverse(substring));
                }
                else if (command == "Cut")
                {
                    string substring = tokens[1];

                    if (!username.Contains(substring))
                    {
                        Console.WriteLine($"The word {username} doesn't contain {substring}. ");
                        continue;
                    }

                    username = username.Remove(username.IndexOf(substring), substring.Length);
                    Console.WriteLine(username);
                }
                else if (command == "Replace")
                {
                    char symbol = char.Parse(tokens[1]);

                    if (username.Contains(symbol) && symbol != '*')
                    {
                        username = username.Replace(symbol, '*');
                    }

                    Console.WriteLine(username);
                }
                else if (command == "Check")
                {
                    char symbol = char.Parse(tokens[1]);

                    if (!username.Contains(symbol))
                    {
                        Console.WriteLine($"Your username must contain {symbol}. ");
                        continue;
  
                    }
                    Console.WriteLine("Valid");
                }
                
            }
        }

        private static string Reverse(string str)
        {
            char[] charArr = str.ToCharArray();
            
            Array.Reverse(charArr);
            
            return new string(charArr);
        }

        private static bool IsIndexValid(int index, string str)
        {
            if (index >= 0 && index < str.Length)
            {
                return true;
            }

            return false;
        }
    }
}