using System;

namespace Spice_Must_Flow_09
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int days= 0;
            long totalAmount = 0;

            if (startingYield >= 100)
            {
                while (startingYield >= 100)
                {
                    days++;
                    totalAmount += startingYield - 26;
                    startingYield -= 10;
                }

                Console.WriteLine($"{days}\n{totalAmount - 26}");
            }
            else
            {
                Console.WriteLine($"0\n0");
            }
        }
    }
}