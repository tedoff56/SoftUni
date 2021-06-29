using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SportCar car = new SportCar(100, 50);
            
            car.Drive(10);
            Console.WriteLine(car.Fuel);
            car.Drive(10);
            Console.WriteLine(car.Fuel);
        }
    }
}
