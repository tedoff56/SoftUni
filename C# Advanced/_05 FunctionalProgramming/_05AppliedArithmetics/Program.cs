using System;
using System.Linq;

namespace _05AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            
            while (true)
            {
                string command = Console.ReadLine()?.ToLower();
                
                if (command == "end")
                {
                    break;
                }
                
                if (command == "print")
                {
                    Console.WriteLine(string.Join(' ', numbers));
                    continue;
                }
                
                Func<int, int> action = n =>
                    command == "add" ? ++n : 
                    command == "subtract" ? --n :
                    command == "multiply" ? n * 2 : n;
                
                numbers = numbers.Select(action).ToArray();
            }
            
        }
    }
}