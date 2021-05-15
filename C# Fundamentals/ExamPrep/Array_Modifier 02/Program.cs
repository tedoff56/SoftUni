using System;
using System.Linq;
using Microsoft.VisualBasic;

namespace Array_Modifier_02
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] tokens = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string action = tokens[0];

                if (action == "swap")
                {
                    int index1 = int.Parse(tokens[1]);
                    int index2 = int.Parse(tokens[2]);

                    int oldNumber = numbers[index1];
                    numbers[index1] = numbers[index2];
                    numbers[index2] = oldNumber;
                }
                else if (action == "multiply")
                {
                    int index1 = int.Parse(tokens[1]);
                    int index2 = int.Parse(tokens[2]);

                    numbers[index1] *= numbers[index2];
                }
                else if (action == "decrease")
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i]--;
                    }
                }

                
                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}