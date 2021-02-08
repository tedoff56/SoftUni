using System;

namespace Middle_Characters_06
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            MiddleChar(str);
        }

        static void MiddleChar(string input)
        {
            if (input.Length % 2 == 0)
            {
                Console.Write(input[(input.Length/2) - 1]);
                Console.Write(input[input.Length/2]);
            }
            else
            {
                Console.WriteLine(input[(input.Length/2)]);
            }
        }
    }
}