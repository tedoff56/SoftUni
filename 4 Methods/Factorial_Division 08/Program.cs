using System;

namespace Factorial_Division_08
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            
            Console.WriteLine($"{FactorialDivision(firstNumber, secondNumber):F2}");
                
        }

        static double FactorialDivision(int firstNumber, int secondNubmer)
        {
            return (double)Factorial(firstNumber) / Factorial(secondNubmer);
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