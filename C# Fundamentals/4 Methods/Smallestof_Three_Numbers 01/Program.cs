using System;

namespace Smallestof_Three_Numbers_01
{
    class Program
    {
        static void Main(string[] args)
        {
            SmallestNumber();
        }

        static void SmallestNumber()
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int smallestNum = Math.Min(firstNum,secondNum);
            smallestNum = Math.Min(smallestNum, thirdNum);
            Console.WriteLine(smallestNum);
        }
    }
}