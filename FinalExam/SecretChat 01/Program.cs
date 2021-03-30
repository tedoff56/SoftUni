using System;

namespace SecretChat01
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Reveal")
                {
                    break;
                }

                string[] tokens = line.Split(":|:");

                string action = tokens[0];

                if (action == "InsertSpace")
                {
                    int index = int.Parse(tokens[1]);

                    message = message.Insert(index, " ");
                    
                    Console.WriteLine(message);
                }
                else if (action == "Reverse")
                {
                    string substring = tokens[1];

                    if (message.Contains(substring))
                    {
                        int substingIndex = message.IndexOf(substring);

                        message = message.Remove(substingIndex, substring.Length);

                        message = message.Insert(message.Length, Reverse(substring));
                        
                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }

                }
                else if (action == "ChangeAll")
                {
                    string substring = tokens[1];
                    string replacement = tokens[2];

                    while (message.Contains(substring))
                    {
                        message = message.Replace(substring, replacement);
                    }
                    Console.WriteLine(message);
                }
                
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}