using System;
using System.Collections.Generic;
using System.Text;

namespace _09SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalCommands = int.Parse(Console.ReadLine());

            Queue<string> commands = new Queue<string>();
            
            StringBuilder text = new StringBuilder();

            for (int i = 0; i < totalCommands; i++)
            {
                commands.Enqueue(Console.ReadLine());
            }

            for (int i = 0; i < totalCommands; i++)
            {
                string command = commands.Dequeue();

                if (command.Length < 3) 
                {
                    continue;
                }
                
                string str = command.Substring(2);

                if (command[0] == '1')
                {
                    text.Append(str);
                }
                else if (command[0] == '2')
                {
                    text.Remove(text.Length - int.Parse(command.Substring(2)), text.Length);
                }
                else if (command[0] == '3')
                {
                    Console.WriteLine(text[int.Parse(str)]);
                }
                else if(command[0] == '4')
                {
                    
                }
            }
            
            
        }
    }
}