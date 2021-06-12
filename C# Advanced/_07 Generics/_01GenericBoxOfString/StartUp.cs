using System;

namespace _01GenericBoxOfString
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string str = Console.ReadLine();

                var box = new Box<string>(str);

                Console.WriteLine(box);
            }
        }
    }
}