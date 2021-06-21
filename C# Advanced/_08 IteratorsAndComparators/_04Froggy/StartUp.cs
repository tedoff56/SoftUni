using System;
using System.Linq;

namespace _04Froggy
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var lake = new Lake<int>(Console.ReadLine()?.Split(", ").Select(int.Parse).ToArray());

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}