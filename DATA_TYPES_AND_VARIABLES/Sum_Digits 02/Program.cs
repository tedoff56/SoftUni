using System;
namespace Sum_Digits_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int sum = 0;
            
            for (int i = 0; i < number.Length ; i++)
            {
                sum += (number[i] - '0');
            }
            Console.WriteLine(sum);
        }
    }
}