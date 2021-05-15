using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstEmployee = int.Parse(Console.ReadLine());
            var secondEmployee = int.Parse(Console.ReadLine());
            var thirdEmployee = int.Parse(Console.ReadLine());
            var totalPeople = int.Parse(Console.ReadLine());
            
            var helpPerHour = firstEmployee + secondEmployee + thirdEmployee;


            var time = 0;
            
            // var time = Math.Round((double)totalPeople / helpPerHour, MidpointRounding.ToPositiveInfinity);
            // if (time / 3 >= 0)
            // {
            //     time += Math.Round(time / 3, MidpointRounding.ToNegativeInfinity);
            // }
            
            while (totalPeople > 0)
            {
                time++;
                if (time % 4 == 0)
                {
                    continue;
                }
                
                totalPeople -= helpPerHour;
            }

            Console.WriteLine($"Time needed: {time}h.");
        }
    }
}