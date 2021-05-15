using System;

namespace SoftUni_Reception_01
{
    class Program
    {
        static void Main(string[] args)
        {

            int firstEmployee = int.Parse(Console.ReadLine());
            int secondEmployee = int.Parse(Console.ReadLine());
            int thirdEmployee = int.Parse(Console.ReadLine());

            int studentsCount = int.Parse(Console.ReadLine());

            int studentsPerHour = firstEmployee + secondEmployee + thirdEmployee;
            int time = 0;
            while (studentsCount > 0)
            {

                time++;
                if (time % 4 == 0)
                {
                    continue;
                }
                studentsCount -= studentsPerHour;
                
            }

            Console.WriteLine($"Time needed: {time}h.");
        }
    }
}