using System;

namespace _02GenericBoxOfInteger
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                var box = new Box<int>(number);

                Console.WriteLine(box);
            }
        }
    }
}