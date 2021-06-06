using System;

namespace _05DateModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();

            Console.WriteLine(DateModifier.GetDifference(date1, date2));
        }
    }
}