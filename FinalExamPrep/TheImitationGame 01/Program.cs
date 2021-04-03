using System;

namespace TheImitationGame_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Decode")
                {
                    Console.WriteLine($"The decrypted message is: {text}");
                    break;
                }

                string[] tokens = line.Split("|", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                if (command == "Move")
                {
                    int lenght = int.Parse(tokens[1]);
                    
                    text = MoveFirstElementsToEnd(text, lenght);
                }
                else if (command == "Insert")
                {
                    int index = int.Parse(tokens[1]);
                    string value = tokens[2];

                    text = text.Insert(index, value);
                }
                else if (command == "ChangeAll")
                {
                    string substring = tokens[1];
                    string replacement = tokens[2];

                    while (text.Contains(substring) && substring != replacement)
                    {
                        text = text.Replace(substring, replacement);
                    }
                }

            }
        }

        private static string MoveFirstElementsToEnd(string text, int length)
        {
            string substring = text.Substring(0, length);
                    
            text = text.Replace(substring, string.Empty);
            
            return text.Insert(text.Length, substring);
        }
    }
}