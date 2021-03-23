using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ActivationKeys_01
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder key = new StringBuilder(Console.ReadLine());
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Generate")
                {
                    break;
                }

                string[] instructions = line
                    .Split(">>>", StringSplitOptions.RemoveEmptyEntries);

                string command = instructions[0];
                if (command == "Contains")
                {
                    string pattern = instructions[1];
                    Regex regex = new Regex(pattern);
                    Match match = regex.Match(key.ToString());

                    if (match.Success)
                    {
                        Console.WriteLine($"{key} contains {pattern}");

                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }

                }
                else if (command == "Flip")
                {
                    string upperOrLower = instructions[1];
                    int startIndex = int.Parse(instructions[2]);
                    int endIndex = int.Parse(instructions[3]);
 
                    if (upperOrLower == "Upper")
                    {
                        for (int i = startIndex; i < endIndex; i++)
                        {
                            key[i] = char.Parse(key[i].ToString().ToUpper());
                        }
                        
                        Console.WriteLine(key);
                    }
                    else if (upperOrLower == "Lower")
                    {
                        for (int i = startIndex; i < endIndex; i++)
                        {
                            key[i] = char.Parse(key[i].ToString().ToLower());
                        }

                        Console.WriteLine(key);
                    }
                }
                else if (command == "Slice")
                {
                    int startIndex = int.Parse(instructions[1]);
                    int endIndex = int.Parse(instructions[2]);

                    key.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(key);
                    
                }
            }

            Console.WriteLine($"Your activation key is: {key}");
        }
        
    }
}