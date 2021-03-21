using System;
using System.Linq;
using System.Text;

namespace StringExplosion07
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder input = new StringBuilder(Console.ReadLine());
            StringBuilder result = new StringBuilder();
            result.Append(input);
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                if (currentChar != '>')
                {
                    continue;;
                }
                int strength = input[i + 1] - '0';

                


            }
        }
    }
}