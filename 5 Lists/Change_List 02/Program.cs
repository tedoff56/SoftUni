using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

namespace Change_List_02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> number = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string[] commands = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = commands[0];
                if (command == "end")
                {
                    break;
                }
                int parameter = int.Parse(commands[1]);

                if (command == "Delete")
                {
                    for (int i = 0; i < number.Count; i++)
                    {
                        if (number[i] == parameter)
                        {
                            number.RemoveAt(i);
                        }
                    }
                }
                if (command == "Insert")
                {
                    number.Insert(int.Parse(commands[2]), parameter);
                }

            }

            Console.WriteLine(string.Join(" ", number));
        }
    }
}