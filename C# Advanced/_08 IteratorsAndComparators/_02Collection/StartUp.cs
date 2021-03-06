﻿using System;
using System.Linq;

namespace _02Collection
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split().Skip(1).ToArray();
            
            ListyIterator<string> listy = new ListyIterator<string>(tokens);
            
            string command = Console.ReadLine();
            
            while (command != "END")
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(listy.Move());
                        break;
                    case "Print":
                        listy.Print();
                        break;
                    case "HasNext":
                        Console.WriteLine(listy.HasNext());
                        break;
                    case "PrintAll":
                        listy.PrintAll();
                        break;
                }
                
                command = Console.ReadLine();
            }
        }
    }
}