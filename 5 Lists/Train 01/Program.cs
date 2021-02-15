using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Loader;

namespace Train_01
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> train = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                
                string command = input[0];

                if (command.Equals("end"))
                {
                    break;
                }
                else if (command.Equals("Add") && int.Parse(input[1]) >= 0)
                {
                    train.Add(int.Parse(input[1]));
                }
                else if(int.Parse(command) >= 0)
                {
                    
                    for (int i = 0; i < train.Count; i++)
                        {
                            if (train[i] + int.Parse(command) <= maxCapacity)
                            {
                                train[i] += int.Parse(command);
                                break;
                            }
                        }
                }

            }

            Console.WriteLine(string.Join(" ", train));
        }
        
    }
}