using System;
using System.Linq;

namespace Array_Manipulator_11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            
            if (command[0].Equals("exchange"))
            {
                Console.WriteLine("exchange");
            }
            else if(command[0].Equals("max"))
            {
                string evenOdd = command[1];
            }
            else if (command[0].Equals("min"))
            {
                string evenOdd = command[1];
            }
        }

        static void exchange(int[] arr)
        {
            int index = int.Parse(Console.ReadLine());

        }
        
    }
}