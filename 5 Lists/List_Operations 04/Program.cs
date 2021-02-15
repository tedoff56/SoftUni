using System;
using System.Collections.Generic;
using System.Linq;

namespace List_Operations_04
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbersList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }

                string[] parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];

                if (command == "Add") 
                {
                    int number = int.Parse(parts[1]);
                    
                    numbersList.Add(number);
                }
                else if (command == "Insert")
                {
                    int number = int.Parse(parts[1]);
                    int index = int.Parse(parts[2]);
                    
                    if (index < numbersList.Count && index >= 0)
                    {
                        numbersList.Insert(index, number);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (command == "Remove")
                {
                    int index = int.Parse(parts[1]);
                    
                    if (index < numbersList.Count && index >= 00)
                    {
                        numbersList.RemoveAt(index);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (command == "Shift")
                {
                    string side = parts[1];
                    int repeatTimes = int.Parse(parts[2]);
                    
                    if (side == "left")
                    {
                        for (int i = 0; i < repeatTimes; i++)
                        {
                            numbersList.Add(numbersList[0]);
                            numbersList.RemoveAt(0);
                        }

                    }
                    else if(side == "right")
                    {
                        for (int i = 0; i < repeatTimes; i++)
                        {
                            numbersList.Insert(0, numbersList.Last());
                            numbersList.RemoveAt(numbersList.Count - 1);
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ",numbersList));
        }
    }
}