using System;

namespace Factorial_Division_08
{
    class Program
    {
        static void Main(string[] args)
        {

            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            double division = (double)Factorial(number1) / Factorial(number2);
            
            Console.WriteLine($"{division:F2}");


        }

        static int Factorial(int number)
        {
            
            int factorial = 1;
            for (int i = 1; i <= number; i++)
                {
                    factorial *= i;
                }
                
            return factorial;

        }
        
    }
}