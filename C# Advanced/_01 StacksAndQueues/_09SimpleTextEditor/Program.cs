using System;
using System.Collections.Generic;
using System.Text;

namespace _09SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            Stack<string> textLog = new Stack<string>();
            
            StringBuilder text = new StringBuilder();
            
            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();
                
                int commandName = command[0] - '0';

                if (commandName == 4 && textLog.Count > 0)
                {
                    text = new StringBuilder(textLog.Pop());
                    continue;
                }
                
                string argument = command.Substring(2);
                
                if (commandName == 1)
                {
                    textLog.Push(text.ToString());
                    text.Append(string.Join("", argument.Split()));
                }
                else if (commandName == 2)
                {
                    textLog.Push(text.ToString());
                    text.Remove(text.Length - int.Parse(argument), int.Parse(argument));
                }
                else if (commandName == 3)
                {
                    Console.WriteLine(text[int.Parse(argument) - 1]);
                }
                
            }
        }
    }
}