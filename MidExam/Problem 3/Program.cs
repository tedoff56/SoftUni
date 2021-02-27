using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> chat = new List<string>();
            
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                
                string action = tokens[0];
                string message = tokens[1];

                if (action == "Chat")
                {
                    chat.Add(message);
                }
                else if (action == "Delete")
                {
                    if (chat.Contains(message))
                    {
                        chat.Remove(message);
                    }
                }
                else if (action == "Edit")
                {
                    string editedMessage = tokens[2];
                    chat[chat.IndexOf(message)] = editedMessage;

                }
                else if (action == "Pin")
                {
                    chat.Remove(message);
                    chat.Add(message);
                }
                else if (action == "Spam")
                {
                    string[] spam = tokens.Where(n => n != "Spam").ToArray();
                    chat.AddRange(spam);
                    
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join("\n", chat));
        }
    }
}