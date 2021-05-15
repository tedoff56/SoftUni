using System;

namespace Add_and_Subtract_05
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(Subtract(Sum(firstNumber, secondNumber), thirdNumber));

        }

        static int Sum(int n1, int n2)
        {
            return n1 + n2;
        }

        static int Subtract(int n1, int n2)
        {
            return n1 - n2 ;
        }
    }
}