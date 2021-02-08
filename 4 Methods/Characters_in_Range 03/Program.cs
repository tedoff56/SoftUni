using System;

namespace Characters_in_Range_03
{
    class Program
    {
        static void Main(string[] args)
        {
            CharsInRange();
        }

        static void CharsInRange()
        {
            char from = Char.Parse(Console.ReadLine());
            char to = Char.Parse(Console.ReadLine());
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