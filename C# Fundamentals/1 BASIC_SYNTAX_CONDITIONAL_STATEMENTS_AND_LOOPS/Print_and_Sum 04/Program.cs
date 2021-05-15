using System;

namespace Print_and_Sum_04
{
    class Program
    {
        static void Main(string[] args)
        {
            int fromNum = int.Parse(Console.ReadLine());
            int toNum = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = fromNum; i <= toNum; i++)
            {
                if (i == toNum)
                {
                    Console.WriteLine(i);
                }
                else
                {
                    Console.Write($"{i} ");
                }
                sum += i;
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}