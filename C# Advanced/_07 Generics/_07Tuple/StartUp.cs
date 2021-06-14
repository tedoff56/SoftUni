using System;

namespace _07Tuple
{
    class StartUp
    {
        static void Main()
        {
            string[] personAddressInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = $"{personAddressInfo[0]} {personAddressInfo[1]}";

            MyTuple<string, string> myTuple = new MyTuple<string, string>(name, personAddressInfo[2]);

            Console.WriteLine(myTuple);
            
            string[] personBeersInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var tuple2 = new MyTuple<string, int>(personBeersInfo[0], int.Parse(personBeersInfo[1]));

            Console.WriteLine(tuple2);
            
            string[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var tuple3 = new MyTuple<int, double>(int.Parse(numbers[0]), Double.Parse(numbers[1]));

            Console.WriteLine(tuple3);
        }
    }
}