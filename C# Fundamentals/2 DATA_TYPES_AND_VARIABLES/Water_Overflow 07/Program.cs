using System;

namespace Water_Overflow_07
{
    class Program
    {
        static void Main(string[] args)
        {


            int n = int.Parse(Console.ReadLine());
            int tankCapacity = 255;
            int sum = 0;
            
            for (int i = 0; i < n; i++)
            {
                int liters = int.Parse(Console.ReadLine());

                if ((sum + liters) <= tankCapacity)
                    sum += liters;
                else
                    Console.WriteLine("Insufficient capacity!");
            }

            Console.WriteLine(sum);
            
        }

    }
}