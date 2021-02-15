using System;

namespace Middle_Characters_06
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            Console.WriteLine(MiddleChar(str));
        }

        static string MiddleChar(string input)
        {
            int center = input.Length / 2;
            if (input.Length % 2 == 0) 
            {
                return $"{input[center - 1]}{input[center]}";

            }
            
            return $"{input[center]}";
        }
    }
}