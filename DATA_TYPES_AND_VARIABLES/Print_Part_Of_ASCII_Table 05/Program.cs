using System;

namespace Print_Part_Of_ASCII_Table_05
{
    class Program
    {
        static void Main(string[] args)
        {

            int from = int.Parse(Console.ReadLine());
            int to = int.Parse(Console.ReadLine());

            for (int i = from; i <= to; i++)
            {
                
                Console.Write($"{(char)i} ");
            }
        }
    }
}