using System;

namespace Elevator_03
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int capacity = int.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            
            double courses = Math.Ceiling((double)capacity / people);
            Console.WriteLine(courses);
        }
    }
}