using System;

namespace Factorial_Division_08
{
    class Program
    {
        static void Main(string[] args)
        {

            double number1 = int.Parse(Console.ReadLine());
            double number2 = int.Parse(Console.ReadLine());
            double division = Factorial(number1) / Factorial(number2);
            
            Console.WriteLine($"{division:F2}");


        }

        static double Factorial(double number)
        {
            
            double factorial = 1;
            for (int i = 1; i <= number; i++)
                {
                    factorial *= i;
                }
                
            return factorial;

        }
        
    }
}