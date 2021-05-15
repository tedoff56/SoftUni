using System;

namespace Characters_in_Range_03
{
    class Program
    {
        static void Main(string[] args)
        {
            char from = Char.Parse(Console.ReadLine());
            char to = Char.Parse(Console.ReadLine());

            CharsInRange(from, to);
        }

        static void CharsInRange(char from, char to)
        {

            if (from > to)
            {
                for (int i = to+1; i < from; i++)
                {
                    Console.Write($"{(char)i} ");
                }
            }
            else
            {
                for (int i = from+1; i < to; i++)
                {
                    Console.Write($"{(char)i} ");
                }
            }

        }
    }
}